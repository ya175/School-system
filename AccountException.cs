using System;

public class AcccountException:Exception
{
	public AcccountException(string message="Wrong Data .This Account is not Existed ."):base(message) { }
	
}
