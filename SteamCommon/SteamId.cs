namespace SteamCommon;

using System.Collections;


/// <summary>
/// Provides a simple interface wrapping the <b>Steam64 Id</b> and <b>Steam3 Id</b> values using
/// the public SteamId64.
/// </summary>
/// <remarks>
/// SteamIds are publicly exposed 64-bit integers that encode information about the given
/// account. When decoded into it's textual form, known as a <c>Steam3 Id</c> it unpacks
/// more information about the profile.
/// <para>
/// You can read more on <see href="https://developer.valvesoftware.com/wiki/SteamID">Valve's website</see>.
/// </para>
/// </remarks>
public class SteamId
{
    private readonly long _steamId64;

    public SteamId(string steamId64) : this(long.Parse(steamId64))
    {
    }

    public SteamId(long steamId64)
    {
        _steamId64 = steamId64;
        SetSteamIds();
    }

    public string SteamId64 => _steamId64.ToString();
    public long SteamId64Number => _steamId64;


    private string _steam2Id { get; set; }
    public string Steam2Id => _steam2Id;
    private int _steam2IdNumber { get; set; }
    public int Steam2IdNumber => _steam2IdNumber;


    private string _steam3Id { get; set; }
    public string Steam3Id => _steam3Id;
    private int _steam3IdNumber { get; set; }
    public int Steam3IdNumber => _steam3IdNumber;


    private void SetSteamIds()
    {
        byte[] steamId64Bytes = BitConverter.GetBytes(_steamId64);
        BitArray steamId64Bits = new BitArray(steamId64Bytes);

        bool yBit = false;
        List<bool> zBits = new();
        List<bool> instanceBits = new();
        List<bool> accountTypeBits = new();
        List<bool> universeBits = new();

        for (int i = 1; i < steamId64Bits.Length + 1; i++)
        {
            var idx = i - 1;
            if (i == 1)
            {
                yBit = steamId64Bits[idx];
                continue;
            }

            if (i <= 32)
            {
                zBits.Add(steamId64Bits[idx]);
                continue;
            }

            if (i <= 52)
            {
                instanceBits.Add(steamId64Bits[idx]);
                continue;
            }

            if (i <= 56)
            {
                accountTypeBits.Add(steamId64Bits[idx]);
                continue;
            }

            if (i <= 64)
            {
                universeBits.Add(steamId64Bits[idx]);
                continue;
            }
        }

        var Y = Convert.ToInt32(yBit);
        var accountNumber = GetIntFromBitArray(new BitArray(zBits.ToArray()));
        var instance = GetIntFromBitArray(new BitArray(instanceBits.ToArray()));

        int accountType = GetIntFromBitArray(new BitArray(accountTypeBits.ToArray()));
        string accountTypeLetter = GetAccountTypeLetter(accountType);
        var universe = GetIntFromBitArray(new BitArray(universeBits.ToArray()));


        _steam2IdNumber = accountNumber;
        _steam2Id = $"STEAM_{accountType}:{universe}:{accountNumber}";


        int steam3AccountNumber = accountNumber * 2 + Y;
        _steam3Id = $"{accountTypeLetter}:{universe}:{steam3AccountNumber}";
        _steam3IdNumber = steam3AccountNumber;
    }

    private static int GetIntFromBitArray(BitArray bits)
    {
        if (bits.Length > 32)
        {
            throw new ArgumentException("Bit length cannot be greater than 32 bits");
        }

        int[] intArray = new int[1];
        bits.CopyTo(intArray, 0);

        return intArray[0];
    }

    private static string GetAccountTypeLetter(int accountType)
    {
        switch (accountType)
        {
            case 1:
                return "U"; // Individual
            case 2:
                return "M"; // Multiseat
            case 3:
                return "G"; // GameServer
            case 4:
                return "A"; // AnonGameServer
            case 5:
                return "P"; // Pending
            case 6:
                return "C"; // ContentServer
            case 7:
                return "g"; // Clean
            case 8:
                return "T"; // Chat
            case 9:
                return string.Empty; // P2P SuperSeeder (Fake SteamID for local PSN Account)
            case 10:
                return "a"; // AnonUser
            default:
                return "I"; // Invalid
        }
    }
}
