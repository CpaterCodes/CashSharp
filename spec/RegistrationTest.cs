namespace spec;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;

public class RegistrationTest : IDisposable
{
	private readonly HttpClient client = new(){
		BaseAddress = new Uri("http://localhost:5078")
	};

	private Dictionary<String, String> Registration(
		String name = "Bob Hudson",
		String email = "SonAndDone@example.com",
		String phoneNumber = "+44 1632 960280",
		String password = "correcthorsebatteystaple"
	)
	{
		return new ()
		{
			["name"] = name,
			["email"] = email,
			["phoneNumber"] = phoneNumber,
			["password"] = password
		};
	}
	
	private StringContent Payload(Dictionary<String, String> data)
	{
		return new StringContent(JsonSerializer.Serialize(data));
	}

    [Fact]
    public async Task ValidRegistration()
    {
		StringContent regPayload = Payload(Registration());
		var response = await client.PostAsync("/register", regPayload);
		Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

	[Fact]
	public async Task InvalidEmailRegistration()
	{
		StringContent regPayload = Payload(
			Registration(email: "hello.world")
		);
		var response = await client.PostAsync("/register", regPayload);
		Assert.Equal(
			HttpStatusCode.UnprocessableContent, response.StatusCode
		);
	}

	[Fact]
	public async Task InvalidPhoneNumberRegistration()
	{
		StringContent regPayload = Payload(
			Registration(phoneNumber: "+4 aaaa")
		);
		var response = await client.PostAsync("/register", regPayload);
		Assert.Equal(
			HttpStatusCode.UnprocessableContent, response.StatusCode
		);
	}

	[Fact]
	public async Task MissingValuesRegistration()
	{
		Dictionary<String,String> missingValsReg = new()
		{ 
			["name"] = "Joe King", 
			["email"] = "Joking@example.com" 
		};
		StringContent regPayload = Payload(missingValsReg);
		var response = await client.PostAsync("/register", regPayload);
		Assert.Equal(
			HttpStatusCode.BadRequest, response.StatusCode
		);
	}
	
	[Fact]
	public async Task NonsenseRegistration(){
		Dictionary<String,String> missingValsReg = new()
		{ 
			["foo"] = "marco!", 
			["bar"] = "polo!" 
		};
		StringContent regPayload = Payload(missingValsReg);
		var response = await client.PostAsync("/register", regPayload);
		Assert.Equal(
			HttpStatusCode.BadRequest, response.StatusCode
		);
	}

	public void Dispose()
	{

	}
}

