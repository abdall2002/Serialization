// See https://aka.ms/new-console-template for more information

using System;
using CAHttpClientJson;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

private readonly static HttpClient httpClient = new HttpClient();
static async Task Main(string[] args)
{
    var todoesJsonContent = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

    var todoes = JsonSerializer.Deserialize<List<Todo>>(todoesJsonContent
        , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    foreach (var item in todoes)
        Console.WriteLine(item);
}



