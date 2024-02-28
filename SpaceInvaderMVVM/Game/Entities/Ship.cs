using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaderMVVM.Game.Entities;
public class Ship : ObservableObject
{

    private string _imagePath = "ms-appx:///SpaceInvaderMVVM/Assets/ship.png";

    private double _width = 42;
    private double _height = 42;
    private readonly double _speed = 10;
    private double _x;
    private double _y;

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

    public string ImagePath => _imagePath;


    public Ship(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void MoveRight()
    {
        if (X + _speed + Width < GameBoard.Width)

        X += _speed;
    }

    public void MoveLeft()
    {
        if(X - _speed > 0)
        X -= _speed;
    }


}
