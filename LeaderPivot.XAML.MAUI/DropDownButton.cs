
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeaderAnalytics.LeaderPivot.XAML.MAUI;

public class DropDownButton : ContentView, INotifyPropertyChanged
{
    #region BindableProperties
    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create("Command", typeof(ICommand), typeof(DropDownButton), null, BindingMode.TwoWay);


    public ICommand SelectionChangedCommand
    {
        get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
        set { SetValue(SelectionChangedCommandProperty, value); }
    }

    public static readonly BindableProperty SelectionChangedCommandProperty =
        BindableProperty.Create("SelectionChangedCommand", typeof(ICommand), typeof(DropDownButton), null, BindingMode.TwoWay);


    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(DropDownButton), null);


    public object SelectedItem
    {
        get { return (object)GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }

    public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create("SelectedItem", typeof(object), typeof(DropDownButton), null,  BindingMode.TwoWay);


    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemTemplateProperty); }
        set { SetValue(ItemTemplateProperty, value); }
    }

    public static readonly BindableProperty ItemTemplateProperty =
        BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(DropDownButton), null);


    public Style ButtonStyle
    {
        get { return (Style)GetValue(ButtonStyleProperty); }
        set { SetValue(ButtonStyleProperty, value); }
    }

    public static readonly BindableProperty ButtonStyleProperty =
        BindableProperty.Create("ButtonStyle", typeof(Style), typeof(DropDownButton), null);


    public Style ListBoxStyle
    {
        get { return (Style)GetValue(ListBoxStyleProperty); }
        set { SetValue(ListBoxStyleProperty, value); }
    }

    public static readonly BindableProperty ListBoxStyleProperty =
        BindableProperty.Create("ListBoxStyle", typeof(Style), typeof(DropDownButton), null);



    public Style ListBoxItemStyle
    {
        get { return (Style)GetValue(ListBoxItemStyleProperty); }
        set { SetValue(ListBoxItemStyleProperty, value); }
    }

    public static readonly BindableProperty ListBoxItemStyleProperty =
        BindableProperty.Create("ListBoxItemStyle", typeof(Style), typeof(DropDownButton), null);


    public Style PopupStyle
    {
        get { return (Style)GetValue(PopupStyleProperty); }
        set { SetValue(PopupStyleProperty, value); }
    }

    public static readonly BindableProperty PopupStyleProperty =
        BindableProperty.Create("PopupStyle", typeof(Style), typeof(DropDownButton), null);


    public Thickness PopupPadding
    {
        get { return (Thickness)GetValue(PopupPaddingProperty); }
        set { SetValue(PopupPaddingProperty, value); }
    }

    public static readonly BindableProperty PopupPaddingProperty =
        BindableProperty.Create("PopupPadding", typeof(Thickness), typeof(DropDownButton), new Thickness());



    #endregion

    private bool _IsDropDownOpen;
    public bool IsDropDownOpen
    {
        get => _IsDropDownOpen;
        set => SetProp(ref _IsDropDownOpen, value);
    }

    private ICommand _ToggleDropDownCommand;
    public ICommand ToggleDropDownCommand
    {
        get => _ToggleDropDownCommand;
        set => SetProp(ref _ToggleDropDownCommand, value);
    }

    private ICommand _MouseLeaveCommand;
    public ICommand MouseLeaveCommand
    {
        get => _MouseLeaveCommand;
        set => SetProp(ref _MouseLeaveCommand, value);
    }

    public static readonly BindableProperty JunkCommandProperty =
        BindableProperty.Create("JunkCommand", typeof(ICommand), typeof(DropDownButton), null);



    public DropDownButton()
    {
        Loaded += DropDownButton_Loaded;
        ToggleDropDownCommand = new RelayCommand(() => IsDropDownOpen = !IsDropDownOpen);
        MouseLeaveCommand = new RelayCommand(() => IsDropDownOpen = false);
    }

    private void DropDownButton_Loaded(object sender, EventArgs e)
    {
        Loaded -= DropDownButton_Loaded;
        ListView lb = GetTemplateChild("PART_ListBox") as ListView;

        if (lb != null)
            lb.ItemSelected += (s, e) => SelectionChanged(s, e);
    }

    public event EventHandler SelectionChanged;

    


    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler? PropertyChanged;
    public void RaisePropertyChanged([CallerMemberNameAttribute] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void SetProp<T>(ref T prop, T value, [CallerMemberNameAttribute] string propertyName = "")
    {
        if (!Object.Equals(prop, value))
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }
    }
    #endregion
}
