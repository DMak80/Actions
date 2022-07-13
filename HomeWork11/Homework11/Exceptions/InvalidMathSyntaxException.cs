namespace Homework11.Exceptions;

public class InvalidSyntaxException : Exception
{
	public InvalidSyntaxException(string message)
		: base(message)
	{
	}
}