using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaderMVVM.Game.Entities;

namespace SpaceInvaderMVVM.Game;
public class GameOverHandler
{
    public delegate void GameOverHanlderEvt();
    public event GameOverHanlderEvt GameOverEvt;

    public void CheckGameOver(List<Enemy> enemis, Ship ship)
    {
        // Check if the ship is colliding with any of the enemies

        foreach (var enemy in enemis)
        {

            if (ship.X < enemy.X + enemy.Width &&
                ship.X + ship.Width > enemy.X &&
                ship.Y < enemy.Y + enemy.Height &&
                ship.Y + ship.Height > enemy.Y
                )
            {
                GameOverEvt?.Invoke();
            }

        }

    }

}
