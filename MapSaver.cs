using System.Xml.Serialization;
using Spectre.Console;

public static class MapSaver
{
    public static void SaveMap(Map map, string destinationTmxPath)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(Map));
            using var reader = new StreamWriter(destinationTmxPath);
            serializer.Serialize(reader, map);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            throw;
        }
    }
}