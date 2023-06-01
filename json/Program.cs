using System.Text.Json;
using System.Text.Json.Nodes;

var jsonString = File.ReadAllText(args.FirstOrDefault() ?? "large-file.json");
var start = DateTime.UtcNow;
JsonNode forecastNode = JsonNode.Parse(jsonString)!;
Console.WriteLine($"{forecastNode.AsArray().Count} objects read at {DateTime.UtcNow - start}");
