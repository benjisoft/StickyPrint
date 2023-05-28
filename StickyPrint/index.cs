using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace StickyPrint
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        public static void CreateEmptyFile(string filename)
        {
            File.Create(filename).Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string docName = "printString.txt";
            string fullPath = System.IO.Path.Combine(docName);
            if (!File.Exists(fullPath))
            {
                CreateEmptyFile(fullPath);
            }

            printDocument1.DocumentName = docName;

            var stringToPrint = System.IO.File.ReadAllText(fullPath);

            printDocument1.Print();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var stringToPrint = richTextBox1.Text;
            int charactersOnPage = 0;
            int linesPerPage = 0;
            Margins margins = new Margins(100, 100, 100, 100);
            printDocument1.DefaultPageSettings.Margins = margins;

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.PageBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

        }
    }
}