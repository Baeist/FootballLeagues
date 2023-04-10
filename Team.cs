using CsvHelper.Configuration.Attributes;
using CsvHelper;

class Team{
    
    public string abbreviation {get; set;} = "unknown";
   
    public string name {get; set;} = "unknown";
   
    public string specialStatus {get; set;} = "unknown";
    public int matches {get; set;} = 0;
    public int wonM {get; set;} = 0;
    public int drawM {get; set;} = 0;
    public int lostM {get; set;} = 0;
    public int gFor {get; set;} = 0;
    public int gAgainst {get; set;} = 0;
    public int points {get; set;} = 0;
    public int goalDifference {get; set;} = 0;

     public Team UpdateResults(Result result, Team team){

        if(result.abbreviationawayteam == team.abbreviation){

            team.gAgainst = team.gAgainst + result.homegoals;
            team.gFor = team.gFor + result.awaygoals;

            if(result.homegoals > result.awaygoals){
                team.lostM = team.lostM + 1;
            }else if(result.homegoals < result.awaygoals){
                team.wonM = team.wonM + 1;
                team.points = team.points + 3;
            }else if(result.awaygoals == result.homegoals){
                team.drawM = team.drawM + 1;
                team.points = team.points + 1;
            }

        }else if(result.abbreviationhometeam == team.abbreviation){

            team.gAgainst = team.gAgainst + result.awaygoals;
            team.gFor = team.gFor + result.homegoals;

            if(result.awaygoals > result.homegoals){
                team.lostM = team.lostM + 1;
            }else if(result.awaygoals < result.homegoals){
                team.wonM = team.wonM + 1;
                team.points = team.points + 3;
            }else if(result.homegoals == result.awaygoals){
                team.drawM = team.drawM + 1;
                team.points = team.points + 1;
            }

        }else{
            return team;
        }    
        team.matches = team.matches + 1;
        
        return team;
     }   

     public void calculateGoalDifference(Team team){
        team.goalDifference = team.gFor - team.gAgainst;
     }   

     public override string ToString(){
        
        string status = "";

        if(specialStatus != "N"){
        status = String.Format("{0,-3}({1,1}) {2,-2} {3,-2} {4,-2} {5,-2} +{6,-3} -{7,-3} {8,-3}", abbreviation, specialStatus, matches, wonM, drawM, lostM, gFor, gAgainst, points);
        }
        else{
        status = String.Format("{0,-6} {1,-2} {2,-2} {3,-2} {4,-2} +{5,-3} -{6,-3} {7,-3}", abbreviation, matches, wonM, drawM, lostM, gFor, gAgainst, points);    
        }
        return status;
     }

     public List<Team> sortTeams(List<Team> teams){

        List<Team> sortedTeams = new List<Team>();

        var enumerableTeams = teams.OrderBy(teams => teams.points).ThenBy(teams => teams.goalDifference).ThenBy(teams => teams.abbreviation); 
    
        for(int i = 0; i < 12; i++){

        Team tempTeam = enumerableTeams.ElementAt(i);
       
        sortedTeams.Insert(0, tempTeam);
    }

        return sortedTeams;
     }

     public void printTable(List<Team> sortedTeams){
        FileHandler fileHandler = new FileHandler();
        Setup setup = fileHandler.readSetupFromCSV();

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
