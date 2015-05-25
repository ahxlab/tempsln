Module Module1

    Sub Main()

        'ディクショナリー作成
        Dim dicData As New Dictionary(Of Integer, DataClass)

        'For i As Integer = 0 To 10
        '    Dim data As New DataClass

        '    With data
        '        .member1 = "One" & i
        '        .member2 = "Two" & i
        '    End With

        '    dicData(i) = data
        'Next

        'タイマー作成/開始
        Dim tc As New TimerClass(dicData)

        'ディクショナリーアクセス
        ReadDictionary(dicData)

    End Sub




    ''' <summary>
    ''' ディクショナリーアクセス
    ''' </summary>
    ''' <param name="dicData"></param>
    ''' <remarks></remarks>
    Private Sub ReadDictionary(dicData As Dictionary(Of Integer, DataClass))
        Dim st As Integer = 0
        Dim ed As Integer = 1000

        While True
            For i As Integer = st To ed
                Dim data As New DataClass(i)
                'dicData(i) = data
            Next
        End While

    End Sub

End Module


''' <summary>
''' タイマークラス
''' </summary>
''' <remarks></remarks>
Class TimerClass

    Public Property DicData As New Dictionary(Of Integer, DataClass)

    Private WithEvents tm As Timers.Timer

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="dicData"></param>
    ''' <remarks></remarks>
    Public Sub New(dicData As Dictionary(Of Integer, DataClass))
        Me.DicData = dicData

        tm = New Timers.Timer(5)
        tm.AutoReset = False
        tm.Start()
    End Sub

    ''' <summary>
    ''' ディクショナリーアクセス
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dicAccess1() Handles tm.Elapsed
        Dim st As Integer = 0
        Dim ed As Integer = 100

        For i As Integer = st To ed
            'Dim data As New DataClass(i)
            'DicData(i) = data
            'DicData.Remove(i)

            Dim d As New DataClass(1)

            Console.WriteLine(DateTime.Now.ToString("# hh:mm:ss.fff"))

            If DicData.ContainsKey(1) Then
                Dim a As Integer = 0
            End If
        Next

        tm.Start()
    End Sub

    ''' ディクショナリーアクセス
    Private Sub dicAccess2() Handles tm.Elapsed
        Dim st As Integer = 0
        Dim ed As Integer = 100

        For i As Integer = st To ed
            'Dim data As New DataClass(i)
            'DicData(i) = data
            'DicData.Remove(i)

            Dim d As New DataClass(1)

            Console.WriteLine(DateTime.Now.ToString("+ hh:mm:ss.fff"))

            If DicData.ContainsKey(1) Then
                Dim a As Integer = 0
            End If
        Next

        'tm.Start()
    End Sub



End Class



Class DataClass
    Public Property member1 As String
    Public Property member2 As String

    Public Sub New(i As Integer)
        Me.member1 = "One" & i
        Me.member2 = "Two" & i
    End Sub

End Class


