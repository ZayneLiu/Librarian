using Xunit;
namespace CustodianAPI.Test
{
    public class WordDocumentTest
    {
        [Fact]
        public void IndexTest()
        {
            var testDoc = new WordDocument("/Users/zayne/Workspace/Desktop/Librarian/CustodianAPI/Test Doc/EazyCyber.docx");
            System.Console.WriteLine(testDoc);
        }
    }
}
