using System;

class Program{

public static void Main(string[] args){

    FileHandler fileHandler = new FileHandler();
    List<Team> teams = new List<Team>();
    Console.WriteLine("Program is running");
    
    string setup = fileHandler.readSetupFromCSV();
    Console.WriteLine(setup);
    teams = fileHandler.updateResultsForRounds(0);
    teams.Sort((t2, t1)=>{

        int result = t1.points.CompareTo(t2.points);
        return result == 0 ? (t1.gFor - t1.gAgainst).CompareTo(t2.gFor - t2.gAgainst) : result == 0 ? t1.abbreviation.CompareTo(t2.abbreviation) : result;

    });
    for(int g = 0; g < teams.Count; g++){
        Console.WriteLine(teams[g].ToString());
        }
    }

}
