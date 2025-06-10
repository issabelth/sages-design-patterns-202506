namespace CompositePattern;

public interface ActionResult { }

public class CreatedResult : ActionResult
{
    public CreatedResult(string? location, object? value) { }
}

public class BadRequestObjectResult : ActionResult
{
    public BadRequestObjectResult(object? error) { }
}