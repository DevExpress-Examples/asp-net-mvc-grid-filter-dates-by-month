# GridView - How to filter dates by the month


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


