using System;

class Program{

public static void Main(string[] args){

    // choose number of rounds here
    int rounds = 2;

    FileHandler fileHandler = new FileHandler();
    List<Team> teams = new List<Team>();
    List<Team> sortedTeams = new List<Team>();
    Setup setup = fileHandler.readSetupFromCSV();
    Console.WriteLine("Program is running");
    
    string writeSetup = setup.ToString();
    Console.WriteLine(writeSetup);
    teams = fileHandler.updateResultsForRounds(rounds);
    
    var enumerableTeams = teams.OrderBy(teams => teams.points).ThenBy(teams => teams.goalDifference).ThenBy(teams => teams.abbreviation); 
    
    for(int i = 0; i < 12; i++){

        Team tempTeam = enumerableTeams.ElementAt(i);
       
        sortedTeams.Insert(0, tempTeam);
    }
    
    for(int g = 0; g < sortedTeams.Count; g++){

        if(g <= (setup.EL + setup.CL + setup.CONF -1)){
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        if(g <= (setup.EL + setup.CL -1)){
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        if(g <= (setup.CL -1)){
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        if(g <= (setup.Promotion -1) && setup.Promotion > 0){
            Console.ForegroundColor = ConsoleColor.Green;
        }
        if(g >= sortedTeams.Count - setup.Relegation){
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.WriteLine(sortedTeams[g].ToString());

        Console.ForegroundColor = ConsoleColor.White;        
        }


    }

}
