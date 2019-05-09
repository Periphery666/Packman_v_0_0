using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    struct Logics
    {

        public static bool endGame = false;

      

        public static VectorMove Move(ConsoleKey ck)
        {
            VectorMove vm = VectorMove.NoDirection;
            switch (ck)
            {
                case ConsoleKey.W:
                    vm = VectorMove.Up;
                    break;

                case ConsoleKey.S:
                    vm = VectorMove.Down;
                    break;

                case ConsoleKey.A:
                    vm = VectorMove.Left;
                    break;

                case ConsoleKey.D:
                    vm = VectorMove.Right;
                    break;

                default:
                    break;
            }
            return vm;
        }



        public static void ChangeVec(ref Player pl)
        {
            switch (pl.vec)
            {
                case VectorMove.Up:
                    CheckStatusTile(ref pl, - 1);
                    break;

                case VectorMove.Down:
                    CheckStatusTile(ref pl, 1);
                    break;

                case VectorMove.Left:
                    CheckStatusTile(ref pl, 0,-1);
                    break;

                case VectorMove.Right:
                    CheckStatusTile(ref pl, 0,1);
                    break;

                default:
                    break;
            }
        }



        public static void CheckStatusTile(ref Player pl , int posX = 0, int posY = 0)
        {

            if (Map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Wall)
            {
                return;
            }


            if (Map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Enemy)
            {
                Logics.endGame = true;
                return;
            }


            if (Map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Food)
            {
                ClearFirstPosition(ref pl);

                pl.score += 100;
                ChangePosXY(ref pl, posX, posY);
            }


            if (Map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.NoDirection)
            {
                ClearFirstPosition(ref pl);
                ChangePosXY(ref pl, posX, posY);
            }

            Map.map[pl.posX, pl.posY].mapValue = pl.mv;
            Map.map[pl.posX, pl.posY].statusTile = pl.st;

            Console.SetCursorPosition(pl.posY, pl.posX);
            Console.Write((char)Map.map[pl.posX, pl.posY].mapValue);
        }



        public static void ChangePosXY(ref Player pl, int posX, int posY)
        {
            pl.posX += posX;
            pl.posY += posY;
        }



        public static void ClearFirstPosition(ref Player pl, Status s = Status.NoDirection, MapValue mv = MapValue.NoDirection)
        {
            pl.actualStatus = s;
            pl.actualMapValue = mv;

            Map.map[pl.posX, pl.posY].statusTile = s;
            Map.map[pl.posX, pl.posY].mapValue = mv;

            Map.ChangeColor(Map.map[pl.posX, pl.posY].cc);

            Console.SetCursorPosition(pl.posY, pl.posX);
            Console.Write((char)Map.map[pl.posX, pl.posY].mapValue);
            Map.ChangeColor(pl.cc);


        }



        public static void ChangeVec(ref Enemy pl)
        {

            switch (pl.vec)
            {
                case VectorMove.Up:
                    CheckStatusTile(ref pl, -1);
                    break;

                case VectorMove.Down:
                    CheckStatusTile(ref pl, 1);
                    break;

                case VectorMove.Left:
                    CheckStatusTile(ref pl, 0, -1);
                    break;

                case VectorMove.Right:
                    CheckStatusTile(ref pl, 0, 1);
                    break;

                default:
                    break;
            }

        }


        public static void CheckStatusTile(ref Enemy pl, int posX = 0, int posY = 0)
        {

            if (Map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Wall)
            {
                return;
            }

            if (Map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Enemy && pl.st != Status.Enemy)
            {
                Logics.endGame = true;
                return;
            }

            if (Map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Food )
            {
                ClearFirstPosition(ref pl, Status.Food, MapValue.Food);

                //pl.score += 100;     // для игрока
                ChangePosXY(ref pl, posX, posY);
            }

            if (Map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.NoDirection )
            {

                ClearFirstPosition(ref pl);
                ChangePosXY(ref pl, posX, posY);

            }

            Map.map[pl.posX, pl.posY].mapValue = pl.mv;
            Map.map[pl.posX, pl.posY].statusTile = pl.st;

            Console.SetCursorPosition(pl.posY, pl.posX);
            Console.Write((char)Map.map[pl.posX, pl.posY].mapValue);
        }



        public static void ChangePosXY(ref Enemy pl, int posX, int posY)
        {
            pl.posX += posX;
            pl.posY += posY;
        }



        public static void ClearFirstPosition(ref Enemy pl , Status s = Status.NoDirection , MapValue mv = MapValue.NoDirection)
        {
            pl.actualStatus = s;
            pl.actualMapValue = mv;

            Map.map[pl.posX, pl.posY].statusTile = s;     
            Map.map[pl.posX, pl.posY].mapValue =  mv;     


            Map.ChangeColor(Map.map[pl.posX, pl.posY].cc);

            Console.SetCursorPosition(pl.posY, pl.posX);
            Console.Write((char)Map.map[pl.posX, pl.posY].mapValue);
            Map.ChangeColor(pl.cc);

        }






    }
}
