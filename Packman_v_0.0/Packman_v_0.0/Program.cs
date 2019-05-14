using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Packman_v_0._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Player pl = new Player();
            pl.level = Game.SetLevelGame();

            Map map = new Map();
            Game.CreateMap(ref map);
            pl.InitPlayer();

            Initializer.SetPlayers(ref pl,ref map);
            Enemy.level = pl.level;

            Initializer.InitMap(ref map);
            Randomaizer.RandomBlock(ref map);


            Enemy[] enVec = Enemy.CreateEnemy(Enemy.level);
            Initializer.InitVecEnemy(enVec,ref map);

            pl.vec = VectorMove.NoDirection;

            Game.Print(map);

            while (!Logics.endGame)
            {
                if (Console.KeyAvailable)
                {
                    pl.vec = Logics.Move(Game.GetMove());
                    Logics.ChangeVec(ref pl, ref map);

                }

                Enemy.InitVecEnemy(enVec, ref map);


                System.Threading.Thread.Sleep(200);
            }


        }

    }
}
