using CustodianAPI.DocumentParser;
using Xunit;
using System.Reflection;
namespace CustodianAPI.Test
{
    public class WordDocumentTest
    {
        [Fact]
        public void IndexTest()
        {
            // var testOdt = new WordDocument("/Users/zayne/Workspace/Desktop/Librarian/CustodianAPI/Test Doc/test.odt");
            // Word 2007 (.docx, .docm)
            var testDocx = new Word07Document("/Users/zayne/Workspace/Desktop/Librarian/CustodianAPI/Test Doc/EazyCyber.docx");
            // Word 1997 (.doc)
            // var testDoc = new Word97Document("/Users/zayne/Workspace/Desktop/Librarian/CustodianAPI/Test Doc/test.doc");

            // Assert.Equal(3, testOdt.Thumbnail["add"]);
            // Assert.Equal(3, testDoc.Thumbnail["add"]);
        }
    }
}
