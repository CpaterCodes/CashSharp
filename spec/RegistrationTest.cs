namespace spec;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;

public class RegistrationTest : IDisposable
{
	private readonly HttpClient client = new(){
		BaseAddress = new Uri("http://localhost:5078")
	};

    [Fact]
    public async Task ValidRegistration()
    {
		Dictionary<String, String> payload = new(){
			["name"] = "Bod Hudson",
			["email"] = "SonAndDone@example.com",
			["phoneNumber"] = "+44 1632 960280"
		};
		
		var response = await client.PostAsync(
			"/register", 
			new StringContent(JsonSerializer.Serialize(payload))
		);
		Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

	[Fact]
	public async Task InvalidEmailRegistration()
	{

	}

	[Fact]
	public async Task InvalidPhoneNumberRegistration()
	{

	}

	[Fact]
	public async Task MissingValuesRegistration()
	{

	}

	public void Dispose()
	{

	}
}

