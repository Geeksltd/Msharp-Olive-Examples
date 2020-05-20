# Excel files with dropdowns

![](/Assets/ExcelTemplatesWithDropDowns/1.png)

It is a common scenario to provide a template file for importing data. In this template you may need to provide dropdowns to ley user pick items that are in the database. And the dropdowns could depend on each other or other values in the sheet. To see a complete sample check [this project](/Solutions/ExcelTemplatesWithDropDowns).

The simplest way to count the steps of this requirement is:
- Create a template file in excel and make it a resource in your project.
- Write data into an instance of the template created in the previous step.

## Excel knowledge

First things first, to create the empty template Excel file you need to know a few [formulas](https://exceljet.net/excel-formulas-and-functions). [String concatenation](https://www.ablebits.com/office-addins-blog/2015/07/15/excel-concatenate-strings-cells-columns/), [Address](https://exceljet.net/excel-functions/excel-address-function), [Lookup](https://www.laptopmag.com/articles/excel-2013-vlookup), [SubString](https://www.excel-easy.com/examples/substring.html) and [Indirect](https://support.office.com/en-gb/article/indirect-function-474b3a3a-8a26-4f44-b491-92b6306fa261) are the ones we used in this example.

In our example we have a dropdown that could have only two values `-Yes and No-` simulating a boolean. To create that, first add a title for it in one of the first row's columns. Then select all the columns in that row. After that, from the ribbon bar navigate to Data > Data Validation. Then, set the `Allow` to `List` and set the `Source` to `Yes, No`.

![It could be hard to find the Data Validation icon](/Assets/ExcelTemplatesWithDropDowns/2.png)

We have another dropdown in our example containing the list of brands coming from the database. To do so, follow the steps like the previous dropdown except for the last bit. Set the source to be the first column of another sheet in your excel file -known as Workbook- which is Brands in our example. There are [several sources](https://www.google.com/search?q=excel+formula+select+range+of+cells) online showing how you can do it. Now only the remaining part is to export your list of brands in the Brands sheet when the user requests a template.

The last dropdown in our project is the list of products of the selected brand in the current row. To do so, we need to create a dynamic source in our Data Validation rule. So, we will create a string using `VLookup`, `SubString`, etc., and turn it to a formula using `Indirect`. Please, check [this file](/Solutions/ExcelTemplatesWithDropDowns/Domain/Resources/ImportTemplate.xlsx) for more details.

## Exporting data to the template

We used [DotNetCore.NPOI](https://www.nuget.org/packages/DotNetCore.NPOI/) to manipulate the excel files but you are free to use whatever you think is the right tool for you. Please check [this class]("C:\Projects\Msharp-Olive-Examples\Solutions\ExcelTemplatesWithDropDowns\Domain\Services\ImportTemplateGenerator.cs") for more information.

> Do not forget to protect your exported data with a password and uniqueness rules.