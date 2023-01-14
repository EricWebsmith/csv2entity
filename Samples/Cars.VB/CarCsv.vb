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
