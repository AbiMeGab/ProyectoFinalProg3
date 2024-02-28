using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaderMVVM.Game;
public class LifesHandler : ObservableObject
{
    private readonly int MAX_LIFES = 6;
    private readonly int POINTS_TO_ADD_LIFE = 100;
    private int acommulatedPoints = 0;

    private ObservableCollection<int> _lifes = [1, 1, 1];

    public ObservableCollection<int> Lifes
    {
        get => _lifes;
        set => SetProperty(ref _lifes, value);
    }

    public void OnPlayerCollision()
    {
        Lifes.Clear();
    }

    public void OnChangeScore(int value)
    {

        acommulatedPoints += value;
        if (acommulatedPoints >= POINTS_TO_ADD_LIFE)
        {
            acommulatedPoints = 0;
            if (Lifes.Count < MAX_LIFES)
            {
                Lifes.Add(1);
            }
        }

    }
}
