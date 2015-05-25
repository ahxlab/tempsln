Module Module1

    Sub Main()

        'LinqSelect()

        select_new_noname()

        Console.ReadKey()
    End Sub


    Sub LinqSelect()

        'データソースの作成
        Dim animals = New String() {"アメンボ", "イノシシ", "ウマ", "エリマキトカゲ", "オオカミ"}

        'LINQで処理を定義
        Dim results = From name In animals Select name, name.Length

        '結果セットを取得して表示
        For Each animal In results
            Console.WriteLine(animal.name)
            Console.WriteLine(animal.Length)
        Next
    End Sub


    Function f1(ByVal n As Integer)
        Return n * n * n
    End Function

    Sub select_new_noname()
        ' Ordersオブジェクトの配列
        Dim oders() As Order = New Order() {New Order(1000, 1, DateTime.Now, "Norway"), New Order(1001, 3, DateTime.Now, "Germany"), New Order(1002, 7, DateTime.Now, "Norway"), New Order(1003, 7, DateTime.Now, "Poland")}


        Dim query1 = From n In oders Where n.ShipCounTry = "Norway" Select New With {.OrderID = n.OrderID, .EmployeeID = n.EmployeeID}


        For Each item In query1
            Console.WriteLine(item.EmployeeID)
        Next

        Dim query2 = oders.Where(Function(c) c.ShipCounTry = "Norway").Select(Function(n) n.EmployeeID * 100)
        For Each item2 In query2
            Console.WriteLine(item2)
        Next

        Dim query3 = oders.Where(Function(c) c.ShipCounTry = "Norway").Select(Function(c) f1(c.EmployeeID))
        For Each item3 In query3
            Console.WriteLine(item3)
        Next


        Dim query31 = oders.Where(Function(c) c.ShipCounTry = "Norway").Select(Function(c)
                                                                                   Return c.EmployeeID + c.OrderID + 20000
                                                                               End Function)
        For Each item31 In query31
            Console.WriteLine(item31)
        Next

    End Sub





    Public Class Order
        Public OrderID As Integer
        Public EmployeeID As Integer
        Public OrderDate As DateTime
        Public ShipCounTry As String

        Public Sub New(ByVal id As Integer, ByVal emp As Integer, ByVal date1 As DateTime, ByVal ship As String)
            Me.OrderID = id
            Me.EmployeeID = emp
            Me.OrderDate = date1
            Me.ShipCounTry = ship
        End Sub
    End Class


    Public Sub DataTableLinqSelectTest()

        'テスト用テーブル作成
        Dim dt As New DataTable("TestTable")
        With dt.Columns
            .Add("Code")
            .Add("Name")
            .Add("Type")
            .Add("Value", Type.GetType("System.Int32"))
        End With

        Dim nr As DataRow

        nr = dt.NewRow
        nr("Code") = "001"
        nr("Name") = "株式会社テスト工業"
        nr("Type") = "製造"
        nr("Value") = 100000
        dt.Rows.Add(nr)

        nr = dt.NewRow
        nr("Code") = "002"
        nr("Name") = "株式会社テストマテリアルズ"
        nr("Type") = "製造"
        nr("Value") = 200000
        dt.Rows.Add(nr)

        nr = dt.NewRow
        nr("Code") = "003"
        nr("Name") = "株式会社テストシステム"
        nr("Type") = "ソフトウェア"
        nr("Value") = 150000
        dt.Rows.Add(nr)

        nr = dt.NewRow
        nr("Code") = "004"
        nr("Name") = "株式会社テストストア"
        nr("Type") = "小売"
        nr("Value") = 150000
        dt.Rows.Add(nr)

        nr = dt.NewRow
        nr("Code") = "005"
        nr("Name") = "株式会社手須戸インダストリー"
        nr("Type") = "製造"
        nr("Value") = 250000
        dt.Rows.Add(nr)

        'Typeが「製造」を含むデータを取得
        Dim query = From el In dt.AsEnumerable
                    Where el("Type") = "製造"
                    Select el

        'Typeが「製造」を含むデータを取得
        Dim q = dt.AsEnumerable().Where(Function(e1)
                                            Return e1("Type") = "製造"
                                        End Function).OrderByDescending(Function(e1) e1("Code")).Select(Function(e1) e1)

        For Each r As DataRow In q
            Console.WriteLine(r("Code") & ": " & r("Name"))
        Next


        'データの書き出し
        Console.WriteLine("")
        For Each r As DataRow In query
            Console.WriteLine(r("Code") & ": " & r("Name"))
        Next

        'Valueの合計を取得
        Dim valuesum = query.Sum(Function(el) el("Value"))
        Console.WriteLine("Sum: " & valuesum)

    End Sub

End Module
