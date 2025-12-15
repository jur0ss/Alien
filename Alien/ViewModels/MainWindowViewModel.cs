using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            MainCharacters = new List<string> { "Ellen Ripley", "Dallas", "Ash", "Lambert", "Kane" },
            Ship = "USCSS Nostromo",
            Description = "Załoga statku handlowego Nostromo odbiera sygnał z nieznanej planety.",
            FunFact = "Scena z „wyskakującym potworem” z klatki piersiowej aktora była niespodzianką dla obsady."
        }
    };
    
    private MovieModel _selectedMovie;
    public MovieModel SelectedMovie
    {
        get => _selectedMovie;
        set => this.RaiseAndSetIfChanged(ref _selectedMovie, value);
    }

    public MovieModel NewMovie { get; set; } = new MovieModel();


    public string MainCharactersText { get; set; } = "";


    public ReactiveCommand<Unit, Unit> ShowDetailsCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteMovieCommand { get; }
    public ReactiveCommand<Unit, Unit> AddMovieCommand { get; }


    public MainWindowViewModel()
    {

        var canModifySelected = this
            .WhenAnyValue(x => x.SelectedMovie)
            .Select(movie => movie != null);


        ShowDetailsCommand = ReactiveCommand.Create(ShowDetails, canModifySelected);


        DeleteMovieCommand = ReactiveCommand.Create(DeleteMovie, canModifySelected);


        AddMovieCommand = ReactiveCommand.Create(() =>
        {

            NewMovie.MainCharacters = MainCharactersText
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToList();
            
            Movies.Add(NewMovie);
            
            NewMovie = new MovieModel();
            MainCharactersText = "";
        });
    }


    private void ShowDetails()
    {
        if (SelectedMovie != null)
        {
            Console.WriteLine($"{SelectedMovie.OriginalTitle} - {SelectedMovie.PolishTitle}");
        }
    }
    
    private void DeleteMovie()
    {
        if (SelectedMovie != null)
            Movies.Remove(SelectedMovie);
    }
}