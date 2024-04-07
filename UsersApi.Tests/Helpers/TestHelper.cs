using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace UsersApi.Tests.Helpers
{
    public static class TestHelper
    {
        //Método para criar um client http da api de usuario
        public static HttpClient CreateClient => new WebApplicationFactory<Program>().CreateClient();

        //Método para serializar o conteudo da requisição que será enviada para um serviço
        public static StringContent CreateContent<TRequest>(TRequest request) => new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

        //Método para deselializar o retorno obtido pela execução de um serviço
        public static TResponse ReadResponse<TResponse>(HttpResponseMessage message) => JsonConvert.DeserializeObject<TResponse>(message.Content.ReadAsStringAsync().Result);
    }
}
