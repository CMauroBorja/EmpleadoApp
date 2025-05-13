using System.Net.Http;
using System.Threading.Tasks;

public class ApiService
{
    public async Task ObtenerDatosExternosAsync()
    {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
        var contenido = await response.Content.ReadAsStringAsync();
        Console.WriteLine(contenido);
    }
}