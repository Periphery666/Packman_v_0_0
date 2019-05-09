using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    struct Player
    {
        public int level;
        public int posX;
        public int posY;
       // public  string NamePlayer;
        public uint score;
        public MapValue mv;
        public Status st;
        public VectorMove vec;
        public ConsoleColor cc;

        public MapValue actualMapValue;
        public Status actualStatus;

        public void InitPlayer()
        {
            vec = VectorMove.NoDirection;
            mv = MapValue.Player;
            st = Status.Player;
            cc = ConsoleColor.Green;
        }

    }
}
