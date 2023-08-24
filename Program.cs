using Spectre.Console;

AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("Welcome to [purple]TMX tileset deduplicator[/] ([grey]v1.0.1[/]) by [blue]Tom O'Neill[/].");
AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("NOTE: Tilesets will always be consolidated into the first tileset.");
AnsiConsole.MarkupLine("Remember, you can always fix the image source of the leftover tileset later!");
AnsiConsole.WriteLine();

var tmxPath = AnsiConsole.Ask<string>("Where is the [purple].tmx[/] located?");
var map = MapLoader.TryLoadMap(tmxPath);

if (map == null)
{
    throw new FileLoadException($"Could not load '{tmxPath}'");
}

var selectedTilesets = AnsiConsole.Prompt(
    new MultiSelectionPrompt<Tileset>()
        .Title("Which [purple]tilesets[/] do you want to deduplicate?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more tilesets)[/]")
        .InstructionsText(
            "[grey](Press [blue]<space>[/] to toggle a tileset, " +
            "[green]<enter>[/] to accept)[/]")
        .AddChoices(map.Tilesets.ToArray())
        .UseConverter((tileset) => $"{tileset.Name} ([grey]{tileset.Image.Source}[/]) (tiles: {tileset.TileCount})")
);

var tileGrids = selectedTilesets.Select(tileset =>
{
    var index = 0;
    return Enumerable.Range(tileset.FirstGid, tileset.TileCount).ToDictionary(i => index++);
});

var sourceTileset = tileGrids.ElementAt(0);
var otherTilesets = tileGrids.Skip(1);
AnsiConsole.MarkupLine($"Using tileset '[purple]{selectedTilesets.ElementAt(0).Name}[/]' ([grey]{selectedTilesets.ElementAt(0).Image.Source}[/]) as source.");
map.Layers.ForEach((layer) =>
{
    AnsiConsole.MarkupLine($"Processing layer '[blue]{layer.Name}[/]'");
    if (layer.Data.Encoding != "csv")
    {
        throw new NotSupportedException($"Layer '{layer.Name}' had data encoding '{layer.Data.Encoding}'. Only 'csv' is supported. Please open an issue on GitHub.");
    }
    var layerTiles = layer.Data.Text.Split(',').Select(tile =>
    {
        if (tile == "0" || tile == "\n")
        {
            return tile;
        }
        var isParsable = int.TryParse(tile, out var tileGid);
        if (!isParsable)
        {
            AnsiConsole.MarkupLine($"[yellow]WARNING: Layer '{layer.Name}' contained value '{tile}' which could not be processed. There could be issues with the result, though it's not likely.[/]");
            return tile;
        }
        if (!otherTilesets.Any(tileset => tileset.Values.Contains(tileGid)))
        {
            return tile;
        }

        var tilesetContainingTile = otherTilesets.Single(tileset => tileset.Values.Contains(tileGid));
        var tileSetIndex = tilesetContainingTile.FirstOrDefault(x => x.Value == tileGid).Key;
        var sourceTilesetEquivalentGid = sourceTileset[tileSetIndex];

        return sourceTilesetEquivalentGid.ToString();
    });
    AnsiConsole.MarkupLine($"Rewriting layer '[blue]{layer.Name}[/]'");
    layer.Data.Text = string.Join(',', layerTiles);
});

var selectedTilesetsButFirst = selectedTilesets.GetRange(1, selectedTilesets.Count - 1);
map.Tilesets.RemoveAll(tileset =>
{
    var shouldRemove = selectedTilesetsButFirst.Any(selectedTileset => tileset == selectedTileset);
    if (shouldRemove)
    {
        AnsiConsole.MarkupLine($"Removing tileset '[purple]{tileset.Name}[/]' ([grey]{tileset.Image.Source}[/])");
    }
    return shouldRemove;
});

var tmxPathWithoutExtension = Path.GetFileNameWithoutExtension(tmxPath);
var destinationTmxPath = tmxPath.Replace(tmxPathWithoutExtension, $"{tmxPathWithoutExtension}-merged");
MapSaver.SaveMap(map, destinationTmxPath);
AnsiConsole.WriteLine();
AnsiConsole.MarkupLine($"[green]All done![/] The consolidated file can be found at '[grey]{destinationTmxPath}[/]'");
AnsiConsole.WriteLine();
Console.ReadLine();