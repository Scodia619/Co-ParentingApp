namespace Co_ParentingApp.Application.MatchedMembers;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}

public class PairKeyException : Exception
{
    public PairKeyException(string message) : base(message) { }
}

public class AlreadyMatchedException : Exception
{
    public AlreadyMatchedException(string message) : base(message) { }
}