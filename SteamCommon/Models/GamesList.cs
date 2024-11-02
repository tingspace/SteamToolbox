namespace SteamCommon.Models;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot(ElementName = "gamesList", Namespace = "", IsNullable = false)]
public partial class GamesList
{

    private ulong steamID64Field;

    private string steamIDField;

    private gamesListGame[] gamesField;

    /// <remarks/>
    public ulong steamID64
    {
        get
        {
            return steamID64Field;
        }
        set
        {
            steamID64Field = value;
        }
    }

    /// <remarks/>
    public string steamID
    {
        get
        {
            return steamIDField;
        }
        set
        {
            steamIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItem("game", IsNullable = false)]
    public gamesListGame[] games
    {
        get
        {
            return gamesField;
        }
        set
        {
            gamesField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public partial class gamesListGame
{

    private uint appIDField;

    private string nameField;

    private string logoField;

    private string storeLinkField;

    private string hoursLast2WeeksField;

    private bool hoursLast2WeeksFieldSpecified;

    private string hoursOnRecordField;

    private bool hoursOnRecordFieldSpecified;

    private string statsLinkField;

    private string globalStatsLinkField;

    /// <remarks/>
    public uint appID
    {
        get
        {
            return appIDField;
        }
        set
        {
            appIDField = value;
        }
    }

    /// <remarks/>
    public string name
    {
        get
        {
            return nameField;
        }
        set
        {
            nameField = value;
        }
    }

    /// <remarks/>
    public string logo
    {
        get
        {
            return logoField;
        }
        set
        {
            logoField = value;
        }
    }

    /// <remarks/>
    public string storeLink
    {
        get
        {
            return storeLinkField;
        }
        set
        {
            storeLinkField = value;
        }
    }

    /// <remarks/>
    public string hoursLast2Weeks
    {
        get
        {
            return hoursLast2WeeksField;
        }
        set
        {
            hoursLast2WeeksField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnore()]
    public bool hoursLast2WeeksSpecified
    {
        get
        {
            return hoursLast2WeeksFieldSpecified;
        }
        set
        {
            hoursLast2WeeksFieldSpecified = value;
        }
    }

    /// <remarks/>
    public string hoursOnRecord
    {
        get
        {
            return hoursOnRecordField;
        }
        set
        {
            hoursOnRecordField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnore()]
    public bool hoursOnRecordSpecified
    {
        get
        {
            return hoursOnRecordFieldSpecified;
        }
        set
        {
            hoursOnRecordFieldSpecified = value;
        }
    }

    /// <remarks/>
    public string statsLink
    {
        get
        {
            return statsLinkField;
        }
        set
        {
            statsLinkField = value;
        }
    }

    /// <remarks/>
    public string globalStatsLink
    {
        get
        {
            return globalStatsLinkField;
        }
        set
        {
            globalStatsLinkField = value;
        }
    }
}

