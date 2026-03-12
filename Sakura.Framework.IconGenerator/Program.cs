// This code is part of the Sakura framework project. Licensed under the MIT License.
// See the LICENSE file for full license text.

using System.Text;

namespace Sakura.Framework.IconGenerator;

internal class Program
{
    private static void Main(string[] args)
    {
        string outputFile = "IconUsage.cs";

        Console.WriteLine("Current directory: " + Directory.GetCurrentDirectory());
        string[] codepointFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Fonts"), "*.codepoints");

        if (codepointFiles.Length == 0)
        {
            Console.WriteLine("No .codepoints files found in the Fonts directory.");
            return;
        }

        string inputFile = codepointFiles[0];
        Console.WriteLine($"Using codepoints file: {Path.GetFileName(inputFile)}");

        string[] lines = File.ReadAllLines(inputFile);
        var sb = new StringBuilder();

        sb.AppendLine("namespace Sakura.Framework.Graphics.Drawables;");
        sb.AppendLine();
        sb.AppendLine("public enum IconUsage : uint");
        sb.AppendLine("{");

        int parsedCount = 0;
        HashSet<string> usedNames = new HashSet<string>();

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;

            string rawName = parts[0];
            string hexCode = parts[1];

            string enumName = convertSnakeToPascalCase(rawName);

            if (char.IsDigit(enumName[0]))
                enumName = "_" + enumName;

            if (enumName == "Class" || enumName == "Event" || enumName == "Return")
                enumName = "@" + enumName;

            // Ensure we don't add duplicate enum names
            if (usedNames.Add(enumName))
            {
                sb.AppendLine($"    /// <summary>{rawName} (U+{hexCode})</summary>");
                sb.AppendLine($"    {enumName} = 0x{hexCode},");
                parsedCount++;
            }
        }

        sb.AppendLine("}");

        File.WriteAllText(outputFile, sb.ToString());
        Console.WriteLine($"Successfully generated {outputFile} with {parsedCount} icons");
    }

    private static string convertSnakeToPascalCase(string input)
    {
        string[] words = input.Split('_');
        var result = new StringBuilder();
        foreach (var word in words)
        {
            if (word.Length > 0)
            {
                result.Append(char.ToUpper(word[0]));
                if (word.Length > 1)
                    result.Append(word.Substring(1).ToLower());
            }
        }
        return result.ToString();
    }
}
