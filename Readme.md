<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550079/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T328882)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [FilterConfig.cs](./CS/GridViewBatchEdit/App_Start/FilterConfig.cs)
* [RouteConfig.cs](./CS/GridViewBatchEdit/App_Start/RouteConfig.cs)
* [WebApiConfig.cs](./CS/GridViewBatchEdit/App_Start/WebApiConfig.cs)
* [HomeController.cs](./CS/GridViewBatchEdit/Controllers/HomeController.cs)
* [Model.cs](./CS/GridViewBatchEdit/Models/Model.cs)
* **[_GridViewPartial.cshtml](./CS/GridViewBatchEdit/Views/Home/_GridViewPartial.cshtml)**
* [Index.cshtml](./CS/GridViewBatchEdit/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to filter dates by the month
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t328882/)**
<!-- run online end -->


<p>By default, GridView uses cell values for filtering. At the same time, the control can display custom text in cells. The solution is based on these aspects.</p>
<p>1. Add an <a href="https://documentation.devexpress.com/#AspNet/CustomDocument16859">unbound columns</a> to display dates:</p>


```cs
settings.Columns.Add(column =>
{
    column.FieldName = "Month";
    column.ColumnType = MVCxGridViewColumnType.DateEdit;
    column.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
    column.SettingsHeaderFilter.Mode = GridHeaderFilterMode.CheckedList;
})

```


<p> Note, its <em>UnboundType</em> is <em>Integer</em>, but not <em>DateTime</em>. The column will contain the numbers of months.</p>
<p>Handle the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridView_CustomUnboundColumnDatatopic">CustomUnboundColumnData</a> event to populate column cells by month numbers:</p>


```cs
settings.CustomUnboundColumnData = (sender, e) =>
{
    if (e.Column.FieldName == "Month")
    {
        DateTime value = (DateTime)e.GetListSourceFieldValue("C5");
        e.Value = value.Month;
    }
};

```


<p> The <em>C5</em> field is a real column in GridView. If you do not need to show it to an end-user, you can hide this column. However, it is required for getting unbound column data.</p>
<p><br>Now the unbound column displays month values. However, if you wish to show an end-user full dates, handle the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridView_CustomColumnDisplayTexttopic">CustomColumnDisplayText</a> event and implement the following handler:</p>


```cs
settings.CustomColumnDisplayText = (sender, e) =>
{
    if (e.Column.FieldName == "Month")
    {
        DateTime realValue = ((DateTime)e.GetFieldValue("C5"));
        e.DisplayText = realValue.ToString("dd MMM yyyy");
    }
};

```


<p> The data is returned from the bound <em>C5 </em>data column, but shown in the unbound column.</p>
<p><br>Finally, update the Header Filter items as demonstrated below:</p>


```cs
settings.HeaderFilterFillItems = (sender, e) =>
{
    if (e.Column.FieldName == "Month")
    {
        e.Values.Clear();
        e.AddValue("January", "1");
        e.AddValue("February", "2");
        e.AddValue("March", "3");
        e.AddValue("April", "4");
        e.AddValue("May", "5");
        e.AddValue("June", "6");
        e.AddValue("July", "7");
        e.AddValue("August", "8");
        e.AddValue("September", "9");
        e.AddValue("October", "10");
        e.AddValue("November", "11");
        e.AddValue("December", "12");
    }
};
```



<br/>


