using CsvHelper.Configuration.Attributes;

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
}