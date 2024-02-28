using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaderMVVM.Game.Entities;
public class Score
{
    public int Value { get; set; }


    public Score(int value)
    {
        Value = value;
    }
}
