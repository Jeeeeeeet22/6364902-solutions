using System;

class Program
{
    static void Main()
    {
        DocumentFactory factory;

        factory = new WordFactory();
        IDocument wordDoc = factory.CreateDocument();
        wordDoc.Open();

        factory = new PdfFactory();
        IDocument pdfDoc = factory.CreateDocument();
        pdfDoc.Open();

        factory = new ExcelFactory();
        IDocument excelDoc = factory.CreateDocument();
        excelDoc.Open();
    }
}
