##### C# constructs
1. Collection: List<Team> teams = new List<Team>();
2. String interpolation(not sure if this is string formatting): status = String.Format("{0,-3}({1,1}) {2,-2} {3,-2} {4,-2} {5,-2} +{6,-3} -{7,-3} {8,-3}", abbreviation, specialStatus, matches, wonM, drawM, lostM, gFor, gAgainst, points);
3. Class and properties: class Team{ public string abbreviation {get; set;} = "unknown"; .. }
4. Try/catch: try{ .. var reader = new StreamReader("CSVtest/teams.csv"); .. }catch(Exception e){ Console.WriteLine("An error occured reading the teams file: " + e); }
        