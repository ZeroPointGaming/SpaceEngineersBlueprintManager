Public Class XMLCleaner
    Public Function CleanXML(inputfile As String)
        Dim originalxml As String = inputfile
        Dim outputxml As String = Nothing

        'only keep requested xml lines and remove xsi:type from <definition> element
        For Each line In originalxml.Split(vbNewLine)
            If line.ToString().Contains("<?xml") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<Definitions xmlns:xsi") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<CubeBlocks>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<Definition xsi:type") Then
                outputxml += "<Definition>" + vbNewLine
            ElseIf line.ToString().Contains("<Definition>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<Id>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("</Id>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<TypeId>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<SubtypeId>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<DisplayName>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<Icon>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<CubeSize>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<BlockPairName>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<BuildTimeSeconds>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<Components>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("<Component Subtype") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("</Components>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("</Definition>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("</CubeBlocks>") Then
                outputxml += line.ToString() + vbNewLine
            ElseIf line.ToString().Contains("</Definitions>") Then
                outputxml += line.ToString() + vbNewLine
            End If
        Next

        Return outputxml
    End Function
End Class
