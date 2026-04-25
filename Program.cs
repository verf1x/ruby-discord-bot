using System.Net.Http;
using System.Text.Json.Nodes;
using System.Linq;

const string baseAddress = "http://127.0.0.1:2333";
const string passphrase = "youshallnotpass";
const string query = "scsearch:bones ctrlaltdelete";

using var http = new HttpClient
{
    BaseAddress = new Uri(baseAddress),
    Timeout = TimeSpan.FromSeconds(15),
};

http.DefaultRequestHeaders.Add("Authorization", passphrase);

var json = JsonNode.Parse(await http.GetStringAsync($"/v4/loadtracks?identifier={Uri.EscapeDataString(query)}"));
var title = ExtractTitle(json?["data"]);

Console.WriteLine(title is null ? "трек не найден" : $"найдено: {title}");

static string? ExtractTitle(JsonNode? data)
{
    if (data is JsonObject single)
    {
        return single["info"]?["title"]?.GetValue<string>();
    }

    if (data is JsonArray many)
    {
        return many.FirstOrDefault()?["info"]?["title"]?.GetValue<string>();
    }

    return null;
}