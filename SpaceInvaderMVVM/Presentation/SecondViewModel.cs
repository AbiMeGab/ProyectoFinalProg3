using SpaceInvaderMVVM.Game.Entities;

namespace SpaceInvaderMVVM.Presentation;

public partial class  SecondViewModel : ObservableObject
{
    private Score _score;

    public Score Score
    {
        get => _score;
        set => SetProperty(ref _score, value);
    }

    public SecondViewModel(Score score)
    {
        Score = score;
    }
}
