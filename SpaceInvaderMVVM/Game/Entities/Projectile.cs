using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;

namespace SpaceInvaderMVVM.Game.Entities;
internal class Projectile : Entity
{
    private bool _isAlive = false;
    public delegate void CollisionWithEnemyHandler(Enemy enemy);
    public event CollisionWithEnemyHandler CollisionWithEnemy;

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }

    public Projectile(double x, double y, string imagePath, Direction direction) : base(x, y, imagePath)
    {
        Direction = direction;
        Width = 2;
        Height = 24;

    }

    public void CheckCollisionWithEnmies(List<Enemy> enemies, Canvas ctx)
    {
        if(!_isAlive) return;

        foreach (var enemy in enemies)
        {
            if (X < enemy.X + enemy.Width &&
                X + Width > enemy.X &&
                Y < enemy.Y + enemy.Height &&
                Y + Height > enemy.Y)
            {
                enemy.Destroy(ctx);
                CollisionWithEnemy?.Invoke(enemy);
                ctx.Children.Remove(Image);
                _isAlive = false;
                return;
            }
        }
    }

    public void Update(Canvas ctx)
    {
        if(!_isAlive) return;

        Move(Direction);

        if (Y < 0 || Y > GameBoard.Height)
        {
            ctx.Children.Remove(Image);
            _isAlive = false;
            Image = null;
            return;
        }

        Canvas.SetLeft(Image, X);
        Canvas.SetTop(Image, Y);
    }

    public void Fire(double x, double y, Canvas ctx)
    {
        if (_isAlive) return;
        X = x;
        Y = y;
        Image = new Image
        {
            Source = new BitmapImage(new Uri(_imagePath)),
            Width = _width,
            Height = _height
        };

        Canvas.SetLeft(Image, X);
        Canvas.SetTop(Image, Y);

        ctx.Children.Add(Image);
        _isAlive = true;
    }

}
