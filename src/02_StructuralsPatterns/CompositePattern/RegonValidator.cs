namespace CompositePattern;

public class RegonValidator : ICustomerValidator
{
    public bool Validate(Customer customer)
    {
        return customer.Regon.Length == 9;
    }
}

