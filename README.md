# CSV2Entity


[![ericfeed MyGet Build Status](https://www.myget.org/BuildSource/Badge/ericfeed?identifier=f8245f2f-8154-494a-be4e-de175e194be5)](https://www.myget.org/)
[![Build status](https://ci.appveyor.com/api/projects/status/637a70iwpkcusjab?svg=true)](https://ci.appveyor.com/project/juwikuang/csv2entity)
[![Build Status](https://dev.azure.com/juwikuang/CSV2Entity/_apis/build/status/juwikuang.csv2entity?branchName=master)](https://dev.azure.com/juwikuang/CSV2Entity/_build/latest?definitionId=1?branchName=master)

## Install

### Install Core from Nuget

* [CSV2Entity](https://www.nuget.org/packages/Ezfx.Csv) [![Nuget](http://img.shields.io/nuget/v/Ezfx.Csv.svg?maxAge=10800)](https://www.nuget.org/packages/Ezfx.Csv/)

### Instial Visual Studio Extension from marketplace

https://marketplace.visualstudio.com/items?itemName=EricZhou.csv2entity

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

	public class Car

	{

       [CsvField(Name = "Year", Order = 0)]

       public string Year { get; set; }

       [CsvField(Name = "Make", Order = 1)]

       public string Make { get; set; }

       [CsvField(Name = "Model", Order = 2)]

       public string Model { get; set; }

       [CsvField(Name = "Length", Order = 3)]

       public string Length { get; set; }

	}

## Generate CSV Class

So, do we need to create CSV classes manually? Of cause not. So I developed the following tool to generate CSV classes:

To Generate CSV Classes, you have to install the VSIX file:

      
![VSIX file](https://github.com/juwikuang/csv2entity/raw/master/pics/vsix.png)
 

After the installation a new template called EZFX CSV Class will be displayed in your Visual Studio 2010 both in language VB and C#.

Add VB Class:

![VB](https://github.com/juwikuang/csv2entity/raw/master/pics/addvb.png)

Add C# Class:

![CS](https://github.com/juwikuang/csv2entity/raw/master/pics/addcs.png)

After click of add, a CSV Generate Wizard Window will be displayed, you can select a CSV file by click the browse button, this Wizard support Excel(xls, xlsx) and Access files(mdb, accdb), too. You specify the encoding for the CSV file and table name for Excel and Access file.

 

The following is the generated file:

The C# file:

![CS](https://github.com/juwikuang/csv2entity/raw/master/pics/csclass.png)

The VB file:

![VB](https://github.com/juwikuang/csv2entity/raw/master/pics/vbclass.png)

This is a .Net 3.5 Version of VB file. For the 4.0 Version, the get and set body can be omitted. I will add this feature in the coming version.

 

 

## CSV Read

The following code reads a csv file and put data to Csv Objects.

```
ImdbCsv[] imdbs = CsvContext.ReadFile<ImdbCsv>("imdb.csv");
```

You can also provide csv content as a string

```
ImdbCsv[] imdbs = CsvContext.ReadContext<ImdbCsv>("...");
```
 

## Document Generator

With Document Generator, you can get the schema of the CSV files or the Excel and Access files and save the result to a CSV file for further edit.

![](./pics/gen.png)

References

CSV in Wikipedia: http://en.wikipedia.org/wiki/Comma-separated_values

