using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaderMVVM.Game.Entities;

namespace SpaceInvaderMVVM.Game;
public class ScoreHandler : ObservableObject
{
    private int _score = 30;

    public delegate void ScoreChangedEventHandler(int score);
    public event ScoreChangedEventHandler ScoreChanged;


    public int Score
    {
        get => _score;
        set => SetProperty(ref _score, value);
    }

    public void AddScore(int value)
    {
        Score += value;
    }


    public void OnEnemyCollision(Enemy enemy)
    {
        int value = enemy.Value;
        AddScore(value);
        ScoreChanged?.Invoke(value);
    }

}

