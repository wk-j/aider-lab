using NSwag;
using NSwag.CodeGeneration.CSharp;

class Program
{
    static async Task Main(string[] args)
    {
        // Load the Swagger specification
        var document = await OpenApiDocument.FromFileAsync("src/MyApp/swagger.json");

        // Configure the code generator settings
        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "MyAppClient",
            CSharpGeneratorSettings =
            {
                Namespace = "MyApp.Client"
            }
        };

        // Generate the client code
        var generator = new CSharpClientGenerator(document, settings);
        var code = generator.GenerateFile();

        // Write the generated code to a file
        await File.WriteAllTextAsync("src/MyApp.Client/MyAppClient.cs", code);

        Console.WriteLine("C# client generated successfully.");
    }
}
