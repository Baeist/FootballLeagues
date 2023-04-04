using CsvHelper.Configuration.Attributes;

class Setup{

    public string LeagueName {get; set;} = "unknown";
    public int CL {get; set;} = 0;
    public int EL {get; set;} = 0;
    public int CONF {get; set;} = 0;
    public int Promotion {get; set;} = 0;
    public int Relegation {get; set;} = 0;


    public override string ToString()
    {
        string description = LeagueName;

        if(CL != 0){
            description = description + " CL: " + CL;
        }
        if(EL != 0){
            description = description + " EL: " + EL;
        }
        if(CONF != 0){
            description = description + " Conference League: " + CONF;
        }
        if(Promotion != 0){
            description = description + " Promotion: " + Promotion;
        }
        if(Relegation != 0){
            description = description + " Relegation: " + Relegation;
        }
        return description;
    }
}