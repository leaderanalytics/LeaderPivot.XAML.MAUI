namespace LeaderAnalytics.LeaderPivot.XAML.MAUI;

public class CellContainer : ContentView
{
    public int RowSpan { get; set; } = 1;
    public int ColSpan { get; set; } = 1;

    
}

public abstract class BaseCell : ContentView, INotifyPropertyChanged
{
    

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

public class DimensionContainerCell : BaseCell
{
    public IList<Dimension> Dimensions
    {
        get { return (IList<Dimension>)GetValue(DimensionsProperty); }
        set { SetValue(DimensionsProperty, value); }
    }

    public static readonly BindableProperty DimensionsProperty =
        BindableProperty.Create("Dimensions", typeof(IList<Dimension>), typeof(DimensionContainerCell), null);

    public bool IsRows
    {
        get { return (bool)GetValue(IsRowsProperty); }
        set { SetValue(IsRowsProperty, value); }
    }

    public static readonly BindableProperty IsRowsProperty =
        BindableProperty.Create("IsRows", typeof(bool), typeof(DimensionContainerCell), false);

    public int MaxDimensions { get; set; }

    public DimensionContainerCell()
    {

    }

    
}

public class GroupHeaderCell : BaseCell
{
    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }

    public static readonly BindableProperty IsExpandedProperty =
        BindableProperty.Create("IsExpanded", typeof(bool), typeof(GroupHeaderCell), true);


    public bool CanToggleExpansion
    {
        get { return (bool)GetValue(CanToggleExpansionProperty); }
        set { SetValue(CanToggleExpansionProperty, value); }
    }

    public static readonly BindableProperty CanToggleExpansionProperty =
        BindableProperty.Create("CanToggleExpansion", typeof(bool), typeof(GroupHeaderCell), true);


    public string NodeID
    {
        get { return (string)GetValue(NodeIDProperty); }
        set { SetValue(NodeIDProperty, value); }
    }

    public static readonly BindableProperty NodeIDProperty =
        BindableProperty.Create("NodeID", typeof(string), typeof(GroupHeaderCell), null);


    public ICommand ToggleNodeExpansionCommand
    {
        get { return (ICommand)GetValue(ToggleNodeExpansionCommandProperty); }
        set { SetValue(ToggleNodeExpansionCommandProperty, value); }
    }

    public static readonly BindableProperty ToggleNodeExpansionCommandProperty =
        BindableProperty.Create("ToggleNodeExpansionCommand", typeof(ICommand), typeof(GroupHeaderCell), null);

}

public class GrandTotalHeaderCell : BaseCell
{
    
}

public class GrandTotalCell : BaseCell
{
    
}

public class MeasureCell : BaseCell
{
    
}

public class MeasureContainerCell : BaseCell
{
    public Style ReloadButtonStyle
    {
        get { return (Style)GetValue(ReloadButtonStyleProperty); }
        set { SetValue(ReloadButtonStyleProperty, value); }
    }

    public static readonly BindableProperty ReloadButtonStyleProperty =
        BindableProperty.Create("ReloadButtonStyle", typeof(Style), typeof(MeasureContainerCell), null);

    public Style MeasureCheckBoxStyle
    {
        get { return (Style)GetValue(MeasureCheckBoxStyleProperty); }
        set { SetValue(MeasureCheckBoxStyleProperty, value); }
    }

    public static readonly BindableProperty MeasureCheckBoxStyleProperty =
        BindableProperty.Create("MeasureCheckBoxStyle", typeof(Style), typeof(MeasureContainerCell), null);


    public Style HiddenDimensionsListBoxStyle
    {
        get { return (Style)GetValue(HiddenDimensionsListBoxStyleProperty); }
        set { SetValue(HiddenDimensionsListBoxStyleProperty, value); }
    }

    public static readonly BindableProperty HiddenDimensionsListBoxStyleProperty =
        BindableProperty.Create("HiddenDimensionsListBoxStyle", typeof(Style), typeof(MeasureContainerCell), null);

    
}

public class MeasureLabelCell : BaseCell
{
    
}

public class MeasureTotalLabelCell : BaseCell
{
    
}

public class TotalCell : BaseCell
{
    
}

public class TotalHeaderCell : BaseCell
{
    
}

