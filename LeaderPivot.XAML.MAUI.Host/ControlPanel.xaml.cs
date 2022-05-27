using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Drawing;
using CommunityToolkit.Mvvm.Input;

namespace LeaderAnalytics.LeaderPivot.XAML.MAUI.Host;

public partial class ControlPanel : ContentView, INotifyPropertyChanged
{
    public bool DisplayGrandTotalOption
    {
        get { return (bool)GetValue(DisplayGrandTotalOptionProperty); }
        set { SetValue(DisplayGrandTotalOptionProperty, value); }
    }

    public static readonly BindableProperty DisplayGrandTotalOptionProperty =
        BindableProperty.Create("DisplayGrandTotalOption", typeof(bool), typeof(ControlPanel), true);


    public bool DisplayDimensionButtons
    {
        get { return (bool)GetValue(DisplayDimensionButtonsProperty); }
        set { SetValue(DisplayDimensionButtonsProperty, value); }
    }

    public static readonly BindableProperty DisplayDimensionButtonsProperty =
        BindableProperty.Create("DisplayDimensionButtons", typeof(bool), typeof(ControlPanel), true);


    public bool DisplayMeasureSelectors
    {
        get { return (bool)GetValue(DisplayMeasureSelectorsProperty); }
        set { SetValue(DisplayMeasureSelectorsProperty, value); }
    }

    public static readonly BindableProperty DisplayMeasureSelectorsProperty =
        BindableProperty.Create("DisplayMeasureSelectors", typeof(bool), typeof(ControlPanel), true);


    public bool DisplayReloadDataButton
    {
        get { return (bool)GetValue(DisplayReloadDataButtonProperty); }
        set { SetValue(DisplayReloadDataButtonProperty, value); }
    }

    public static readonly BindableProperty DisplayReloadDataButtonProperty =
        BindableProperty.Create("DisplayReloadDataButton", typeof(bool), typeof(ControlPanel), false);

    public string SelectedPivotStyle
    {
        get { return (string)GetValue(SelectedPivotStyleProperty); }
        set { SetValue(SelectedPivotStyleProperty, value); }
    }

    public static readonly BindableProperty SelectedPivotStyleProperty =
        BindableProperty.Create("SelectedPivotStyle", typeof(string), typeof(ControlPanel), null);
    

    public static readonly BindableProperty UseResponsiveSizingProperty =
        BindableProperty.Create("UseResponsiveSizing", typeof(bool), typeof(ControlPanel), false);


    public bool UseDarkTheme
    {
        get { return (bool)GetValue(UseDarkThemeProperty); }
        set { SetValue(UseDarkThemeProperty, value); }
    }

    public static readonly BindableProperty UseDarkThemeProperty =
        BindableProperty.Create("UseDarkTheme", typeof(bool), typeof(ControlPanel), false, BindingMode.OneWay, null, UseDarkThemeChanged);


    public int CellPadding
    {
        get { return (int)GetValue(CellPaddingProperty); }
        set { SetValue(CellPaddingProperty, value); }
    }

    public static readonly BindableProperty CellPaddingProperty =
        BindableProperty.Create("CellPadding", typeof(int), typeof(ControlPanel), 4, BindingMode.OneWay, null, (b, o, n) => ((ControlPanel)b).RaisePropertyChanged(nameof(CellPaddingString)));


    public int PivotControlFontSize
    {
        get { return (int)GetValue(PivotControlFontSizeProperty); }
        set { SetValue(PivotControlFontSizeProperty, value); }
    }

    public static readonly BindableProperty PivotControlFontSizeProperty =
        BindableProperty.Create("PivotControlFontSize", typeof(int), typeof(ControlPanel), 11, BindingMode.OneWay, null, (b, o, n) => ((ControlPanel)b).RaisePropertyChanged(nameof(FontSizeString)));


    private ICommand _TogglePanelVisibilityCommand;
    public ICommand TogglePanelVisibilityCommand
    { 
        get => _TogglePanelVisibilityCommand;
        set => SetProp(ref _TogglePanelVisibilityCommand, value);
    }

    private ICommand _ShowColorPickerPopupCommand;
    public ICommand ShowColorPickerPopupCommand
    {
        get => _ShowColorPickerPopupCommand;
        set => SetProp(ref _ShowColorPickerPopupCommand, value);
    }

    private ICommand _HideColorPickerPopupCommand;
    public ICommand HideColorPickerPopupCommand
    {
        get => _HideColorPickerPopupCommand;
        set => SetProp(ref _HideColorPickerPopupCommand, value);
    }

    private bool _PanelVisibility;
    public bool PanelVisibility
    {
        get => _PanelVisibility;
        set => SetProp(ref _PanelVisibility, value);
    }

    private Microsoft.Maui.Graphics.Color _PrimaryColor;
    public Microsoft.Maui.Graphics.Color PrimaryColor
    {
        get => _PrimaryColor;
        set
        {
            SetProp(ref _PrimaryColor, value);
            ColorsChanged();
        }
    }

    private Microsoft.Maui.Graphics.Color _SecondaryColor;
    public Microsoft.Maui.Graphics.Color SecondaryColor
    {
        get => _SecondaryColor;
        set
        {
            SetProp(ref _SecondaryColor, value);
            ColorsChanged();
        }
    }

    private bool _IsColorPickerPopupOpen;
    public bool IsColorPickerPopupOpen
    {
        get => _IsColorPickerPopupOpen;
        set => SetProp( ref _IsColorPickerPopupOpen, value);
    }

    private ICommand _SelectedThemeChangedCommand;
    public ICommand SelectedThemeChangedCommand
    {
        get => _SelectedThemeChangedCommand;
        set => SetProp(ref _SelectedThemeChangedCommand, value);
    }

    public string CellPaddingString => $"Cell Padding ({CellPadding})";
    public string FontSizeString => $"Font Size ({PivotControlFontSize})";
    

    public ControlPanel()
    {
     
        PanelVisibility = false;
        TogglePanelVisibilityCommand = new RelayCommand(() => PanelVisibility = PanelVisibility ? false : true);
        ShowColorPickerPopupCommand = new RelayCommand(() => IsColorPickerPopupOpen = true);
        HideColorPickerPopupCommand = new RelayCommand(() => IsColorPickerPopupOpen = false);
        //var paletteHelper = new PaletteHelper();
        //var theme = paletteHelper.GetTheme();
        //PrimaryColor = theme.PrimaryMid.Color;
        //SecondaryColor = theme.SecondaryMid.Color;
        //SelectedThemeChangedCommand = new RelayCommand<SelectionChangedEventArgs>((x) => SelectedThemeChangedCommandHandler(x));
        //SetResourceDictionary("Primary", true);
    }

    public static void UseDarkThemeChanged(BindableObject sender, object oldValue, object newValue)
    {
        ControlPanel panel = sender as ControlPanel;
        //var paletteHelper = new PaletteHelper();
        //var theme = paletteHelper.GetTheme();
        //theme.SetBaseTheme(panel.UseDarkTheme ? Theme.Dark : Theme.Light);
        //paletteHelper.SetTheme(theme);
    }

    public void ColorsChanged()
    {
        //var paletteHelper = new PaletteHelper();
        //var theme = paletteHelper.GetTheme();
        //theme.PrimaryLight = new ColorPair(PrimaryColor.Lighten());
        //theme.PrimaryMid = new ColorPair(PrimaryColor);
        //theme.PrimaryDark = new ColorPair(PrimaryColor.Darken());
        
        //theme.SecondaryLight = new ColorPair(SecondaryColor.Lighten());
        //theme.SecondaryMid = new ColorPair(SecondaryColor);
        //theme.SecondaryDark = new ColorPair(SecondaryColor.Darken());
        //paletteHelper.SetTheme(theme);
    }

    private void SelectedThemeChangedCommandHandler(SelectionChangedEventArgs e)
    {
        //string remove = ((ComboBoxItem)e.RemovedItems[0]).Content.ToString();
        //string add = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
        //SetResourceDictionary(remove, false);
        //SetResourceDictionary(add, true);
    }

    private void SetResourceDictionary(string themeName, bool add)
    {
        Uri uri = new Uri($"/LeaderPivot.XAML.WPF.Host;component/Themes/{themeName}.xaml", UriKind.Relative);

        if (add)
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        else
            Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries.First(x => x.Source == uri));
    }

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
