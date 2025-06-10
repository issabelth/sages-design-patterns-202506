namespace SimpleFactoryPattern
{
    // Fabric
    public class VisitFactory
    {
        // Product
        public Visit Create(string kind, TimeSpan duration, decimal pricePerHour) => kind switch
        {
            "N" => new NfzVisit(duration),
            "P" => new PrivateVisit(duration, pricePerHour),
            "F" => new PacketVisit(duration, pricePerHour),
            "T" => new TeleVisit(duration, pricePerHour),
            _ => throw new NotSupportedException(),
        };
    }

    public class NfzVisit : Visit
    {
        public NfzVisit(TimeSpan duration) : base(duration) { }
        public override decimal CalculateCost() => 0;
    }

    public class PrivateVisit : PayVisit
    {
        public PrivateVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour) { }
    }

    public class PacketVisit : PayVisit
    {
        private const decimal companyDiscountPercentage = 0.9m;

        public PacketVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour) { }
        public override decimal CalculateCost() => base.CalculateCost() * companyDiscountPercentage;
    }

    // Abstract
    public abstract class Visit
    {
        public DateTime VisitDate { get; set; }
        public TimeSpan Duration { get; set; }
      

        public Visit(TimeSpan duration)
        {
            VisitDate = DateTime.Now;
            Duration = duration;
        }

        public abstract decimal CalculateCost();
       
    }

    public abstract class PayVisit : Visit
    {
        private readonly decimal pricePerHour;

        protected PayVisit(TimeSpan duration, decimal pricePerHour) : base(duration)
        {
            this.pricePerHour = pricePerHour;
        }

        public override decimal CalculateCost() => (decimal)Duration.TotalHours * pricePerHour;
    }

    public class TeleVisit : PayVisit
    {
        public TeleVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour) { }

        public override decimal CalculateCost() => 50m;
    }
}
