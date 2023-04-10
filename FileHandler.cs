using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class FileHandler{

    private Team checkTeam = new Team();
    public Random rng = new Random(); 
    public List<Team> readTeamsFromCSV(){
        
        List<Team> teamsToReturn = new List<Team>();

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
          Delimiter = ",",
          HasHeaderRecord = true,
          HeaderValidated = null,
          MissingFieldFound = null,
        };
        var reader = new StreamReader("CSVtest/teams.csv");
        var csv = new CsvReader(reader, configuration);
        {
          
            var teams = csv.GetRecords<Team>();
            
            for(int i = 0; i < 12; i++){
                
                Team test = teams.ElementAt(0);
                teamsToReturn.Add(test);   
                // Console.WriteLine(teamsToReturn[i].ToString());
            }
            
        }
        return teamsToReturn;
    }

    public List<Team> updateResultsForRounds(int roundNumber){

        List<Team> teamsToReturn = this.readTeamsFromCSV();
        List<Result> updateResultsFromList = new List<Result>();


        for(int i = 1; i <= roundNumber; i++){
        
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
          Delimiter = ",",
          HasHeaderRecord = true,
          HeaderValidated = null,
          MissingFieldFound = null,
        };
        var reader = new StreamReader("CSVtest/round" + i + ".csv");
        var csv = new CsvReader(reader, configuration);
        {
          
            var results = csv.GetRecords<Result>();
            
            for(int j = 0; j < 6; j++){
                
                Result result = results.ElementAt(0);
                updateResultsFromList.Add(result);
            }
            
        }
        
        }

        for(int t = 0; t < teamsToReturn.Count; t++){

            for(int d = 0; d < updateResultsFromList.Count; d++){

                if(teamsToReturn[t].abbreviation == updateResultsFromList[d].abbreviationawayteam || teamsToReturn[t].abbreviation == updateResultsFromList[d].abbreviationhometeam){

                    checkTeam.UpdateResults(updateResultsFromList[d], teamsToReturn[t]);
                  //  Console.WriteLine(t + " " + d);
                  //  Console.WriteLine(checkTeam.UpdateResults(updateResultsFromList[d], teamsToReturn[t]).ToString());
                  //  teamsToReturn.Insert(t, checkTeam.UpdateResults(updateResultsFromList[d], teamsToReturn[t]));
                  //  teamsToReturn.Insert(t, checkTeam.UpdateResults(updateResultsFromList[d], teamsToReturn[t]));
                    
                }


            }

        }
        // Console.WriteLine(teamsToReturn[0].ToString());
        for(int v = 0; v < teamsToReturn.Count; v++){
            checkTeam.calculateGoalDifference(teamsToReturn[v]);
        }    


        return teamsToReturn;
    }

    public Setup readSetupFromCSV(){
        
        Setup setup = new Setup();

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
          Delimiter = ",",
          HasHeaderRecord = true,
        };
        var reader = new StreamReader("CSVtest/setup.csv");
        var csv = new CsvReader(reader, configuration);
        {
          
            var temp = csv.GetRecords<Setup>();
            setup = temp.ElementAt(0);
        }
        
        
        return setup;
    }

    public void createRounds(int roundNumber){

        List<Team> teams = readTeamsFromCSV();
        
        for(int i = 0; i < roundNumber; i++){
        
        List<Result> results = new List<Result>();
        
        teams = shuffle(teams);

        for(int j = 0; j < 6; j++){
          Result tempResult = new Result();

          tempResult.abbreviationawayteam = teams[j].abbreviation;
          tempResult.abbreviationhometeam = teams[j + 6].abbreviation;
          tempResult.awaygoals = rng.Next(0, 4);
          tempResult.homegoals = rng.Next(0, 4);
          tempResult.pointsaway = 1;
          tempResult.pointshome = 1;
               if(tempResult.homegoals > tempResult.awaygoals){
                  tempResult.pointshome = 3;
                   tempResult.pointsaway = 0;
               }
               if(tempResult.awaygoals > tempResult.homegoals){
                   tempResult.pointshome = 0;
                   tempResult.pointsaway = 3;
               }
          results.Add(tempResult);
          
        }

        string fileName = "CSVtest/round" + (i + 1) + ".csv";
        var writer = new StreamWriter(fileName);
        var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        
        csv.WriteRecords(results);
        
        writer.Close();
        }
    }
    public List<Team> shuffle(List<Team> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
        n--;  
        int k = rng.Next(n + 1);  
        Team tempTeam = list[k];  
        list[k] = list[n];  
        list[n] = tempTeam;  
        }  
        return list;
    }
    
    public void deleteFiles(int rounds = 33){

        for(int i = 0; i < rounds; i++){
           string path =  "CSVtest/round" + (i + 1) + ".csv";
            File.Delete(path);
        }

    }
}