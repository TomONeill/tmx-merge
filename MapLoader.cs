using System.Xml.Serialization;
using Spectre.Console;

public static class MapLoader
{
    public static Map? TryLoadMap(string tmxPath)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Map));
            using (var reader = new StreamReader(tmxPath))
            {
                return (Map?)serializer.Deserialize(reader);
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            throw;
        }
    }
}