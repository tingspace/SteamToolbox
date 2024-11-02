using MatchingSteamGames;
using SteamCommon;

var config = CommonSetupHelper.GetConfiguration();
var serviceFactory = CommonSetupHelper.GetServiceFactory(config);
var matcher = new Matcher(serviceFactory);

var exit = false;
var retry = true;
var retryCount = 0;
var maxRetries = 3;

Console.WriteLine("Enter 2 Steam Profile URLs to compare:");

var urls = new List<string>();
while (retry && retryCount < maxRetries)
{
    if (urls.Count == 2)
    {
        break;
    }
    
    var msg = urls.Count == 0 
        ? "Profile 1: " 
        : "Profile 2: ";
    Console.Write(msg);
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("You gave me nothing. DO IT AGAIN.");
        continue;
    }

    if (input.Contains("exit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Exiting...");
        retry = false;
        exit = true;
        continue;
    }

    var pieces = input.Split('/');
    if (pieces.Length < 4)
    {
        Console.WriteLine("Don't know what you gave, but I can't parse this. Do it again.");
        retryCount++;
        continue;
    }

    urls.Add(input);
}

if (exit || urls.Count < 2)
{
    return;
}

Console.WriteLine($"Comparing the games of: \n\t{urls[0]}\n\t{urls[1]}");
var matches = new List<string>();
var matchedGameCounts = matcher.FindMatchesFor(urls.ToArray());
foreach (var matchedGame in matchedGameCounts)
{
    if (matchedGame.Value > 0)
    {
        matches.Add(matchedGame.Key);
    }
}

Console.WriteLine($"Matched {matches.Count} matches.");
Console.WriteLine("Matched Games:");
foreach (var match in matches)
{
    Console.WriteLine($"\t{match}");
}
