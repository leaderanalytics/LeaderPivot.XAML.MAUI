
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//https://github.com/borisoprit/DragdropMaui
namespace LeaderAnalytics.LeaderPivot.XAML.MAUI;

public class DimensionButton : DropDownButton
{
    public ICommand CheckboxCheckedCommand
    {
        get { return (ICommand)GetValue(CheckboxCheckedCommandProperty); }
        set { SetValue(CheckboxCheckedCommandProperty, value); }
    }

    public static readonly BindableProperty CheckboxCheckedCommandProperty =
        BindableProperty.Create("CheckboxCheckedCommand", typeof(ICommand), typeof(DimensionButton), null);


    public object CommandParameter
    {
        get { return (object)GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create("CommandParameter", typeof(object), typeof(DimensionButton), null);


    //public IInputElement CommandTarget
    //{
    //    get { return (IInputElement)GetValue(CommandTargetProperty); }
    //    set { SetValue(CommandTargetProperty, value); }
    //}

    //public static readonly BindableProperty CommandTargetProperty =
    //    BindableProperty.Create("CommandTarget", typeof(IInputElement), typeof(DimensionButton), null);


    public Dimension Dimension
    {
        get { return (Dimension)GetValue(DimensionProperty); }
        set { SetValue(DimensionProperty, value); }
    }

    public static readonly BindableProperty DimensionProperty =
        BindableProperty.Create("Dimension", typeof(Dimension), typeof(DimensionButton), null);


    

    public DimensionButton() => CheckboxCheckedCommand = new RelayCommand<DimensionAction>(x => SelectedItem = x);
}

