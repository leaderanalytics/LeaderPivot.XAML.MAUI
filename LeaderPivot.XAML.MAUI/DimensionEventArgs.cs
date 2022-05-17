using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderAnalytics.LeaderPivot.XAML.MAUI;
public class DimensionEventArgs
{
    //  Dimension.DisplayName is guaranteed to be unique and is also the ID
    public string DimensionID { get; set; }
    public DimensionAction Action { get; set; }
}
