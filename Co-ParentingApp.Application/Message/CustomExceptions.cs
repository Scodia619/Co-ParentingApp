namespace Co_ParentingApp.Application.Message;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}
