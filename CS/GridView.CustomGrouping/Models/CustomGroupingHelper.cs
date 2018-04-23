using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace GridView.CustomGrouping.Models {
    public static class CustomGroupingHelper {
        public static int Compare(string columnName, object value1, object value2) {
            int res = 0;
            if(columnName == "UnitPrice") {
                double x = Math.Floor(Convert.ToDouble(value1) / 10);
                double y = Math.Floor(Convert.ToDouble(value2) / 10);
                res = Comparer.Default.Compare(x, y);
                if(x > 9 && y > 9) res = 0;
            }

            return res;
        }
        public static string GetUnitPriceColumnText(object value) {
            double d = Math.Floor(Convert.ToDouble(value) / 10);
            string displayText = string.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10);
            if(d > 9) displayText = string.Format(">= {0:c} ", 100);
            return displayText;
        }
    }
}