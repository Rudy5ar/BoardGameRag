using System.Text;
using UglyToad.PdfPig;

namespace BoardGameRag;

public static class RulebookReader
{
    public static string ReadRules()
    {
        using var document = PdfDocument.Open("root rules.pdf");
        var textBuilder = new StringBuilder();
        
        foreach (var page in document.GetPages())
        {
            textBuilder.AppendLine(page.Text);
        } 
        return textBuilder.ToString();
    }
    
    public static List<string> ReadRulesAsChunks()
    {
        List<string> chunks = [];
        var chunkSize = 1000;
        var overlap = 200;
        
        var documentText = ReadRules();
        
        for (int i = 0; i < documentText.Length; i += chunkSize - overlap)  
        {
            var lengthToGrab = Math.Min(chunkSize, documentText.Length - i);
            chunks.Add(documentText.Substring(i, lengthToGrab));
        }
        
        return chunks;
    }
}