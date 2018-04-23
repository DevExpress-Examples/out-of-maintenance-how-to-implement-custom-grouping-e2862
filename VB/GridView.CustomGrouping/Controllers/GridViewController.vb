Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports GridView.CustomGrouping.Models

Namespace GridView.CustomGrouping.Controllers
	<HandleError> _
	Public Class GridViewController
		Inherits Controller
		Public Function Index() As ActionResult
			Return Grouping()
		End Function
		Public Function Grouping() As ActionResult
			Return View("Grouping", NorthwindDataProvider.GetProducts())
		End Function
		Public Function GroupingPartial() As ActionResult
			Return PartialView("GroupingPartial", NorthwindDataProvider.GetProducts())
		End Function
	End Class
End Namespace
