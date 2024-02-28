using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;

namespace SpaceInvaderMVVM.Game.Entities;
public abstract class Entity : ObservableObject
{
    protected double _width = 64;
    protected double _height = 64;
    protected readonly string _imagePath;
    protected double _speed = 10;
    protected double _x;
    protected double _y;
    protected Direction _direction;
    protected UIElement _image;

    public Entity(double x, double y, string imagePath)
    {
        X = x;
        Y = y;

        _image = new Image
        {
            Source = new BitmapImage(new Uri(imagePath)),
            Width = _width,
            Height = _height
        };
        _imagePath = imagePath;
    }

    public double X
    {
        get => _x;
        set => SetProperty(ref _x, value);
    }

    public double Y
    {
        get => _y;
        set => SetProperty(ref _y, value);
    }

    public double Width
    {
        get => _width;
        set => SetProperty(ref _width, value);
    }

    public double Height
    {
        get => _height;
        set => SetProperty(ref _height, value);
    }

    public Direction Direction
    {
        get => _direction;
        set => SetProperty(ref _direction, value);
    }

    public UIElement Image
    {
        get => _image;
        set => SetProperty(ref _image, value);
    }

    public double Speed
    {
        get => _speed;
        set => SetProperty(ref _speed, value);
    }

    public void SetSpeed(double speed)
    {
        Speed = speed;
    }



    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                X -= _speed;
                break;
            case Direction.Right:
                X += _speed;
                break;
            case Direction.Up:
                Y -= _speed;
                break;
            case Direction.Down:
                Y += _speed;
                break;
        }
    }

}
