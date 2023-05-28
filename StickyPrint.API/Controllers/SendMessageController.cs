using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StickyPrint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var docPath = Path.Combine("tempDoc.txt");
            using (StreamWriter outputFile = new StreamWriter(docPath))
            {
                outputFile.WriteLine(value);
            }

            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "notepad";
            p.StartInfo.Arguments = $"/p {docPath}";
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.Dispose();
            Console.WriteLine("FINISHED");
            //PrintDocument p1 = new PrintDocument();
            //p.PrintPage += new PrintPageEventHandler(this.Page_Print);
            //p1.Print();
        }

        //protected void Page_Print(object sender, PrintPageEventArgs ev)
        //{
        //    Brush b = new SolidBrush(Color.Black);
        //    Font printFont = new Font("Lucida Sans Typewriter", 10);
        //    ev.Graphics.DrawString("Hello World", printFont, b, x, y, StringFormat.GenericDefault);
        //}
    }
}
