using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using Alien.Models;
using ReactiveUI;

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
    
    private MovieModel _selectedMovie;
    
    public MovieModel SelectedMovie {
        get => _selectedMovie;
        set => this.RaiseAndSetIfChanged(ref _selectedMovie, value);
    }
    
    public ReactiveCommand<Unit, Unit> ShowDetailsCommand { get; }

    private void ShowDetails()
    {
        if (SelectedMovie != null)
        {
            Console.WriteLine($"{SelectedMovie.OriginalTitle} - {SelectedMovie.PolishTitle}");
        }
    }

    public MainWindowViewModel()
    {
        var canShow = this
            .WhenAnyValue(x => x.SelectedMovie)
            .Select(movie => movie != null);
        
        ShowDetailsCommand = ReactiveCommand.Create(ShowDetails, canShow);
    }
    
    
}