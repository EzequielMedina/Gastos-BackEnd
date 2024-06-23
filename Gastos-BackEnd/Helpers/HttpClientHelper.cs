using Gastos_BackEnd.Models.Response;
using Gastos_BackEnd.Repository.Entity;
using System.Net.Http.Json;
using System.Text.Json;

namespace Gastos_BackEnd.Helpers
{
    public static class HttpClientHelper
    {

        private static HttpClientWrapper _httpClient = new HttpClientWrapper();
        private static string _url = "http://192.168.1.2:8081/";


        public static async Task<List<Persona>> PostListPersonaByOrganizacion(string token) {
            List<Persona> listPersona = new List<Persona>();
            try
            {
                string urlPost = _url + "user/GetUsersByOrganization";
                string jsonContent = token;
                string resultPost = await _httpClient.PostAsync(urlPost, jsonContent);
                ResponseBase response = JsonSerializer.Deserialize<ResponseBase>(resultPost);

                if (response.Ok)
                {
                    listPersona = JsonSerializer.Deserialize<List<Persona>>(response.Data.ToString());
                }
            }
            catch (Exception ex)
            {

            }
          
            return listPersona;
        }
        // Ejemplo de solicitud GET
    //    string urlGet = "https://api.example.com/data";
    //string resultGet = await client.GetAsync(urlGet);
    //Console.WriteLine("GET result: " + resultGet);

        // Ejemplo de solicitud POST
    //    string urlPost = "https://api.example.com/data";
    //string jsonContent = "{\"key\":\"value\"}";
    //string resultPost = await client.PostAsync(urlPost, jsonContent);
    //Console.WriteLine("POST result: " + resultPost);
    }
}
