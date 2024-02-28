using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;

namespace SpaceInvaderMVVM.Game.Entities;
public class Enemy : ObservableObject
{
    private readonly int _value;

    private double _width = 48;
    private double _height = 48;
    private readonly string _imagePath;
    private double _speed = 10;
    private double _x;
    private double _y;
    private Direction _direction;
    private UIElement _image;

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

    public int Value => _value;


    public Enemy(double x, double y, string imagePath, int value)
    {
        X = x;
        Y = y;
        _value = value;

        _image = new Image
        {
            Source = new BitmapImage(new Uri(imagePath)),
            Width = _width,
            Height = _height
        };

        _imagePath = imagePath;
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
            case Direction.Down:
                Speed += 0.05;
                Y += _speed;
                break;
        }


        Canvas.SetLeft(_image, X);
        Canvas.SetTop(_image, Y);
    }

    public void SetDirection(Direction direction)
    {
        _direction = direction;
    }

    public void UpdateSpeed(double speed)
    {
        _speed = speed;
    }

    public void Destroy(Canvas ctx)
    {
        ctx.Children.Remove(_image);
        Image = null;
    }

}
