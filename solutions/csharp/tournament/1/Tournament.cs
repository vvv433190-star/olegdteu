using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{
    public class TeamStats
    {
        public string Name;
        public int MP;
        public int W;
        public int D;
        public int L;
        public int P;
    }

    public static void Tally(Stream inStream, Stream outStream)
    {
        var reader = new StreamReader(inStream);
        var teams = new Dictionary<string, TeamStats>();

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(';');
            if (parts.Length != 3) continue;

            string team1 = parts[0];
            string team2 = parts[1];
            string result = parts[2];

            if (!teams.ContainsKey(team1)) teams[team1] = new TeamStats { Name = team1 };
            if (!teams.ContainsKey(team2)) teams[team2] = new TeamStats { Name = team2 };

            teams[team1].MP++;
            teams[team2].MP++;

            switch (result)
            {
                case "win":
                    teams[team1].W++; teams[team1].P += 3;
                    teams[team2].L++;
                    break;
                case "loss":
                    teams[team1].L++;
                    teams[team2].W++; teams[team2].P += 3;
                    break;
                case "draw":
                    teams[team1].D++; teams[team1].P += 1;
                    teams[team2].D++; teams[team2].P += 1;
                    break;
            }
        }

        var lines = new List<string>();
        lines.Add("Team                           | MP |  W |  D |  L |  P");

        var sortedTeams = teams.Values
            .OrderByDescending(t => t.P)
            .ThenBy(t => t.Name);

        foreach (var team in sortedTeams)
        {
            lines.Add($"{team.Name.PadRight(30)} | {team.MP,2} | {team.W,2} | {team.D,2} | {team.L,2} | {team.P,2}");
        }

        using var writer = new StreamWriter(outStream);
        for (int i = 0; i < lines.Count; i++)
        {
            writer.Write(lines[i]);
            if (i != lines.Count - 1)
                writer.Write('\n');
        }
        writer.Flush();
    }
}