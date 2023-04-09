using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
 
class FileHandler{

    private Team checkTeam = new Team();
    
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

    public string readSetupFromCSV(){
        
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
        string returnSetup = setup.ToString();
        
        return returnSetup;
    }
}