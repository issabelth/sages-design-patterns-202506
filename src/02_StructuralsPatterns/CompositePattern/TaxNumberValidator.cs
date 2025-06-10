namespace CompositePattern;

public class TaxNumberValidator : ICustomerValidator
{
    public bool Validate(Customer customer)
    {
        return customer.TaxNumber.Length == 11;
    }
}

