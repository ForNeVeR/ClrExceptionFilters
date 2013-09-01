using System;

namespace CSharpFilter
{
class Program
{
	static void Main(string[] args)
	{
		FilterException();
	}

	static void FilterException()
	{
		try
		{
			var exception = new Exception();
			exception.Data["foo"] = "bar1";
			Console.WriteLine("Throwing");
			throw exception;
		}
		catch (Exception exception)
		{
			if (!Filter(exception))
			{
				throw;
			}

			Console.WriteLine("Caught");
		}
	}

	static bool Filter(Exception exception)
	{
		return exception.Data["foo"].Equals("bar");
	}
}
}
