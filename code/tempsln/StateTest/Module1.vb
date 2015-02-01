Module Module1

    ' IContextインターフェイスです。
    Public Interface IContext

        ' 状態を変化させます。
        Sub ChageState(ByVal state As IState)

        Sub Beep()

        Sub Red()
        Sub Orange()
        Sub Green()

    End Interface

    ' IStateインターフェイスです。
    Public Interface IState

        ' Red
        Sub DoRedCondition(ByVal context As IContext)

        ' Orange
        Sub DoOrangeCondition(ByVal context As IContext)

        ' Green
        Sub DoGreenCondition(ByVal context As IContext)

    End Interface


    Public Class RedState : Implements IState
        Private Shared _singleton As RedState = New RedState()

        Private Sub New()
        End Sub

        Public Shared Function GetInstance() As IState
            Return _singleton
        End Function

        Public Sub DoGreenCondition(context As IContext) Implements IState.DoGreenCondition
            context.ChageState(GreenState.GetInstance())
        End Sub

        Public Sub DoOrangeCondition(context As IContext) Implements IState.DoOrangeCondition
            context.ChageState(OrangeState.GetInstance())
        End Sub

        Public Sub DoRedCondition(context As IContext) Implements IState.DoRedCondition
            context.ChageState(RedState.GetInstance())
        End Sub
    End Class


    Public Class OrangeState : Implements IState
        Private Shared _singleton As OrangeState = New OrangeState()

        Private Sub New()
        End Sub

        Public Shared Function GetInstance() As IState
            Return _singleton
        End Function

        Public Sub DoGreenCondition(context As IContext) Implements IState.DoGreenCondition
            context.ChageState(GreenState.GetInstance())
        End Sub

        Public Sub DoOrangeCondition(context As IContext) Implements IState.DoOrangeCondition
            context.ChageState(OrangeState.GetInstance())
        End Sub

        Public Sub DoRedCondition(context As IContext) Implements IState.DoRedCondition
            context.Beep()
            context.ChageState(RedState.GetInstance())
        End Sub
    End Class

    Public Class GreenState : Implements IState
        Private Shared _singleton As GreenState = New GreenState()

        Private Sub New()
        End Sub

        Public Shared Function GetInstance() As IState
            Return _singleton
        End Function

        Public Sub DoGreenCondition(context As IContext) Implements IState.DoGreenCondition
            context.ChageState(GreenState.GetInstance())
        End Sub

        Public Sub DoOrangeCondition(context As IContext) Implements IState.DoOrangeCondition
            context.ChageState(OrangeState.GetInstance())
        End Sub

        Public Sub DoRedCondition(context As IContext) Implements IState.DoRedCondition
            context.Beep()
            context.ChageState(RedState.GetInstance())
        End Sub
    End Class


    Public Class TestContext : Implements IContext

        Private Shared _state As IState = GreenState.GetInstance()
        Public Sub ChageState(state As IState) Implements IContext.ChageState
        End Sub

        Public Sub Beep() Implements IContext.Beep
            Console.WriteLine("Beep!")
        End Sub
        Public Sub Red() Implements IContext.Red
            _state.DoRedCondition(Me)
        End Sub
        Public Sub Orange() Implements IContext.Orange
            _state.DoOrangeCondition(Me)
        End Sub
        Public Sub Green() Implements IContext.Green
            _state.DoGreenCondition(Me)
        End Sub

    End Class

    Sub Main()

        Dim context As TestContext = New TestContext()

        context.Green()
        context.Red()
        context.Orange()
        context.Red()
        context.Green()

    End Sub

End Module
