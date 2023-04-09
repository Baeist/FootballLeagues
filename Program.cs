using System;

class Program{

public static void Main(string[] args){

    // choose number of rounds here
    int rounds = 2;


    FileHandler fileHandler = new FileHandler();
    List<Team> teams = new List<Team>();
    List<Team> sortedTeams = new List<Team>();
    Console.WriteLine("Program is running");
    
    string setup = fileHandler.readSetupFromCSV();
    Console.WriteLine(setup);
    teams = fileHandler.updateResultsForRounds(rounds);
    
    var enumerableTeams = teams.OrderBy(teams => teams.points).ThenBy(teams => teams.goalDifference).ThenBy(teams => teams.abbreviation); 
    
    for(int i = 0; i < 12; i++){

        Team team = enumerableTeams.ElementAt(i);
       
        sortedTeams.Insert(0, team);
    }
    
    for(int g = 0; g < sortedTeams.Count; g++){
        Console.WriteLine(sortedTeams[g].ToString());
        }
    }

}
