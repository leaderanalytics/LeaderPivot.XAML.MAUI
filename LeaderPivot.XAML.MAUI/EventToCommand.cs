using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderAnalytics.LeaderPivot.XAML.MAUI;

public interface ICommunityToolkitValueConverter : IValueConverter
{
    /// <summary>
    /// Gets the <see cref="Type" /> this converter expects to <see cref="Convert" /> from or <see cref="ConvertBack" /> to.
    /// </summary>
    Type FromType { get; }

    /// <summary>
    /// Gets the <see cref="Type" /> this converter expects to <see cref="Convert" /> to or <see cref="ConvertBack" /> from.
    /// </summary>
    Type ToType { get; }

    /// <summary>
    /// Converts the incoming values to a different object
    /// </summary>
    /// <param name="value">The object to convert</param>
    /// <param name="targetType">Target Type</param>
    /// <param name="parameter">Optional Parameters</param>
    /// <param name="culture">Culture Info</param>
    /// <returns>The converted object</returns>
    new object? Convert(object? value, Type targetType, object? parameter, CultureInfo? culture);

    /// <summary>
    /// Converts the object back to the outgoing values
    /// </summary>
    /// <param name="value">The object to convert back</param>
    /// <param name="targetType">Target Type</param>
    /// <param name="parameter">Optional Parameters</param>
    /// <param name="culture">Culture Info</param>
    /// <returns>The object converted back</returns>
    new object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo? culture);

    /// <inheritdoc />
    object? IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        Convert(value, targetType, parameter, culture);

    /// <inheritdoc />
    object? IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        ConvertBack(value, targetType, parameter, culture);
}

public abstract class BaseBehavior<TView> : Behavior<TView> where TView : VisualElement
{
    static readonly MethodInfo? getContextMethod
        = typeof(BindableObject).GetRuntimeMethods()?.FirstOrDefault(m => m.Name is "GetContext");

    static readonly FieldInfo? bindingField
        = getContextMethod?.ReturnType.GetRuntimeField("Binding");

    BindingBase? defaultBindingContextBinding;

    /// <summary>
    /// View used by the Behavior
    /// </summary>
    protected TView? View { get; private set; }

    [MemberNotNullWhen(true, nameof(defaultBindingContextBinding))]
    internal bool TrySetBindingContext(Binding binding)
    {
        if (!IsBound(BindingContextProperty))
        {
            SetBinding(BindingContextProperty, defaultBindingContextBinding = binding);
            return true;
        }

        return false;
    }

    internal bool TryRemoveBindingContext()
    {
        if (defaultBindingContextBinding != null)
        {
            RemoveBinding(BindingContextProperty);
            defaultBindingContextBinding = null;

            return true;
        }

        return false;
    }

    /// <summary>
    /// Virtual method that executes when a property on the View has changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnViewPropertyChanged(TView sender, PropertyChangedEventArgs e)
    {

    }

    /// <inheritdoc/>
    [MemberNotNull(nameof(View))]
    protected override void OnAttachedTo(TView bindable)
    {
        base.OnAttachedTo(bindable);

        View = bindable;
        bindable.PropertyChanged += OnViewPropertyChanged;

        TrySetBindingContext(new Binding
        {
            Path = BindingContextProperty.PropertyName,
            Source = bindable
        });
    }

    /// <inheritdoc/>
    protected override void OnDetachingFrom(TView bindable)
    {
        base.OnDetachingFrom(bindable);

        TryRemoveBindingContext();

        bindable.PropertyChanged -= OnViewPropertyChanged;

        View = null;
    }

    /// <summary>
    /// Virtual method that executes when a binding context is set
    /// </summary>
    /// <param name="property"></param>
    /// <param name="defaultBinding"></param>
    /// <returns></returns>
    [MemberNotNullWhen(true, nameof(bindingField), nameof(getContextMethod))]
    protected bool IsBound(BindableProperty property, BindingBase? defaultBinding = null)
    {
        var context = getContextMethod?.Invoke(this, new object[] { property });
        return context != null
            && bindingField?.GetValue(context) is BindingBase binding
            && binding != defaultBinding;
    }

    void OnViewPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is not TView view)
        {
            throw new ArgumentException($"Behavior Cann Only Be Attached to {typeof(TView)}");
        }

        OnViewPropertyChanged(view, e);
    }
}

public class EventToCommandBehavior : BaseBehavior<VisualElement>
{
    /// <summary>
	/// Backing BindableProperty for the <see cref="EventName"/> property.
	/// </summary>
	public static readonly BindableProperty EventNameProperty =
        BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior), propertyChanged: OnEventNamePropertyChanged);

    /// <summary>
    /// Backing BindableProperty for the <see cref="Command"/> property.
    /// </summary>
    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior));

    /// <summary>
    /// Backing BindableProperty for the <see cref="CommandParameter"/> property.
    /// </summary>
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(EventToCommandBehavior));

    /// <summary>
    /// Backing BindableProperty for the <see cref="EventArgs"/> property.
    /// </summary>
    public static readonly BindableProperty EventArgsConverterProperty =
        BindableProperty.Create(nameof(EventArgsConverter), typeof(ICommunityToolkitValueConverter), typeof(EventToCommandBehavior));

    readonly MethodInfo eventHandlerMethodInfo = typeof(EventToCommandBehavior).GetTypeInfo()?.GetDeclaredMethod(nameof(OnTriggerHandled)) ?? throw new InvalidOperationException($"Cannot find method {nameof(OnTriggerHandled)}");

    Delegate? eventHandler;

    EventInfo? eventInfo;

    /// <summary>
    /// The name of the event that should be associated with <see cref="Command"/>. This is bindable property.
    /// </summary>
    public string? EventName
    {
        get => (string?)GetValue(EventNameProperty);
        set => SetValue(EventNameProperty, value);
    }

    /// <summary>
    /// The Command that should be executed when the event configured with <see cref="EventName"/> is triggered. This is a bindable property.
    /// </summary>
    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    /// An optional parameter to forward to the <see cref="Command"/>. This is a bindable property.
    /// </summary>
    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    /// <summary>
    /// An optional <see cref="ICommunityToolkitValueConverter"/> that can be used to convert <see cref="EventArgs"/> values, associated with the event configured with <see cref="EventName"/>, to values passed into the <see cref="Command"/>. This is a bindable property.
    /// </summary>
    public ICommunityToolkitValueConverter? EventArgsConverter
    {
        get => (ICommunityToolkitValueConverter?)GetValue(EventArgsConverterProperty);
        set => SetValue(EventArgsConverterProperty, value);
    }

    /// <inheritdoc/>
    protected override void OnAttachedTo(VisualElement bindable)
    {
        base.OnAttachedTo(bindable);
        RegisterEvent();
    }

    /// <inheritdoc/>
    protected override void OnDetachingFrom(VisualElement bindable)
    {
        UnregisterEvent();
        base.OnDetachingFrom(bindable);
    }

    static void OnEventNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        => ((EventToCommandBehavior)bindable).RegisterEvent();

    void RegisterEvent()
    {
        UnregisterEvent();

        var eventName = EventName;
        if (View == null || string.IsNullOrWhiteSpace(eventName))
        {
            return;
        }

        eventInfo = View.GetType()?.GetRuntimeEvent(eventName) ??
            throw new ArgumentException($"{nameof(EventToCommandBehavior)}: Couldn't resolve the event.", nameof(EventName));

        ArgumentNullException.ThrowIfNull(eventInfo.EventHandlerType);
        ArgumentNullException.ThrowIfNull(eventHandlerMethodInfo);

        eventHandler = eventHandlerMethodInfo.CreateDelegate(eventInfo.EventHandlerType, this) ??
            throw new ArgumentException($"{nameof(EventToCommandBehavior)}: Couldn't create event handler.", nameof(EventName));

        eventInfo.AddEventHandler(View, eventHandler);
    }

    void UnregisterEvent()
    {
        if (eventInfo != null && eventHandler != null)
        {
            eventInfo.RemoveEventHandler(View, eventHandler);
        }

        eventInfo = null;
        eventHandler = null;
    }

    /// <summary>
    /// Virtual method that executes when a Command is invoked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    [Microsoft.Maui.Controls.Internals.Preserve(Conditional = true)]
    protected virtual void OnTriggerHandled(object? sender = null, object? eventArgs = null)
    {
        var parameter = CommandParameter
            ?? EventArgsConverter?.Convert(eventArgs, typeof(object), null, null)
            ?? eventArgs;

        var command = Command;
        if (command?.CanExecute(parameter) ?? false)
        {
            command.Execute(parameter);
        }
    }
}
