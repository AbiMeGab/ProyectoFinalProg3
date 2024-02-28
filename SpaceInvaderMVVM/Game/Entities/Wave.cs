using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaderMVVM.Game.Entities;
internal class Wave
{

    private readonly List<Enemy> _enemies = [];
    public List<Enemy> Enemies => _enemies;
    private readonly Canvas _ctx;
    private Direction _direction = Direction.Right;
    private int _speed = 1000;

    public Wave(Canvas ctx)
    {
        GenerateWave();
        _ctx = ctx;
        Draw(_ctx);
    }

    public void GenerateWave()
    {
        var initialY = 100;


        for (int i = 0; i < 10; i++)
        {
            _enemies.Add(new Enemy(i * 64, initialY, "ms-appx:///SpaceInvaderMVVM/Assets/enemy40pts.png", 10));
        }

        // add 2nd row for each enemy

        for (int i = 0; i < 10; i++)
        {
            _enemies.Add(new Enemy(i * 64, initialY + 64, "ms-appx:///SpaceInvaderMVVM/Assets/enemy20pts.png", 20));
        }

        // add 3rd row for each enemy

        for (int i = 0; i < 10; i++)
        {
            _enemies.Add(new Enemy(i * 64, initialY + 128, "ms-appx:///SpaceInvaderMVVM/Assets/enemy10pts.png", 30));
        }

    }


    public void Move(Canvas cavnas)
    {
        CheckNullEnemies();
        foreach (var enemy in _enemies)
        {
            enemy.Move(_direction);
        }
        CheckIfAtEdge();
        CheckNewWave();
    }

    public void Draw(Canvas canvas)
    {
        foreach (var enemy in _enemies)
        {
            canvas.Children.Add(enemy.Image);
        }
    }


    // Verificar si los enemigos tiene un _image diferente de null
    public void CheckNullEnemies()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].Image == null)
                _enemies.RemoveAt(i);
        }
    }


    public void CheckNewWave()
    {
        if (_enemies.Count == 0)
        {
            GenerateWave();
            Draw(_ctx);
            UpdateSpeed();
        }
    }

    public void CheckIfAtEdge()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.X + enemy.Width + enemy.Speed > GameBoard.Width)
            {
                _direction = Direction.Left;
                foreach (var e in _enemies)
                    e.Move(Direction.Down);
                return;
            }
            if (enemy.X - enemy.Speed < 0)
            {
                _direction = Direction.Right;
                foreach (var e in _enemies)
                    e.Move(Direction.Down);
                return;
            }
        }
    }

    public void UpdateSpeed()
    {
        if (Enemies.Count == 0) return;

        for (int i = 0; i < _enemies.Count; i++)
            _enemies[i].UpdateSpeed(_speed);
    }



}
