using Microsoft.Extensions.Localization;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Input;
using SpaceInvaderMVVM.Game;
using SpaceInvaderMVVM.Game.Entities;
using Windows.System;

namespace SpaceInvaderMVVM.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;

    [ObservableProperty]
    private string? name;
    private Canvas _ctx;
    public Ship Ship { get; } = new Ship(GameBoard.Width / 2, GameBoard.Height - 120);
    public ScoreHandler ScoreHandler { get; } = new ScoreHandler();
    public LifesHandler LifesHandler { get; } = new LifesHandler();
    public GameOverHandler GameOverHandler { get; } = new GameOverHandler();

    private Projectile Projectile;
    private Wave _wave;

    public double Width
    {
        get => GameBoard.Width;
    }
    public double Height
    {
        get => GameBoard.Height;
    }
    public double PlayerWidth
    {
        get => GameBoard.PlayerWidth;
    }

    public double PlayerHeight
    {
        get => GameBoard.PlayerHeight;
    }


    public MainViewModel(
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Space Invaders";
    }

    public string? Title { get; }
    public ICommand GoToSecond { get; }

    private DispatcherTimer _timer;

    public void InitGame(Canvas ctx)
    {
        _ctx = ctx;
        Projectile = new(0, 0, "ms-appx:///SpaceInvaderMVVM/Assets/Projectile.png", Direction.Up);
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1000 / 60)
        };

        Projectile.CollisionWithEnemy += ScoreHandler.OnEnemyCollision;
        ScoreHandler.ScoreChanged += LifesHandler.OnChangeScore;
        GameOverHandler.GameOverEvt += OnGameOverStopGame;

        _wave = new Wave(_ctx);
        GameLoop(_ctx);
    }


    public void GameLoop(Canvas ctx)
    {
        _timer.Tick += (s, e) =>
        {
            _wave.Move(ctx);
            Projectile?.Update(ctx);
            Projectile?.CheckCollisionWithEnmies(_wave.Enemies, ctx);
            GameOverHandler.CheckGameOver(_wave.Enemies, Ship);
        };
        _timer.Start();
    }

    public void OnGameOverStopGame()
    {
        _timer.Stop();
    }

    public void OnEventKeyDown(KeyRoutedEventArgs e)
    {

        switch (e.Key)
        {
            case VirtualKey.Left:
                Ship.MoveLeft();
                break;
            case VirtualKey.Right:
                Ship.MoveRight();
                break;
            case VirtualKey.Up:
                Projectile.Fire(Ship.X + Ship.Width / 2, Ship.Y, _ctx);
                break;
            case VirtualKey.Space:
                Projectile.Fire(Ship.X + Ship.Width / 2, Ship.Y, _ctx);
                break;

        }

    }

}
