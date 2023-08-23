using System.Xml.Serialization;

[XmlRoot(ElementName = "property")]
public class Property
{

    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "properties")]
public class Properties
{

    [XmlElement(ElementName = "property")]
    public List<Property> Property { get; set; }
}

[XmlRoot(ElementName = "image")]
public class Image
{

    [XmlAttribute(AttributeName = "source")]
    public string Source { get; set; }

    [XmlAttribute(AttributeName = "width")]
    public int Width { get; set; }

    [XmlAttribute(AttributeName = "height")]
    public int Height { get; set; }
}

[XmlRoot(ElementName = "frame")]
public class Frame
{

    [XmlAttribute(AttributeName = "tileid")]
    public int TileId { get; set; }

    [XmlAttribute(AttributeName = "duration")]
    public int Duration { get; set; }
}

[XmlRoot(ElementName = "animation")]
public class Animation
{

    [XmlElement(ElementName = "frame")]
    public List<Frame> Frames { get; set; }
}

[XmlRoot(ElementName = "tile")]
public class Tile
{

    [XmlElement(ElementName = "properties")]
    public Properties Properties { get; set; }

    [XmlElement(ElementName = "animation")]
    public Animation Animation { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }
}

[XmlRoot(ElementName = "tileset")]
public class Tileset
{

    [XmlElement(ElementName = "image")]
    public Image Image { get; set; }

    [XmlElement(ElementName = "tile")]
    public List<Tile> Tiles { get; set; }

    [XmlAttribute(AttributeName = "firstgid")]
    public int FirstGid { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "tilewidth")]
    public int TileWidth { get; set; }

    [XmlAttribute(AttributeName = "tileheight")]
    public int TileHeight { get; set; }

    [XmlAttribute(AttributeName = "tilecount")]
    public int TileCount { get; set; }

    [XmlAttribute(AttributeName = "columns")]
    public int Columns { get; set; }
}

[XmlRoot(ElementName = "data")]
public class Data
{

    [XmlAttribute(AttributeName = "encoding")]
    public string Encoding { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "layer")]
public class Layer
{

    [XmlElement(ElementName = "data")]
    public Data Data { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "width")]
    public int Width { get; set; }

    [XmlAttribute(AttributeName = "height")]
    public int Height { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "object")]
public class Object
{

    [XmlElement(ElementName = "properties")]
    public Properties Properties { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "x")]
    public int X { get; set; }

    [XmlAttribute(AttributeName = "y")]
    public int Y { get; set; }

    [XmlAttribute(AttributeName = "width")]
    public int Width { get; set; }

    [XmlAttribute(AttributeName = "height")]
    public int Height { get; set; }
}

[XmlRoot(ElementName = "objectgroup")]
public class Objectgroup
{

    [XmlElement(ElementName = "object")]
    public Object Object { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "visible")]
    public int Visible { get; set; }
}

[XmlRoot(ElementName = "map")]
public class Map
{

    [XmlElement(ElementName = "properties")]
    public Properties Properties { get; set; }

    [XmlElement(ElementName = "tileset")]
    public List<Tileset> Tilesets { get; set; }

    [XmlElement(ElementName = "layer")]
    public List<Layer> Layers { get; set; }

    [XmlElement(ElementName = "objectgroup")]
    public List<Objectgroup> Objectgroups { get; set; }

    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; }

    [XmlAttribute(AttributeName = "tiledversion")]
    public string Tiledversion { get; set; }

    [XmlAttribute(AttributeName = "orientation")]
    public string Orientation { get; set; }

    [XmlAttribute(AttributeName = "renderorder")]
    public string Renderorder { get; set; }

    [XmlAttribute(AttributeName = "compressionlevel")]
    public int Compressionlevel { get; set; }

    [XmlAttribute(AttributeName = "width")]
    public int Width { get; set; }

    [XmlAttribute(AttributeName = "height")]
    public int Height { get; set; }

    [XmlAttribute(AttributeName = "tilewidth")]
    public int TileWidth { get; set; }

    [XmlAttribute(AttributeName = "tileheight")]
    public int TileHeight { get; set; }

    [XmlAttribute(AttributeName = "infinite")]
    public int Infinite { get; set; }

    [XmlAttribute(AttributeName = "nextlayerid")]
    public int Nextlayerid { get; set; }

    [XmlAttribute(AttributeName = "nextobjectid")]
    public int NextObjectId { get; set; }

    [XmlText]
    public string Text { get; set; }
}

