using PrinterApp.Enums;
using System.Drawing.Printing;
//Codigo Escrito por Daniel25A ( Oscar Gomez)  Ingeniero de Software
namespace PrinterApp.Services
{
    public class PrintService
    {
        public static PrintService getInstance= new ();
        int pointerX = 0xF001;
        int pointerY = 0xF002;
        public Task<PrintResult> PrintRaw(
            string content,int quantity)
        {
            try
            {
              using  PrintDocument printer = new();
                printer.PrintPage += delegate (object sender, PrintPageEventArgs e)
                {
                    e?.Graphics?.DrawString(content, new Font("Times New Roman", 12), 
                        new SolidBrush(Color.Black), new RectangleF(0, 0, printer.DefaultPageSettings.PrintableArea.Width,
                        printer.DefaultPageSettings.PrintableArea.Height));

                };
                try
                {
                    printer.Print();
                    return Task.FromResult(PrintResult.Success);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrio un Error !", ex);
                }
            }
            catch (Exception)
            {
               return Task.FromResult(PrintResult.Error);
            }
        }

    }
}
