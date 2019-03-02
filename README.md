# CSV2Entity

[![Build status](https://ci.appveyor.com/api/projects/status/637a70iwpkcusjab?svg=true)](https://ci.appveyor.com/project/juwikuang/csv2entity)
[![Build Status](https://dev.azure.com/juwikuang/CSV2Entity/_apis/build/status/juwikuang.csv2entity?branchName=master)](https://dev.azure.com/juwikuang/CSV2Entity/_build/latest?definitionId=1?branchName=master)

## Install

### Install Core from Nuget

* [CSV2Entity](https://www.nuget.org/packages/Ezfx.Csv) [![Nuget](http://img.shields.io/nuget/v/Ezfx.Csv.svg?maxAge=10800)](https://www.nuget.org/packages/Ezfx.Csv/)

### Instial Visual Studio Extension from marketplace

https://marketplace.visualstudio.com/items?itemName=EricZhou.int123

To view the introduce Video please visit:

[https://youtu.be/z3eB05DaQuI](https://youtu.be/z3eB05DaQuI)


## What is CSV

CSV is the abbreviation of Comma-separated values, a file format stores tabular data in plain-text form, usually with .csv extension. CSV is a simple file format that is widely supported by consumer, business, and scientific applications.

Examples

Example of a USA/UK CSV file




	Year,Make,Model,Length

	1997,Ford,E350,2.34

	2000,Mercury,Cougar,2.38

 
    

 
## CSV Entity

In order to build CSV entities, we need something more. Csharp’s Attribute Mechanism provides us what we need by decorate CSV class properties with a custom attribute. Custom attribute defines CVS field’s display name and order. Here is the CsvFieldAttribute:

	public class CsvFieldAttribute:Attribute

	{

       public string Name { get; set; }

       public int Order { get; set; }

	}

With CsvFieldAttribute, now we can decorate our own class.

	[CsvObject(CodePage = 936, Description = "", HasHeader = true, Name = "")]
	public class Car

	{

       [SystemCsvColumn(Name = "Year", Order = 0)]

       public string Year { get; set; }

       [SystemCsvColumn(Name = "Make", Order = 1)]

       public string Make { get; set; }

       [SystemCsvColumn(Name = "Model", Order = 2)]

       public string Model { get; set; }

       [SystemCsvColumn(Name = "Length", Order = 3)]

       public string Length { get; set; }

	}

## Generate CSV Class

So, do we need to create CSV classes manually? Of cause not. So I developed the following tool to generate CSV classes:

To Generate CSV Classes, you have to install the VSIX file:

      
![VSIX file](https://github.com/juwikuang/csv2entity/raw/master/pics/vsix.png)
 

After the installation a new template called EZFX CSV Class will be displayed in your Visual Studio 2010 both in language VB and C#.

Add VB Class:

![CS](https://github.com/juwikuang/csv2entity/raw/master/pics/addvb.png)

Add C# Class:

![CS](https://github.com/juwikuang/csv2entity/raw/master/pics/addcs.png)

After click of add, a CSV Generation Wizard Window will be displayed, you can select a CSV file by click the browse button, this Wizard support Excel(xls, xlsx) and Access files(mdb, accdb), too. You specify the encoding for the CSV file and table name for Excel and Access file.

![CSV Generation Wizard](https://github.com/juwikuang/csv2entity/blob/master/pics/configform.jpg)

 

The following is the generated file:

The C# code:

```
using Ezfx.Csv;

namespace Cars.CS
{

    [CsvObject(CodePage = 936, Description = "", HasHeader = true, Name = "", MappingType = CsvMappingType.Title, Delimiter = ",")]
    public class CarCsv
    {

        /// <summary>
        /// 0, Year
        /// </summary>
        [SystemCsvColumn(Name = "Year", Ordinal = 0, Alias = "")]
        public string Year { get; set; }


        /// <summary>
        /// 1, Make
        /// </summary>
        [SystemCsvColumn(Name = "Make", Ordinal = 1, Alias = "")]
        public string Make { get; set; }


        /// <summary>
        /// 2, Model
        /// </summary>
        [SystemCsvColumn(Name = "Model", Ordinal = 2, Alias = "")]
        public string Model { get; set; }


        /// <summary>
        /// 3, Length
        /// </summary>
        [SystemCsvColumn(Name = "Length", Ordinal = 3, Alias = "")]
        public string Length { get; set; }


    }
}

```

The VB code:

```
Imports Ezfx.Csv

<CsvObject(CodePage:=936, Description:="", HasHeader:=True, MappingType:=Ezfx.Csv.CsvMappingType.Title, Name:="", Delimiter:=",")> _
Public Class CarCsv

    ''' <summary>
    ''' 0, Year
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=0, Name:="Year")> _
    Public Property Year() As String


    ''' <summary>
    ''' 1, Make
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=1, Name:="Make")> _
    Public Property Make() As String


    ''' <summary>
    ''' 2, Model
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=2, Name:="Model")> _
    Public Property Model() As String


    ''' <summary>
    ''' 3, Length
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=3, Name:="Length")> _
    Public Property Length() As String

End Class
```
 

## CSV Read

The following code reads a csv file and put data to Csv Objects.

```
CarCsv[] imdbs = CsvContext.ReadFile<ImdbCsv>("cars.csv");
```

You can also provide csv content as a string

```
CarCsv[] imdbs = CsvContext.ReadContext<CarCsv>("...");
```
 

## Document Generator

With Document Generator, you can get the schema of the CSV files or the Excel and Access files and save the result to a CSV file for further edit.

![](./pics/gen.png)

References

CSV in Wikipedia: http://en.wikipedia.org/wiki/Comma-separated_values

