using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Slide
    {
        public string Text { get; }

        public Slide(string text)
        {
            Text = text;
        }
    }

    public class Presentation
    {
        private List<Slide> slides = new List<Slide>();

        public void AddSlide(Slide slide)
        {
            slides.Add(slide);
        }

        public void Export(PresentationFormat format)
        {
            if (format == PresentationFormat.PDF)
            {
                var pdf = new PdfDocument();
                pdf.AddPage("Copyright");
                foreach(Slide slide in slides)
                {
                    pdf.AddPage(slide.Text);
                }                
            }
            else if (format == PresentationFormat.Movie)
            {
                var movie = new Movie();
                movie.AddFrame("Copyright", 3);
                foreach (Slide slide in slides)
                {
                    movie.AddFrame(slide.Text, 3);
                }
            }
        }
    }

    public enum PresentationFormat
    {
        PDF,
        Image,
        PowerPoint,
        Movie
    }

    public class PdfDocument
    {
        public void AddPage(string text)
        {
            Console.WriteLine($"Add a page to PDF");
        }
    }

    public class Movie
    {
        public void AddFrame(string text, int duration)
        {
            Console.WriteLine($"Add a frame to the movie");
        }
    }
}
