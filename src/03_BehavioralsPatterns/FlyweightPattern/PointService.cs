public class PointService
{
    private readonly IEnumerable<Point> points;

    public PointService()
    {
        points = new List<Point>
         {
            new Point(10, 20, PointType.Cafe, File.ReadAllBytes("cafe.png")),
            new Point(20, 40, PointType.Cafe, File.ReadAllBytes("cafe.png")),
            new Point(25, 35, PointType.Hotel, File.ReadAllBytes("hotel.png")),
         };
    }

    public IEnumerable<Point> GetAll()
    {
        return points;
    }
}

