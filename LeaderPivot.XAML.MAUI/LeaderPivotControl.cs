﻿/* 
 * Copyright 2021 Leader Analytics 
 * LeaderAnalytics.com
 * SamWheat.com
 * 
 * Please do not remove this header.
 */

using CommunityToolkit.Maui.Alerts;

namespace LeaderAnalytics.LeaderPivot.XAML.MAUI;

public class LeaderPivotControl : ContentView
{
    #region Properties
    public PivotViewBuilder ViewBuilder
    {
        get { return (PivotViewBuilder)GetValue(ViewBuilderProperty); }
        set { SetValue(ViewBuilderProperty, value); }
    }

    public static readonly BindableProperty ViewBuilderProperty =
        BindableProperty.Create("ViewBuilder", typeof(PivotViewBuilder), typeof(LeaderPivotControl), null, BindingMode.OneWay, null, async (bindable,oldValue,newValue) => await ((LeaderPivotControl)bindable).BuildGrid(null));


    public bool DisplayGrandTotalOption
    {
        get { return (bool)GetValue(DisplayGrandTotalOptionProperty); }
        set { SetValue(DisplayGrandTotalOptionProperty, value); }
    }

    public static readonly BindableProperty DisplayGrandTotalOptionProperty =
        BindableProperty.Create("DisplayGrandTotalOption", typeof(bool), typeof(LeaderPivotControl), true);


    public bool DisplayDimensionButtons
    {
        get { return (bool)GetValue(DisplayDimensionButtonsProperty); }
        set { SetValue(DisplayDimensionButtonsProperty, value); }
    }

    public static readonly BindableProperty DisplayDimensionButtonsProperty =
        BindableProperty.Create("DisplayDimensionButtons", typeof(bool), typeof(LeaderPivotControl), true);


    public bool DisplayMeasureSelectors
    {
        get { return (bool)GetValue(DisplayMeasureSelectorsProperty); }
        set { SetValue(DisplayMeasureSelectorsProperty, value); }
    }

    public static readonly BindableProperty DisplayMeasureSelectorsProperty =
        BindableProperty.Create("DisplayMeasureSelectors", typeof(bool), typeof(LeaderPivotControl), true);


    public bool DisplayReloadDataButton
    {
        get { return (bool)GetValue(DisplayReloadDataButtonProperty); }
        set { SetValue(DisplayReloadDataButtonProperty, value); }
    }

    public static readonly BindableProperty DisplayReloadDataButtonProperty =
        BindableProperty.Create("DisplayReloadDataButton", typeof(bool), typeof(LeaderPivotControl), false);

    // 
    //public bool UseResponsiveSizing
    //{
    //    get { return (bool)GetValue(UseResponsiveSizingProperty); }
    //    set { SetValue(UseResponsiveSizingProperty, value); }
    //}

    //public static readonly BindableProperty UseResponsiveSizingProperty =
    //    BindableProperty.Create("UseResponsiveSizing", typeof(bool), typeof(LeaderPivotControl), false));


    public int CellPadding
    {
        get { return (int)GetValue(CellPaddingProperty); }
        set { SetValue(CellPaddingProperty, value); }
    }

    public static readonly BindableProperty CellPaddingProperty =
        BindableProperty.Create("CellPadding", typeof(int), typeof(LeaderPivotControl), 4);


    public Thickness CellBorderThickness
    {
        get { return (Thickness)GetValue(CellBorderThicknessProperty); }
        set { SetValue(CellBorderThicknessProperty, value); }
    }

    public static readonly BindableProperty CellBorderThicknessProperty =
        BindableProperty.Create("CellBorderThickness", typeof(Thickness), typeof(LeaderPivotControl), null);


    public Brush CellBorderBrush
    {
        get { return (Brush)GetValue(CellBorderBrushProperty); }
        set { SetValue(CellBorderBrushProperty, value); }
    }

    public static readonly BindableProperty CellBorderBrushProperty =
        BindableProperty.Create("CellBorderBrush", typeof(Brush), typeof(LeaderPivotControl), null);


    public bool IsBusy
    {
        get { return (bool)GetValue(IsBusyProperty); }
        set { SetValue(IsBusyProperty, value); }
    }

    public static readonly BindableProperty IsBusyProperty =
        BindableProperty.Create("IsBusy", typeof(bool), typeof(LeaderPivotControl), false, BindingMode.TwoWay);


    public Style MeasureCellStyle
    {
        get { return (Style)GetValue(MeasureCellStyleProperty); }
        set { SetValue(MeasureCellStyleProperty, value); }
    }

    public static readonly BindableProperty MeasureCellStyleProperty =
        BindableProperty.Create("MeasureCellStyle", typeof(Style), typeof(LeaderPivotControl), null);


    public Style TotalCellStyle
    {
        get { return (Style)GetValue(TotalCellStyleProperty); }
        set { SetValue(TotalCellStyleProperty, value); }
    }

    public static readonly BindableProperty TotalCellStyleProperty =
        BindableProperty.Create("TotalCellStyle", typeof(Style), typeof(LeaderPivotControl), null);



    public Style GrandTotalCellStyle
    {
        get { return (Style)GetValue(GrandTotalCellStyleProperty); }
        set { SetValue(GrandTotalCellStyleProperty, value); }
    }

    public static readonly BindableProperty GrandTotalCellStyleProperty =
        BindableProperty.Create("GrandTotalCellStyle", typeof(Style), typeof(LeaderPivotControl), null);



    public Style GroupHeaderCellStyle
    {
        get { return (Style)GetValue(GroupHeaderCellStyleProperty); }
        set { SetValue(GroupHeaderCellStyleProperty, value); }
    }

    public static readonly BindableProperty GroupHeaderCellStyleProperty =
        BindableProperty.Create("GroupHeaderCellStyle", typeof(Style), typeof(LeaderPivotControl), null);



    public Style TotalHeaderCellStyle
    {
        get { return (Style)GetValue(TotalHeaderCellStyleProperty); }
        set { SetValue(TotalHeaderCellStyleProperty, value); }
    }

    public static readonly BindableProperty TotalHeaderCellStyleProperty =
        BindableProperty.Create("TotalHeaderCellStyle", typeof(Style), typeof(LeaderPivotControl), null);



    public Style GrandTotalHeaderCellStyle
    {
        get { return (Style)GetValue(GrandTotalHeaderCellStyleProperty); }
        set { SetValue(GrandTotalHeaderCellStyleProperty, value); }
    }

    public static readonly BindableProperty GrandTotalHeaderCellStyleProperty =
        BindableProperty.Create("GrandTotalHeaderCellStyle", typeof(Style), typeof(LeaderPivotControl), null);



    public Style MeasureTotalLabelCellStyle
    {
        get { return (Style)GetValue(MeasureTotalLabelCellStyleProperty); }
        set { SetValue(MeasureTotalLabelCellStyleProperty, value); }
    }

    public static readonly BindableProperty MeasureTotalLabelCellStyleProperty =
        BindableProperty.Create("MeasureTotalLabelCellStyle", typeof(Style), typeof(LeaderPivotControl), null);


    public Style MeasureContainerCellStyle
    {
        get { return (Style)GetValue(MeasureContainerCellStyleProperty); }
        set { SetValue(MeasureContainerCellStyleProperty, value); }
    }

    public static readonly BindableProperty MeasureContainerCellStyleProperty =
        BindableProperty.Create("MeasureContainerCellStyle", typeof(Style), typeof(LeaderPivotControl), null);


    public Style DimensionContainerCellStyle
    {
        get { return (Style)GetValue(DimensionContainerCellStyleProperty); }
        set { SetValue(DimensionContainerCellStyleProperty, value); }
    }

    public static readonly BindableProperty DimensionContainerCellStyleProperty =
        BindableProperty.Create("DimensionContainerCellStyle", typeof(Style), typeof(LeaderPivotControl), null);


    public Style MeasureLabelCellStyle
    {
        get { return (Style)GetValue(MeasureLabelCellStyleProperty); }
        set { SetValue(MeasureLabelCellStyleProperty, value); }
    }

    public static readonly BindableProperty MeasureLabelCellStyleProperty =
        BindableProperty.Create("MeasureLabelCellStyle", typeof(Style), typeof(LeaderPivotControl), null);


    public Style DimensionButtonStyle
    {
        get { return (Style)GetValue(DimensionButtonStyleProperty); }
        set { SetValue(DimensionButtonStyleProperty, value); }
    }

    public static readonly BindableProperty DimensionButtonStyleProperty =
        BindableProperty.Create("DimensionButtonStyle", typeof(Style), typeof(LeaderPivotControl), null);


    public Style MeasureCheckboxStyle
    {
        get { return (Style)GetValue(MeasureCheckboxStyleProperty); }
        set { SetValue(MeasureCheckboxStyleProperty, value); }
    }

    public static readonly BindableProperty MeasureCheckboxStyleProperty =
        BindableProperty.Create("MeasureCheckboxStyle", typeof(Style), typeof(LeaderPivotControl), null);


    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }
    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create("FontSize", typeof(double), typeof(LeaderPivotControl), 12);




    #endregion

    #region Commands

    public ICommand ReloadDataCommand
    {
        get { return (ICommand)GetValue(ReloadDataCommandProperty); }
        set { SetValue(ReloadDataCommandProperty, value); }
    }

    public static readonly BindableProperty ReloadDataCommandProperty =
        BindableProperty.Create("command", typeof(ICommand), typeof(LeaderPivotControl), null);


    public ICommand DimensionEventCommand
    {
        get { return (ICommand)GetValue(DimensionEventCommandProperty); }
        set { SetValue(DimensionEventCommandProperty, value); }
    }

    public static readonly BindableProperty DimensionEventCommandProperty =
        BindableProperty.Create("DimensionEventCommand", typeof(ICommand), typeof(LeaderPivotControl), null);


    #endregion

    private byte[,]? table;
    private Grid grid;
    private ICommand toggleNodeExpansionCommand;

    

    public LeaderPivotControl()
    {
        Snackbar z = new Snackbar();
        ReloadDataCommand = new AsyncRelayCommand(() => BuildGrid(null));
        DimensionEventCommand = new AsyncRelayCommand<DimensionEventArgs>(DimensionEventCommandHandler);
        toggleNodeExpansionCommand = new AsyncRelayCommand<string>(x => BuildGrid(x));
    }

    

    public async Task BuildGrid(string? nodeID)
    {
        // Row span takes precidence over column span.
        // If a cell spans multiple rows, cells in the second and subsequent rows are pushed to the right - not down.
        // A cell is never pushed down to a lower row - it is pushed to the right.  Therefore a cells row index in the matrix is
        // always the same as it's row number in the grid.
        IsBusy = true;
        await ViewBuilder.BuildMatrix(nodeID);
        grid.Children.Clear();
        grid.RowDefinitions.Clear();
        grid.ColumnDefinitions.Clear();
        int rowCount = ViewBuilder.Matrix.Rows.Count;
        int columnCount = ViewBuilder.Matrix.Rows[0].Cells.Sum(x => x.ColSpan);

        table = new byte[rowCount, columnCount];

        for (int j = 0; j < columnCount; j++)
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

        for (int i = 0; i < rowCount; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            int columnIndex = 0;

            for (int j = 0; j < ViewBuilder.Matrix.Rows[i].Cells.Count; j++)
            {
                MatrixCell? mCell = ViewBuilder.Matrix.Rows[i].Cells[j];
                BaseCell cell = mCell.CellType switch
                {
                    CellType.Measure => new MeasureCell(),
                    CellType.Total => new TotalCell(),
                    CellType.GrandTotal => new GrandTotalCell(),
                    CellType.GroupHeader => new GroupHeaderCell { NodeID = mCell.NodeID, IsExpanded = mCell.IsExpanded, CanToggleExpansion = mCell.CanToggleExapansion, ToggleNodeExpansionCommand = toggleNodeExpansionCommand },
                    CellType.TotalHeader => new TotalHeaderCell(),
                    CellType.GrandTotalHeader => new GrandTotalHeaderCell(),
                    CellType.MeasureTotalLabel => new MeasureTotalLabelCell(),
                    CellType.MeasureLabel when i == 0 && j == 0 => new MeasureContainerCell(),
                    CellType.MeasureLabel when i == 0 && j == 1 => new DimensionContainerCell { Dimensions = ViewBuilder.ColumnDimensions, IsRows = false },
                    CellType.MeasureLabel => new MeasureLabelCell(),
                    _ => throw new NotImplementedException($"Cell type not recognised: {mCell.CellType}.")
                };

                Style? style = cell switch
                {
                    MeasureCell => MeasureCellStyle,
                    TotalCell => TotalCellStyle,
                    GrandTotalCell => GrandTotalCellStyle,
                    GroupHeaderCell => GroupHeaderCellStyle,
                    TotalHeaderCell => TotalHeaderCellStyle,
                    GrandTotalHeaderCell => GrandTotalHeaderCellStyle,
                    MeasureTotalLabelCell => MeasureTotalLabelCellStyle,
                    MeasureContainerCell => MeasureContainerCellStyle,
                    DimensionContainerCell => DimensionContainerCellStyle,
                    MeasureLabelCell => MeasureLabelCellStyle,
                    _ => throw new NotImplementedException($"Object type not recognised: {cell.GetType()}.")
                };

                if (style != null)
                    cell.Style = style;

                CellContainer container = new CellContainer();

                container.RowSpan = mCell.RowSpan;
                container.ColSpan = mCell.ColSpan;
                container.Content = cell;
                cell.Content = new Label { Text = mCell.Value?.ToString() };
                columnIndex = IncrementCol(i, columnIndex, container);
                Grid.SetRow(container, i);
                Grid.SetRowSpan(container, container.RowSpan);
                Grid.SetColumn(container, columnIndex);
                Grid.SetColumnSpan(container, container.ColSpan);
                grid.Children.Add(container);
            }
        }
        IsBusy = false;
    }

    public async Task DimensionEventCommandHandler(DimensionEventArgs dimensionEvent)
    {
        if (dimensionEvent == null)
            throw new ArgumentNullException(nameof(dimensionEvent));
        if (dimensionEvent.Action == DimensionAction.NoOp)
            return;

        Dimension dimension = ViewBuilder.Dimensions.First(x => x.DisplayValue == dimensionEvent.DimensionID);

        var x = dimensionEvent.Action switch
        {
            DimensionAction.SortAscending => dimension.IsAscending = true,
            DimensionAction.SortDescending => dimension.IsAscending = false,
            DimensionAction.Hide => dimension.IsEnabled = false,
            DimensionAction.UnHide => dimension.IsEnabled = true,
            _ => throw new Exception($"DimensionAction not recognised: {dimensionEvent.Action}"),
        };
        await BuildGrid(null);
    }

    private int IncrementCol(int rowIndex, int colIndex, CellContainer cell)
    {
        while (table[rowIndex, colIndex] == 1)
            colIndex++;

        for (int r = rowIndex; r < rowIndex + cell.RowSpan; r++)
            for (int c = colIndex; c < colIndex + cell.ColSpan; c++)
                table[r, c] = 1;

        return colIndex;
    }

    #region IDropTarget
  

    //async void IDropTarget.Drop(IDropInfo dropInfo)
    //{
    //    int insertIndex = dropInfo.UnfilteredInsertIndex;
    //    var sourceList = dropInfo.DragInfo.SourceCollection.TryGetList();
    //    var targetList = dropInfo.TargetCollection.TryGetList();
    //    Dimension sourceItem = (Dimension)dropInfo.Data;
    //    Dimension targetItem = (Dimension)dropInfo.TargetItem;

    //    if (sourceList != targetList)
    //    {
    //        sourceItem.IsRow = !sourceItem.IsRow;

    //        if (targetList.Count == 1 && sourceList.Count == 1)
    //        {
    //            // Swap dimensions across axis...
    //            Dimension otherDimension = targetList.Cast<Dimension>().First(x => x != sourceItem);
    //            targetList.Remove(otherDimension);
    //            otherDimension.IsRow = !otherDimension.IsRow;
    //            sourceList.Add(otherDimension);
    //        }
    //    }
    //    sourceItem.Sequence = insertIndex;
    //    IList<Dimension> dimensions = sourceItem.IsRow ? ViewBuilder.RowDimensions : ViewBuilder.ColumnDimensions;

    //    foreach (Dimension d in dimensions.Where(x => x != sourceItem && x.Sequence >= sourceItem.Sequence))
    //        d.Sequence++;

    //    await BuildGrid(null);

    //}
    #endregion

    #region IDragSource implementation
    //public void StartDrag(IDragInfo dragInfo)
    //{
    //    dragInfo.Data = dragInfo.SourceItem;
    //    dragInfo.Effects = dragInfo.Data != null ? DragDropEffects.Copy | DragDropEffects.Move : DragDropEffects.None;
    //}

    //public bool CanStartDrag(IDragInfo dragInfo)
    //{
    //    var sourceList = dragInfo.SourceCollection?.TryGetList();
    //    Dimension sourceItem = (Dimension)dragInfo.SourceItem;
    //    IList<Dimension> dimensions = sourceItem.IsRow ? ViewBuilder.RowDimensions : ViewBuilder.ColumnDimensions;

    //    // If source dimensions has exactly one dimension, count dimensions on cross axis.
    //    // If cross axis has exactly one dimension allow the drag and swap axis for each 
    //    // dimension on drop. 
    //    // Otherwise do not allow the drag if source dimensions has only one dimension.

    //    if (dimensions.Count == 1)
    //    {
    //        IList<Dimension> crossAxisDimensions = sourceItem.IsRow ? ViewBuilder.ColumnDimensions : ViewBuilder.RowDimensions;

    //        if (crossAxisDimensions.Count > 1)
    //            return false;
    //    }
    //    return true;
    //}

    
    #endregion
}


