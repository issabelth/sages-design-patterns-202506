// Zasada pojedynczej odpowiedzialności (Single-Responsibility Principle) - SRP

// Każda klasa powinna być odpowiedzialna za jedną konkretną rzecz.
// Klasa powinna mieć tylko jeden powód do zmiany.

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address WorkAddress { get; set; }
    public Address HomeAddress { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {WorkAddress?.ToString()} {HomeAddress?.ToString()}";
    }

    public string Email { get; set; }
  
   
}

interface IValidator
{
    void Validate(string value);
}

class EmailValidator : IValidator
{
    public void Validate(string email)
    {
        if (!email.Contains("@") || !email.Contains("."))
        {
            throw new FormatException("Email address is a invalid format!");
        }
    }
}

class PostcodeValidator : IValidator
{
    public void Validate(string postcode)
    {
        if (postcode.Length != 5)
        {
            throw new FormatException("Post code is a invalid format!");
        }
    }
}

class Address
{
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }

    public override string ToString()
    {
        return $"{City} {Street} {PostCode}";
    }
}


// Przykład #2 łamiący zasadę pojedynczej odpowiedzialności

public class Student
{
    public string Name { get; set; }
    public string Email { get; set; }

    public void Register()
    {
        // Register a student
        // Perform validation and save to DB
        Console.WriteLine("Registering the student");
    }

    public void EnrollInCourse()
    {
        // Enroll the student in a course
        // Perform validation and save to DB
        Console.WriteLine("Enrolling to the course");
    }
}

// Przykład #3
public class User
{
    public string Username { get; set; }
    public string HashedPassword { get; set; }
}
public class Authentication
{
    //Register a user
    public void RegisterUser(User user)
    {
    }

    // Perform user login
    public void Login(string username, string password)
    {
    }

    // User logout
    public void Logout()
    {
    }
}