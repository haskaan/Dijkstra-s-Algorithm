' This class return result.
Public Class ResultCost
    Public path As String   'Result path.
    Public cost As Integer  'Result cost.
End Class


Module Dijkstra

    Dim INF As Integer = 999    'Infinity value.
    Dim NODE As Integer         'The number of nodes.

    Sub Main()

        Console.WriteLine("DIJKSTRA METHOD")
        Console.WriteLine()
        Console.WriteLine()

        Console.Write("Enter the number of nodes: ")
        NODE = Convert.ToInt32(Console.ReadLine()) - 1          'The number of nodes.

        Dim cost(NODE, NODE), source, target, distance As Integer
        Dim resultCost As ResultCost


        Console.WriteLine("NODE LIST")
        ' Matrix assign infinity value. Matrix print screen.
        For i = 0 To NODE
            For j = 0 To NODE
                cost(i, j) = INF
            Next

            Console.Write((i + 1).ToString() + "." + Convert.ToChar(i + 65) + ", ")
        Next
        Console.WriteLine()
        Console.WriteLine()

        ' Matrix elements are assigned.
        For x = 0 To NODE
            For y = x + 1 To NODE
                Console.Write("Enter the weight of the path between nodes {0} and {1}: ", x + 1, y + 1)
                distance = Convert.ToInt32(Console.ReadLine())
                cost(x, y) = distance
                cost(y, x) = distance
            Next

            Console.WriteLine()
        Next


        Console.WriteLine()
        Console.Write("Enter the source: ")
        source = Convert.ToInt32(Console.ReadLine()) - 1
        Console.Write("Enter the target: ")
        target = Convert.ToInt32(Console.ReadLine()) - 1
        resultCost = Dijkstra(cost, source, target)
        Console.WriteLine()
        Console.WriteLine("The Shortest Path: {0}", resultCost.path)
        Console.WriteLine("The Shortest Cost: {0}", resultCost.cost)

        Console.ReadLine()

    End Sub


    ' Dijkstra method. The Shortest Path Algorithm.
    Public Function Dijkstra(cost(,) As Integer, source As Integer, target As Integer)

        Dim dist(NODE), prev(NODE), selected(NODE), m, min, start, d, j As Integer
        Dim path(NODE) As Char

        For index = 0 To NODE
            dist(index) = INF
            prev(index) = -1
        Next

        start = source
        selected(start) = 1
        dist(start) = 0

        While selected(target) = 0
            min = INF
            m = 0

            For index = 0 To NODE
                d = dist(start) + cost(start, index)

                If d < dist(index) And selected(index) = 0 Then
                    dist(index) = d
                    prev(index) = start
                End If
                If min > dist(index) And selected(index) = 0 Then
                    min = dist(index)
                    m = index
                End If
            Next

            start = m
            selected(start) = 1

        End While

        start = target
        j = 0

        While start <> -1
            path(j) = Convert.ToChar(start + 65)
            j += 1
            start = prev(start)
        End While

        path = StrReverse(path)


        Dim result As New ResultCost()
        result.path = path
        result.cost = dist(target)

        Return result

    End Function

End Module