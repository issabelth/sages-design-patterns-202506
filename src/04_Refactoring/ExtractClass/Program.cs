
var person = new Person
{
    Name = "John",
    Email = "john@domain.com",
    Street = "5th Avenue",
    HouseNumber = "10A",
    City = "New York",
    PostCode = "39000"
};

if (person.FreeDelivery())
{
    Console.WriteLine("Free delivery");
}

class Person
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    // Shipping Address
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }

    public string GetFullAddress()
    {
        return $"{Street} {HouseNumber}, {PostCode} {City}, {Country}";
    }

    public bool FreeDelivery()
    {
        return int.Parse(PostCode) < 40000;
    }

}