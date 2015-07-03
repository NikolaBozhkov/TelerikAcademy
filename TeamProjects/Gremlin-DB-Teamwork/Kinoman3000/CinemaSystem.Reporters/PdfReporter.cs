namespace CinemaSystem.Reporters
{
    using System;
    using System.IO;

    using iTextSharp;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using CinemaSystem.Data;
    using CinemaSystem.Models;
    
    public class PdfReporter : IReporter
    {
        public void Report(ICinemaSystemData data, string reportFileLocation)
        {
            throw new NotImplementedException();
        }

        public void GenerateTicketPdf(Ticket ticket, string reportFileLocation)
        {
            const int Height = 150;
            const int Width = 400;
            const int TitleFontSize = 16;
            const int NormalFontSize = 14;

            var pageSize = new Rectangle(Width, Height);
            var popCornImage = Image.GetInstance("http://www.clipartlord.com/wp-content/uploads/2013/06/popcorn3.png");

            var warmOrange = new BaseColor(241, 128, 63);
            pageSize.BackgroundColor = warmOrange;

            popCornImage.ScaleToFit(pageSize);
            popCornImage.Alignment = Image.UNDERLYING;
            popCornImage.SetAbsolutePosition(Width - 130, 0);

            var document = new Document(pageSize, 15, 15, 0, 0);

            try
            {
                // create writer with stream directed to the file
                PdfWriter.GetInstance(document, new FileStream(reportFileLocation, FileMode.Create));

                document.Open();
                document.Add(popCornImage);

                var titleFont = new Font(Font.FontFamily.TIMES_ROMAN, TitleFontSize, 1, BaseColor.BLACK);
                var normalFont = new Font(Font.FontFamily.TIMES_ROMAN, NormalFontSize, 2, BaseColor.DARK_GRAY);

                var title = new Paragraph("MOVIE TICKET", titleFont);
                title.Alignment = Element.ALIGN_CENTER;

                document.Add(title);

                var movieTitle = new Paragraph(string.Format("Movie Title: {0}", ticket.Screening.Movie.Title), normalFont);
                var screeningHall = new Paragraph(string.Format("Screen Hall: {0}", ticket.Screening.CinemaHall.Name), normalFont);
                var seat = new Paragraph(string.Format("Seat number: {0}", ticket.SeatNumber), normalFont);
                var price = new Paragraph(string.Format("Ticket Price: {0}", ticket.Price), normalFont);

                movieTitle.Leading = 40;
                price.Alignment = Element.ALIGN_BOTTOM;

                document.Add(movieTitle);
                document.Add(screeningHall);
                document.Add(seat);
                document.Add(price);
            }
            catch (DocumentException de)
            {
                throw new InvalidOperationException("There was an internal operation error", de);
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            finally
            {
                document.Close();
            }
        }
    }
}
