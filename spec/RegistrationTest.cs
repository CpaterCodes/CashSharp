namespace spec;
using System.Threading.Tasks;

public class RegistrationTest : IDisposable
{
	private readonly HttpClient client = new(){
		BaseAddress = new Uri("https://localhost:3000")
	};

    [Fact]
    public async Task ValidRegistration()
    {
		//var response = await client.PostAsync(
		//	"/register", 
		//	"");
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

