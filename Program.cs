using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program{

public static void Main(string[] args){

    // configure the number of rounds, round data will generate automatically and old data will delete up to a default of 33 rounds
    // setup and teams needs to be done manually
       
    int rounds = 3; // Configure this number

    FileHandler fileHandler = new FileHandler();
    Team team = new Team();
    List<Team> teams = new List<Team>();
    List<Team> sortedTeams = new List<Team>();

    Console.WriteLine("Program is running");

    fileHandler.deleteFiles(); // insert any number as argument here to delete up to any number of round files

    Setup setup = fileHandler.readSetupFromCSV();
    string writeSetup = setup.ToString();
    
    Console.WriteLine(writeSetup);

    fileHandler.createRounds(rounds);
    teams = fileHandler.updateResultsForRounds(rounds);
    
    sortedTeams = team.sortTeams(teams);
    
    team.printTable(sortedTeams);
    }
}
