Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Dim operators As String() = {"+", "-", "*", "/", "=", "==", "!=", "<", ">", "<=", ">=", "&&", "||", "!", "%"}
    Dim symbols As Char() = {"{", "}", "(", ")", "[", "]", ".", ",", "#"}
    Dim reservedSymbols As String() = {"::", "->", ">>", "<<"}

    Dim languageData As New Dictionary(Of String, Dictionary(Of String, HashSet(Of String))) From {
        {"CSharp", New Dictionary(Of String, HashSet(Of String)) From {
            {"Keyword", New HashSet(Of String) From {"if", "else", "for", "while", "return", "class", "static", "switch", "case", "break", "continue", "try", "catch", "finally"}},
            {"ReservedWord", New HashSet(Of String) From {"using", "Program", "System", "namespace", "async", "await", "void", "public", "private", "protected", "internal", "new", "this", "base"}}
        }},
        {"Python", New Dictionary(Of String, HashSet(Of String)) From {
            {"Keyword", New HashSet(Of String) From {"if", "else", "elif", "for", "while", "return", "def", "class", "try", "except", "finally", "with", "pass", "break", "continue"}},
            {"ReservedWord", New HashSet(Of String) From {"import", "Program", "System", "from", "as", "None", "True", "False", "self", "nonlocal", "global"}}
        }},
        {"Cpp", New Dictionary(Of String, HashSet(Of String)) From {
            {"Keyword", New HashSet(Of String) From {"if", "else", "for", "while", "return", "class", "switch", "case", "break", "continue", "try", "catch"}},
            {"ReservedWord", New HashSet(Of String) From {"namespace", "std", "void", "using", "Program", "System", "public", "private", "protected", "virtual", "template", "typename", "include"}}
        }}
    }

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        ' Add columns to DataGridViews
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("Lexeme", "Lexeme")
            DataGridView1.Columns.Add("Type", "Type")
        End If

        If DataGridView2.Columns.Count = 0 Then
            DataGridView2.Columns.Add("Line", "Line")
            DataGridView2.Columns.Add("Lexeme", "Lexeme")
            DataGridView2.Columns.Add("Type", "Type")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()

        Dim code = RichTextBox1.Text
        LexicalAnalysis(code)
    End Sub

    Private Sub LexicalAnalysis(code As String)
        Dim processedLexemes As New HashSet(Of String)()
        Dim language As String = DetermineLanguage(code)
        Dim langKeywords = languageData(language)("Keyword")
        Dim langReserved = languageData(language)("ReservedWord")

        Dim index As Integer = 0
        While index < code.Length
            Dim matched As Boolean = False
            Dim lineNumber As Integer = code.Substring(0, index).Count(Function(c) c = vbLf) + 1

            ' Check string
            Dim stringMatch = Regex.Match(code.Substring(index), "^(""[^""]*""|'[^']*')", RegexOptions.IgnoreCase)
            If stringMatch.Success Then
                AddToken(stringMatch.Value, "String", lineNumber, processedLexemes)
                index += stringMatch.Length
                Continue While
            End If

            ' Check number
            Dim numberMatch = Regex.Match(code.Substring(index), "^(0x[0-9A-Fa-f]+|\d+(\.\d+)?)", RegexOptions.IgnoreCase)
            If numberMatch.Success Then
                AddToken(numberMatch.Value, "Number", lineNumber, processedLexemes)
                index += numberMatch.Length
                Continue While
            End If

            ' Reserved symbols
            For Each sym In reservedSymbols
                If code.Substring(index).StartsWith(sym) Then
                    AddToken(sym, "ReservedSymbol", lineNumber, processedLexemes)
                    index += sym.Length
                    matched = True
                    Exit For
                End If
            Next
            If matched Then Continue While

            ' Operators
            For Each op In operators.OrderByDescending(Function(o) o.Length)
                If code.Substring(index).StartsWith(op) Then
                    AddToken(op, "Operators", lineNumber, processedLexemes)
                    index += op.Length
                    matched = True
                    Exit For
                End If
            Next
            If matched Then Continue While

            ' Colon
            If code(index) = ":"c Then
                AddToken(":", "Colon", lineNumber, processedLexemes)
                index += 1
                Continue While
            End If

            ' Semicolon
            If code(index) = ";"c Then
                AddToken(";", "Semicolon", lineNumber, processedLexemes)
                index += 1
                Continue While
            End If

            ' Symbols
            If symbols.Contains(code(index)) Then
                AddToken(code(index), "Symbol", lineNumber, processedLexemes)
                index += 1
                Continue While
            End If

            ' Identifiers, Keywords, Reserved
            Dim idMatch = Regex.Match(code.Substring(index), "^[a-zA-Z_][a-zA-Z0-9_]*")
            If idMatch.Success Then
                Dim lex = idMatch.Value
                Dim tokenType As String = If(langKeywords.Contains(lex), "Keyword",
                                         If(langReserved.Contains(lex), "ReservedWord", "Alpha"))
                AddToken(lex, tokenType, lineNumber, processedLexemes)
                index += idMatch.Length
                Continue While
            End If

            ' Skip unclassified characters
            index += 1
        End While
    End Sub

    Private Sub AddToken(lexeme As String, tokenType As String, lineNumber As Integer, processedLexemes As HashSet(Of String))
        DataGridView2.Rows.Add(lineNumber, lexeme, tokenType)
        If Not processedLexemes.Contains(lexeme) Then
            DataGridView1.Rows.Add(lexeme, tokenType)
            processedLexemes.Add(lexeme)
        End If
    End Sub

    Private Function DetermineLanguage(code As String) As String
        If code.Contains("using") AndAlso code.Contains("namespace") Then
            Return "CSharp"
        ElseIf code.Contains("def") OrElse code.Contains("import") Then
            Return "Python"
        ElseIf code.Contains("namespace") OrElse code.Contains("cout") OrElse code.Contains("cin") Then
            Return "Cpp"
        Else
            Return "CSharp"
        End If
    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Show buttons for file options
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadTextFile("DescendingOrder.txt")
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LoadTextFile("GuessNumber.txt")
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        LoadTextFile("UnitConverter.txt")
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub LoadTextFile(filename As String)
        Dim path As String = System.IO.Path.Combine(Application.StartupPath, filename)

        If System.IO.File.Exists(path) Then
            RichTextBox1.Text = System.IO.File.ReadAllText(path)
        Else
            MessageBox.Show("File not found: " & filename)
        End If
    End Sub

End Class
