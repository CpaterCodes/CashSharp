namespace Endpoints;
using System.Text.Json;

public readonly struct Registration
{
	public String Name {get; private init;}
	public String Email {get;private init;}
	public String PhoneNumber {get; private init;}
	public String Password {get; private init;}

	public static void Parse()
	{
	}
}


