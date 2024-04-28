using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using UsersAPI.Infra.Messages.Models;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Services;

public class EmailMessageService
{
    private readonly EmailMessageSetings? _emailMessageSetings;

    public EmailMessageService(IOptions<EmailMessageSetings>? emailMessageSetings)
    {
        _emailMessageSetings = emailMessageSetings?.Value;
    }

    public async Task SendMessage(MessageRequestModel messageRequestModel)
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                var authResponseModel = await ExecuteAuthAsync(); //autenticando na API

                //criando paramentro de cabeçalho com o token
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authResponseModel.Token);
                var messageResquestContent = new StringContent(JsonConvert.SerializeObject(messageRequestModel),
                    Encoding.UTF8, "application/json");

                await httpClient.PostAsync($"{_emailMessageSetings?.BaseUrl}/email", messageResquestContent);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private async Task<AuthResponseModel> ExecuteAuthAsync()
    {
        using (var httpClient = new HttpClient())
        {
            var authRequestModel = new AuthRequestModel
            {
                Key = _emailMessageSetings?.User,
                Pass = _emailMessageSetings?.Pass
            };

            var authRequestContent = new StringContent(JsonConvert.SerializeObject(authRequestModel), Encoding.UTF8,
                "application/json");

            var authResponse =
                await httpClient.PostAsync($"{_emailMessageSetings?.BaseUrl}/auth", authRequestContent);
            var response = ReadResponse<AuthResponseModel>(authResponse);
            return response;
        }
    }

    private T ReadResponse<T>(HttpResponseMessage response)
    {
        var build = new StringBuilder();

        using (var item = response.Content)
        {
            var task = item.ReadAsStringAsync();
            build.Append(task.Result);
        }

        return JsonConvert.DeserializeObject<T>(build.ToString());
    }
}