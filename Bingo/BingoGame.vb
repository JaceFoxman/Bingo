Option Compare Text
Module BingoGame

    Sub Main()
        Dim userInput As String
        Do
            Console.Clear()
            DisplayBoard()
            Console.WriteLine("")
            'prompt
            userInput = Console.ReadLine()
            Select Case userInput
                Case "d"
                    DrawBall()
                Case "c"
                    BingoTracker(0, 0,, True)
                Case Else
                    'pass
            End Select

        Loop Until userInput = "q"
        Console.Clear()
        Console.WriteLine("Have a nice day!")
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
        BingoTracker(currentBallNumber, currentBallletter, True)
        Console.WriteLine($"The current row is {currentBallNumber} and column is {currentBallletter}")
        Return
    End Sub
    ''' <summary>
    ''' contains a presistant array that tracks all possible bingo balls and whether they have been drawn during the current game.
    ''' </summary>
    ''' <param name="ballNumber"></param>
    ''' <param name="ballLetter"></param>
    ''' <param name="clear"></param>
    ''' <returns>Current Tracking Array</returns>
    Function BingoTracker(ballNumber As Integer, ballLetter As Integer, Optional update As Boolean = False, Optional clear As Boolean = False)
        Static _bingoTracker(14, 4) As Boolean
        If update Then
            _bingoTracker(ballNumber, ballLetter) = True
        End If

        If clear Then
            'clear the array
            ReDim _bingoTracker(14, 4) 'clears the array.
        End If

        Return _bingoTracker
    End Function
    ''' <summary>
    ''' Iterates through the tracker array
    ''' </summary>
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