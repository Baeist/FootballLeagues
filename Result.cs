using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Result{

[Index(0)]
public string abbreviationhometeam {get; set;} = "unknown";
[Index(1)]
public string abbreviationawayteam {get; set;} = "unknown";
[Index(2)]
public int homegoals {get; set;} = 0;
[Index(3)]
public int awaygoals {get; set;} = 0;
[Index(4)]
public int pointshome {get; set;} = 0;
[Index(5)]
public int pointsaway {get; set;} = 0;




}