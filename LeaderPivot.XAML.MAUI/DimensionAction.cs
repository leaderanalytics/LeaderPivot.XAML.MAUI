using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderAnalytics.LeaderPivot.XAML.MAUI;
public enum DimensionAction
{
    [Description("Do nothing")]
    NoOp,
    [Description("Sort Ascending")]
    SortAscending,
    [Description("Sort Descending")]
    SortDescending,
    [Description("Hide")]
    Hide,
    [Description("UnHide")]
    UnHide
}