namespace CompositePattern;

public class CustomerController
{
    private readonly ICustomerValidator validator;

    public CustomerController(ICustomerValidator validator)
    {
        this.validator = validator;
    }

    public ActionResult Post(Customer customer)
    {
        bool isValid = validator.Validate(customer);

        if (!isValid)
        {
            return new BadRequestObjectResult("Invalid customer data");
        }

        return new CreatedResult($"/customers/{customer.Id}", customer);
    }
}
