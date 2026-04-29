using System.Text;
using UglyToad.PdfPig;

namespace BoardGameRag;

public class RulebookReader
{
    public static string ReadRules()
    {
        var rulesDocument = PdfDocument.Open("../../../root rules.pdf");

        var textBuilder = new StringBuilder();
        
        foreach (var page in rulesDocument.GetPages())
        {
            textBuilder.AppendLine(page.Text);
        } 
        return textBuilder.ToString();
    }
}