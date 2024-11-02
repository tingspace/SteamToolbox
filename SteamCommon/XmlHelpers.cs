namespace SteamCommon;

using System.Xml.Serialization;

public static class XmlHelpers
{
    private static readonly Dictionary<Type, XmlSerializer> CachedSerializers = new();

    public static T ReadAs<T>(string xmlContent)
    {
        if (!CachedSerializers.TryGetValue(typeof(T), out var serializer))
        {
            serializer = new XmlSerializer(typeof(T));
            CachedSerializers.Add(typeof(T), serializer);
        }

        var xmlReader = new StringReader(xmlContent.Trim());
        return (T)serializer.Deserialize(xmlReader)!;
    }
}
