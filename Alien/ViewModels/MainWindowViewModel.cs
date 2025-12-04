using System.Collections.ObjectModel;
using Alien.Models;

namespace Alien.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<MovieModel> Movies { get; } = new()
    {
        new MovieModel()
        {
            OriginalTitle = "Alien",
            PolishTitle = "Obcy - ósmy pasażer Nostromo",
            Year = 1979,
            Director = "Ridley Scott",
            Writer = "Dan O'Bannon",
            Genre = "Sci-Fi / Horror",
            Length = 117,
            Rating = 8.5,
            MainCharacters = ["Ellen Ripley", "Dallas", "Ash", "Lamber", "Kane"],
            Ship = "USCSS Nostromo"
        }
    };
}