using Questao2;
using System.Net;
using System.Net.Http.Json;
using System.Text;

public class Program
{
    private static readonly HttpClient client = new();

    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = 0;

        Task.Run(async () =>
        {
            totalGoals = await GetTotalScoredGoals(teamName, year);
        }).GetAwaiter().GetResult();

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;

        Task.Run(async () =>
        {
            totalGoals = await GetTotalScoredGoals(teamName, year);
        }).GetAwaiter().GetResult();

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }
   
    internal static async Task<FootballMatchesResult?> CallURL(string url)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        client.DefaultRequestHeaders.Accept.Clear();

        return await client.GetFromJsonAsync<FootballMatchesResult>(url);
    }

    internal static async Task<int> GetTotalScoredGoals(string team, int year)
    {
        StringBuilder urlTeam1 = new(@"https://jsonmock.hackerrank.com/api/football_matches");

        urlTeam1.Append($"?year={year}");
        urlTeam1.Append($"&team1={team}");

        Task<FootballMatchesResult?> team1GoalsResponseTask = CallURL(urlTeam1.ToString());

        StringBuilder urlTeam2 = new(urlTeam1.ToString());
        urlTeam2.Replace("&team1=", "&team2=");

        Task<FootballMatchesResult?> team2GoalsResponseTask = CallURL(urlTeam2.ToString());

        await Task.WhenAll(team1GoalsResponseTask, team2GoalsResponseTask);

        FootballMatchesResult? team1GoalsResponse = await team1GoalsResponseTask;
        FootballMatchesResult? team2GoalsResponse = await team2GoalsResponseTask;

        urlTeam1.Append("&page=");
        urlTeam2.Append("&page=");

        int totalGoals = 0;

        if (team1GoalsResponse is not null)
            totalGoals += await GetScoredGoalsMatches(urlTeam1, team1GoalsResponse, true);

        if (team2GoalsResponse is not null)
            totalGoals += await GetScoredGoalsMatches(urlTeam2, team2GoalsResponse);

        return totalGoals;
    }

    internal static async Task<int> GetScoredGoalsMatches(StringBuilder url, FootballMatchesResult originalResponse, bool homeGame = false)
    {
        int totalGoals = 0;

        if (originalResponse.TotalPages != 0)
        {
            if (originalResponse.TotalPages > 1)
            {
                List<Task<FootballMatchesResult?>> tasksList = new();

                for (int i = 1; i <= originalResponse.TotalPages; i++)
                {
                    url.Append($"{i}");
                    tasksList.Add(CallURL(url.ToString()));
                    url.Remove(url.Length - i.ToString().Length, i.ToString().Length);
                }

                foreach (FootballMatchesResult? result in await Task.WhenAll(tasksList))
                {
                    if (result is not null)
                    {
                        for (int i = 0; i < result.Data.Length; i++)
                        {
                            if (homeGame)
                            {
                                _ = int.TryParse(result.Data[i].Team1Goals, out int goals1);
                                totalGoals += goals1;
                            }
                            else
                            {
                                _ = int.TryParse(result.Data[i].Team2Goals, out int goals2);
                                totalGoals += goals2;
                            }                            
                        }
                    }
                }
            }
            else
            {
                if (originalResponse.Data.Length > 0)
                {
                    for (int i = 0; i < originalResponse.Data.Length; i++)
                    {
                        _ = int.TryParse(originalResponse.Data[i].Team1Goals, out int goals);
                        totalGoals += goals;
                    }
                }
            }
        }

        return totalGoals;
    }    
}