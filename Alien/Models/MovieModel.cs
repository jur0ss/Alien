using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using Avalonia.Controls;

namespace Alien.Models;

public class MovieModel
{
    public string OriginalTitle { get; set; }
    public string PolishTitle { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public string Writer { get; set; }
    public string Genre { get; set; }
    public int Length { get; set; }
    public double Rating { get; set; }
    public List<string> MainCharacters { get; set; }
    public string Ship { get; set; }
    
    public string Description { get; set; }
    public string FunFact {get; set;}
}