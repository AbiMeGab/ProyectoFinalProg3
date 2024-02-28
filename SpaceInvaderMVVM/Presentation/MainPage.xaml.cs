using Microsoft.UI.Xaml.Input;
using SpaceInvaderMVVM.Game.Entities;
using Windows.System;

namespace SpaceInvaderMVVM.Presentation;

public sealed partial class MainPage : Page
{

    private bool InitGame = false;
    public MainPage()
    {
        InitializeComponent();
        KeyDown += OnKeyDown;
        DataContextChanged += OnDataContextChanged;
    }

    // load canvas in MVVM, when the DataContext is set
    protected void OnDataContextChanged(object sender, DataContextChangedEventArgs e)
    {
        var canvas = canvasGame;

        if (canvas != null && DataContext is MainViewModel vm)
        {
            if (!InitGame)
            {
                vm.InitGame(canvas);
                vm.GameOverHandler.GameOverEvt += OnGameOverNavigateToHighScore;
                InitGame = true;
            }
        }

    }

    public void OnKeyDown(object sender, KeyRoutedEventArgs e)
    {
        (DataContext as MainViewModel)?.OnEventKeyDown(e);
    }

    public void OnGameOverNavigateToHighScore()
    {

        var value = (DataContext as MainViewModel)?.ScoreHandler.Score;
        Score score = new((int)value);
        Frame.Navigate(typeof(SecondPage), score);
    }

}
