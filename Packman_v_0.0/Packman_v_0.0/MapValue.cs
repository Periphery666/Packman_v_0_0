using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    enum MapValue : int
    {
        NoDirection = ' ',
        LeftUpCorner = 0x2554,
        RightUpCorner = 0x2557,
        LeftDownCorner = 0x255A,
        RightDownpCorner = 0x255D,
        VerticaltWall = 0x2551,
        GorizontWall = 0x2550,

        Food = 0x00A4,
        Player = 0x007E,
        Enemy = '†'

    }

    enum Status
    {
        NoDirection = 0x00,
        Food = 0x01,
        Wall = 0x02,
        Player = 0x03,
        Enemy = 0x04
    }


    enum VectorMove
    {
        NoDirection,
        Up,
        Down,
        Left,
        Right

    }


    enum Prioritet
    {
        NoDirection,
        VectorRandom,
        VectorMove,
        VectorSee
    }






}
