Imports Ezfx.Csv

<CsvObject(CodePage:=936, Description:="", HasHeader:=True, MappingType:=CsvMappingType.Order, Name:="")> _
Public Class LanguagePopularity
    ''' <summary>
    ''' 0, Position
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=0, Name:="Position")>
    Public Property Position() As String
    ''' <summary>
    ''' 1, ProgrammingLanguage
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=1, Name:="ProgrammingLanguage")>
    Public Property ProgrammingLanguage() As String
    ''' <summary>
    ''' 2, Ratings
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=2, Name:="Ratings")>
    Public Property Ratings() As String
    ''' <summary>
    ''' 3, Delta
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=3, Name:="Delta")>
    Public Property Delta() As String
    ''' <summary>
    ''' 4, Status
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=4, Name:="Status")>
    Public Property Status() As String

End Class
