Module BingoGame

    Sub Main()
        DisplayBoard()
        For i = 0 To 10
            DrawBall()
            DisplayBoard()
            Console.Read()
            Console.Clear()
        Next
    End Sub

    Sub DrawBall()
        Dim temp(,) As Boolean = BingoTracker(0, 0)
        Dim currentBallNumber As Integer
        Dim currentBallletter As Integer
        Do
            currentBallNumber = RandomNumberBetween(0, 14) 'get row
            currentBallletter = RandomNumberBetween(0, 4) 'get column 
        Loop Until temp(currentBallNumber, currentBallletter) = False
        'mark current ball as being drawn, updates the display
        BingoTracker(currentBallNumber, currentBallletter)
        Console.WriteLine($"The current row is {currentBallNumber} and column is {currentBallletter}")
        Return
    End Sub

    Function BingoTracker(ballNumber As Integer, ballLetter As Integer, Optional clear As Boolean = True)
        Static _bingoTracker(14, 4) As Boolean
        'start code here
        _bingoTracker(ballNumber, ballLetter) = True
        Return _bingoTracker
    End Function

    Sub DisplayBoard()
        Dim temp As String = "x |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}
        Dim tracker(,) As Boolean = BingoTracker(0, 0)

        For Each letter In heading
            Console.Write(letter.PadLeft(2).PadRight(4))
        Next

        Console.WriteLine()
        Console.WriteLine(StrDup(20, "_"))

        For currentNumber = 1 To 14

            For CurrentLetter = 1 To 4
                If tracker(currentNumber, CurrentLetter) Then
                    temp = "X |"
                Else
                    temp = " |"
                End If
                temp = temp.PadLeft(4)
                Console.Write(temp)
            Next
            Console.WriteLine()
        Next
    End Sub

    Function RandomNumberBetween(Min As Integer, Max As Integer) As Integer
        Dim temp As Single
        Randomize()
        temp = Rnd()
        temp *= Max + Min
        temp += Min
        Return temp
    End Function

End Module
