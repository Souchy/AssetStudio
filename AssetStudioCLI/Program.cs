using AssetStudioGUI;

namespace AssetStudioCLI;

internal class Program
{
    static void Main(string[] args)
    {
        string pathInput = args[0];
        string pathOutput = args[1];
        //string action = "extract"; // ex: "export assets" on path "Picto/ui/icon.bundle" to "out/icon/..."

        Directory.CreateDirectory(pathOutput);
        //if (action == "extract")
        //{
        int count = Studio.ExtractFile(pathInput, pathOutput);
        Console.WriteLine($"Extracted {count} files.");
        //}
    }
}
