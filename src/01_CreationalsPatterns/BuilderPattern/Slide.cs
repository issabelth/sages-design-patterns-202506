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

    // Abstract Builder
    public interface IPresentationBuilder
    {
        void AddSlide(Slide slide);         
    }

    // Concrete Builder A
    public class PdfPresentationBuilder : IPresentationBuilder
    {
        // Utwórz dokument
        PdfDocument pdf = new PdfDocument();

        public void AddSlide(Slide slide)
        {
            pdf.AddPage(slide.Text);
        }

        public PdfDocument Build()
        {
            return pdf;
        }
    }

    public class MoviePresentationBuilder : IPresentationBuilder
    {
        // Utwórz dokument
        Movie movie = new Movie();

        public void AddSlide(Slide slide)
        {
            movie.AddFrame(slide.Text, 3);
        }

        public Movie Build()
        {
            return movie;
        }
    }


    // Nadzorca
    public class PresentationDirector
    {
        private readonly IPresentationBuilder builder;

        public PresentationDirector(IPresentationBuilder builder)
        {
            this.builder = builder;
        }

        public void Build(Presentation presentation)
        {
            // Dodaj slajd (nagłówek)
            builder.AddSlide(new Slide("Copyright"));

            foreach (Slide slide in presentation.slides)
            {
                builder.AddSlide(slide);
            }
        }

    }

    public class Presentation
    {
        public List<Slide> slides = new List<Slide>();

        public void AddSlide(Slide slide)
        {
            slides.Add(slide);
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
