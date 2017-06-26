Imports Ezfx.Csv

<CsvObject(CodePage:=936, Description:="", HasHeader:=True, MappingType:=CsvMappingType.Order, Name:="")> _
Public Class LanguagePopularity


    Private _Position As String
    ''' <summary>
    ''' 0, Position
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=0, Name:="Position")> _
    Public Property Position() As String
        Get
            Return _Position
        End Get
        Set(ByVal value As String)
            _Position = value
        End Set
    End Property



    Private _ProgrammingLanguage As String
    ''' <summary>
    ''' 1, ProgrammingLanguage
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=1, Name:="ProgrammingLanguage")> _
    Public Property ProgrammingLanguage() As String
        Get
            Return _ProgrammingLanguage
        End Get
        Set(ByVal value As String)
            _ProgrammingLanguage = value
        End Set
    End Property



    Private _Ratings As String
    ''' <summary>
    ''' 2, Ratings
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=2, Name:="Ratings")> _
    Public Property Ratings() As String
        Get
            Return _Ratings
        End Get
        Set(ByVal value As String)
            _Ratings = value
        End Set
    End Property



    Private _Delta As String
    ''' <summary>
    ''' 3, Delta
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=3, Name:="Delta")> _
    Public Property Delta() As String
        Get
            Return _Delta
        End Get
        Set(ByVal value As String)
            _Delta = value
        End Set
    End Property



    Private _Status As String
    ''' <summary>
    ''' 4, Status
    ''' </summary>
    <SystemCsvColumn(Alias:="", Ordinal:=4, Name:="Status")> _
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property




End Class
