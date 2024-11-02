namespace SteamCommon.Models;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
[System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
public partial class Profile
{

    private ulong steamID64Field;

    private string steamIDField;

    private string onlineStateField;

    private string stateMessageField;

    private string privacyStateField;

    private byte visibilityStateField;

    private string avatarIconField;

    private string avatarMediumField;

    private string avatarFullField;

    private byte vacBannedField;

    private string tradeBanStateField;

    private byte isLimitedAccountField;

    private string customURLField;

    private string memberSinceField;

    private object steamRatingField;

    private decimal hoursPlayed2WkField;

    private string headlineField;

    private string locationField;

    private string realnameField;

    private string summaryField;

    private profileMostPlayedGame[] mostPlayedGamesField;

    private profileGroup[] groupsField;

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
    public string onlineState
    {
        get
        {
            return onlineStateField;
        }
        set
        {
            onlineStateField = value;
        }
    }

    /// <remarks/>
    public string stateMessage
    {
        get
        {
            return stateMessageField;
        }
        set
        {
            stateMessageField = value;
        }
    }

    /// <remarks/>
    public string privacyState
    {
        get
        {
            return privacyStateField;
        }
        set
        {
            privacyStateField = value;
        }
    }

    /// <remarks/>
    public byte visibilityState
    {
        get
        {
            return visibilityStateField;
        }
        set
        {
            visibilityStateField = value;
        }
    }

    /// <remarks/>
    public string avatarIcon
    {
        get
        {
            return avatarIconField;
        }
        set
        {
            avatarIconField = value;
        }
    }

    /// <remarks/>
    public string avatarMedium
    {
        get
        {
            return avatarMediumField;
        }
        set
        {
            avatarMediumField = value;
        }
    }

    /// <remarks/>
    public string avatarFull
    {
        get
        {
            return avatarFullField;
        }
        set
        {
            avatarFullField = value;
        }
    }

    /// <remarks/>
    public byte vacBanned
    {
        get
        {
            return vacBannedField;
        }
        set
        {
            vacBannedField = value;
        }
    }

    /// <remarks/>
    public string tradeBanState
    {
        get
        {
            return tradeBanStateField;
        }
        set
        {
            tradeBanStateField = value;
        }
    }

    /// <remarks/>
    public byte isLimitedAccount
    {
        get
        {
            return isLimitedAccountField;
        }
        set
        {
            isLimitedAccountField = value;
        }
    }

    /// <remarks/>
    public string customURL
    {
        get
        {
            return customURLField;
        }
        set
        {
            customURLField = value;
        }
    }

    /// <remarks/>
    public string memberSince
    {
        get
        {
            return memberSinceField;
        }
        set
        {
            memberSinceField = value;
        }
    }

    /// <remarks/>
    public object steamRating
    {
        get
        {
            return steamRatingField;
        }
        set
        {
            steamRatingField = value;
        }
    }

    /// <remarks/>
    public decimal hoursPlayed2Wk
    {
        get
        {
            return hoursPlayed2WkField;
        }
        set
        {
            hoursPlayed2WkField = value;
        }
    }

    /// <remarks/>
    public string headline
    {
        get
        {
            return headlineField;
        }
        set
        {
            headlineField = value;
        }
    }

    /// <remarks/>
    public string location
    {
        get
        {
            return locationField;
        }
        set
        {
            locationField = value;
        }
    }

    /// <remarks/>
    public string realname
    {
        get
        {
            return realnameField;
        }
        set
        {
            realnameField = value;
        }
    }

    /// <remarks/>
    public string summary
    {
        get
        {
            return summaryField;
        }
        set
        {
            summaryField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItem("mostPlayedGame", IsNullable = false)]
    public profileMostPlayedGame[] mostPlayedGames
    {
        get
        {
            return mostPlayedGamesField;
        }
        set
        {
            mostPlayedGamesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItem("group", IsNullable = false)]
    public profileGroup[] groups
    {
        get
        {
            return groupsField;
        }
        set
        {
            groupsField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public partial class profileMostPlayedGame
{

    private string gameNameField;

    private string gameLinkField;

    private string gameIconField;

    private string gameLogoField;

    private string gameLogoSmallField;

    private decimal hoursPlayedField;

    private decimal hoursOnRecordField;

    private string statsNameField;

    /// <remarks/>
    public string gameName
    {
        get
        {
            return gameNameField;
        }
        set
        {
            gameNameField = value;
        }
    }

    /// <remarks/>
    public string gameLink
    {
        get
        {
            return gameLinkField;
        }
        set
        {
            gameLinkField = value;
        }
    }

    /// <remarks/>
    public string gameIcon
    {
        get
        {
            return gameIconField;
        }
        set
        {
            gameIconField = value;
        }
    }

    /// <remarks/>
    public string gameLogo
    {
        get
        {
            return gameLogoField;
        }
        set
        {
            gameLogoField = value;
        }
    }

    /// <remarks/>
    public string gameLogoSmall
    {
        get
        {
            return gameLogoSmallField;
        }
        set
        {
            gameLogoSmallField = value;
        }
    }

    /// <remarks/>
    public decimal hoursPlayed
    {
        get
        {
            return hoursPlayedField;
        }
        set
        {
            hoursPlayedField = value;
        }
    }

    /// <remarks/>
    public decimal hoursOnRecord
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
    public string statsName
    {
        get
        {
            return statsNameField;
        }
        set
        {
            statsNameField = value;
        }
    }
}

/// <remarks/>
[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[System.Xml.Serialization.XmlType(AnonymousType = true)]
public partial class profileGroup
{

    private ulong groupID64Field;

    private string groupNameField;

    private string groupURLField;

    private string headlineField;

    private string summaryField;

    private string avatarIconField;

    private string avatarMediumField;

    private string avatarFullField;

    private ushort memberCountField;

    private bool memberCountFieldSpecified;

    private byte membersInChatField;

    private bool membersInChatFieldSpecified;

    private byte membersInGameField;

    private bool membersInGameFieldSpecified;

    private byte membersOnlineField;

    private bool membersOnlineFieldSpecified;

    private byte isPrimaryField;

    /// <remarks/>
    public ulong groupID64
    {
        get
        {
            return groupID64Field;
        }
        set
        {
            groupID64Field = value;
        }
    }

    /// <remarks/>
    public string groupName
    {
        get
        {
            return groupNameField;
        }
        set
        {
            groupNameField = value;
        }
    }

    /// <remarks/>
    public string groupURL
    {
        get
        {
            return groupURLField;
        }
        set
        {
            groupURLField = value;
        }
    }

    /// <remarks/>
    public string headline
    {
        get
        {
            return headlineField;
        }
        set
        {
            headlineField = value;
        }
    }

    /// <remarks/>
    public string summary
    {
        get
        {
            return summaryField;
        }
        set
        {
            summaryField = value;
        }
    }

    /// <remarks/>
    public string avatarIcon
    {
        get
        {
            return avatarIconField;
        }
        set
        {
            avatarIconField = value;
        }
    }

    /// <remarks/>
    public string avatarMedium
    {
        get
        {
            return avatarMediumField;
        }
        set
        {
            avatarMediumField = value;
        }
    }

    /// <remarks/>
    public string avatarFull
    {
        get
        {
            return avatarFullField;
        }
        set
        {
            avatarFullField = value;
        }
    }

    /// <remarks/>
    public ushort memberCount
    {
        get
        {
            return memberCountField;
        }
        set
        {
            memberCountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnore()]
    public bool memberCountSpecified
    {
        get
        {
            return memberCountFieldSpecified;
        }
        set
        {
            memberCountFieldSpecified = value;
        }
    }

    /// <remarks/>
    public byte membersInChat
    {
        get
        {
            return membersInChatField;
        }
        set
        {
            membersInChatField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnore()]
    public bool membersInChatSpecified
    {
        get
        {
            return membersInChatFieldSpecified;
        }
        set
        {
            membersInChatFieldSpecified = value;
        }
    }

    /// <remarks/>
    public byte membersInGame
    {
        get
        {
            return membersInGameField;
        }
        set
        {
            membersInGameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnore()]
    public bool membersInGameSpecified
    {
        get
        {
            return membersInGameFieldSpecified;
        }
        set
        {
            membersInGameFieldSpecified = value;
        }
    }

    /// <remarks/>
    public byte membersOnline
    {
        get
        {
            return membersOnlineField;
        }
        set
        {
            membersOnlineField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnore()]
    public bool membersOnlineSpecified
    {
        get
        {
            return membersOnlineFieldSpecified;
        }
        set
        {
            membersOnlineFieldSpecified = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute()]
    public byte isPrimary
    {
        get
        {
            return isPrimaryField;
        }
        set
        {
            isPrimaryField = value;
        }
    }
}

