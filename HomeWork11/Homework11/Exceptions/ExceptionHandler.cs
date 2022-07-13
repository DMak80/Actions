using System.Diagnostics.CodeAnalysis;

namespace Homework11.Exceptions;

public class ExceptionHandler : IExceptionHandler
{
	private readonly ILogger<ExceptionHandler> _logger;

	public ExceptionHandler(ILogger<ExceptionHandler> logger)
	{
		_logger = logger;
	}

	public void HandleException<T>(T exception) where T : Exception
	{
		this.Handle((dynamic) exception);
	}
	
	[ExcludeFromCodeCoverage]
	private void Handle(Exception exception)
	{
		_logger.LogError($"Unknown error: {exception.Message}");
	}

	private void Handle(InvalidNumberException exception)
	{
		_logger.LogError($"Invalid number: {exception.Message}");
	}

	private void Handle(InvalidSyntaxException exception)
	{
		_logger.LogError($"Invalid syntax: {exception.Message}");
	}

	private void Handle(InvalidSymbolException exception)
	{
		_logger.LogError($"Invalid symbol: {exception.Message}");
	}
	
	private void Handle(DivideByZeroException exception)
	{
		_logger.LogError(exception.Message);
	}
}