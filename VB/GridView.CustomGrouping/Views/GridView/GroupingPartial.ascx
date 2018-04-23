<%@ Control Language="vb" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="GridView.CustomGrouping.Models" %>

<%
	Html.DevExpress().GridView(Function(settings) AnonymousMethod1(settings)).Bind(Model).Render()
%>

'INSTANT VB TODO TASK: The return type of this anonymous method could not be determined by Instant VB:
private object AnonymousMethod1(object settings)
{
	settings.Name = "dxGridView";
	settings.CallbackRouteValues = New { Controller = "GridView", Action = "GroupingPartial" };
	settings.Columns.Add("ProductID");
	settings.Columns.Add("ProductName");
	settings.Columns.Add("Discontinued", MVCxGridViewColumnType.CheckBox);
	MVCxGridViewColumn column = settings.Columns.Add("UnitPrice");
	column.PropertiesEdit.DisplayFormatString = "c";
	column.Settings.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
	settings.Settings.ShowGroupPanel = True;
	settings.CustomColumnGroup = (sender, e) =>
	{
		e.Result = CustomGroupingHelper.Compare(e.Column.FieldName, e.Value1, e.Value2);
		e.Handled = True;
	};
	settings.CustomColumnSort = (sender, e) =>
	{
		e.Result = CustomGroupingHelper.Compare(e.Column.FieldName, e.Value1, e.Value2);
		e.Handled = True;
	};
	settings.CustomGroupDisplayText = (sender, e) =>
	{
		if (e.Column.FieldName != "UnitPrice")
			Return;
			e.DisplayText = CustomGroupingHelper.GetUnitPriceColumnText(e.Value);
	};
}