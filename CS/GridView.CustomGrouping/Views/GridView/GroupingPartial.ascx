<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="GridView.CustomGrouping.Models" %>

<%
    Html.DevExpress().GridView( settings => {
        settings.Name = "dxGridView";
        settings.CallbackRouteValues = new { Controller = "GridView", Action = "GroupingPartial" };

        settings.Columns.Add("ProductID");
        settings.Columns.Add("ProductName");
        settings.Columns.Add("Discontinued", MVCxGridViewColumnType.CheckBox);
        MVCxGridViewColumn column = settings.Columns.Add("UnitPrice");
        column.PropertiesEdit.DisplayFormatString = "c";
        column.Settings.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;

        settings.Settings.ShowGroupPanel = true;
        settings.CustomColumnGroup = (sender, e) => {
            e.Result = CustomGroupingHelper.Compare(e.Column.FieldName, e.Value1, e.Value2);
            e.Handled = true;
        };
        settings.CustomColumnSort = (sender, e) => {
            e.Result = CustomGroupingHelper.Compare(e.Column.FieldName, e.Value1, e.Value2);
            e.Handled = true;
        };
        settings.CustomGroupDisplayText = (sender, e) => {
            if (e.Column.FieldName != "UnitPrice") 
                return;
            e.DisplayText = CustomGroupingHelper.GetUnitPriceColumnText(e.Value);
        };
    })
    .Bind(Model)
    .Render();
%>