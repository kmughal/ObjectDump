namespace Debug
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;

    public static class Dump
    {

        public static void SaveDumpInClipboard<T>(T value)
        {
            var result = CreateDump(value);
            TextCopy.Clipboard.SetText(result);
        }

        public static void SaveDumpInFile<T>(T value)
        {
            var result = CreateDump(value);
            if (!Directory.Exists("json")) Directory.CreateDirectory("json");
            var fullPathString = Path.Combine("json", $"dump_{Path.GetRandomFileName()}.json");
            File.AppendAllText(fullPathString, result);
        }

        public static async Task WriteDumpInStandardOutput<T>(T value, TextWriter tw)
        {
            var result = CreateDump(value);
            var lines = result.Split('\n');
            foreach (var line in lines)
            {
                await tw.WriteLineAsync(line);
            }
        }

        static string CreateDump<T>(T value, string propertyName = "value")
        {
            Type @objectType = value.GetType();

            if (IsPrimitiveOrString(value))
            {
                return $@"""{propertyName}"" : ""{value.ToString()}""";
            }
            else
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var jsonContents = JsonSerializer.Serialize(value, options);
                return jsonContents;
            }

            bool IsPrimitiveOrString(T _input)
            {
                return _input.GetType() == typeof(string) || _input.GetType().IsPrimitive;
            }
        }
    }
}
