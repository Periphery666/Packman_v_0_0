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



        public static void ChangeVec( ref Player pl,ref Map map)
        {
            switch (pl.vec)
            {
                case VectorMove.Up:
                    CheckStatusTile(ref map,ref pl, - 1);
                    break;

                case VectorMove.Down:
                    CheckStatusTile(ref map, ref pl, 1);
                    break;

                case VectorMove.Left:
                    CheckStatusTile(ref map, ref pl, 0,-1);
                    break;

                case VectorMove.Right:
                    CheckStatusTile(ref map, ref pl, 0,1);
                    break;

                default:
                    break;
            }
        }




        public static void SetVector(ref Map map, ref Enemy en1, ref VectorMove[] vm)
        {

            if (en1.p == Prioritet.VectorRandom)
            {
                AI.FindPlayerVector(map, ref vm, en1.posX, en1.posY, ref en1.findVector, Enemy.level);

                if (en1.findVector)
                {
                    en1.p = Prioritet.VectorMove;
                }
            }

            if (en1.findVector)
            {
                en1.p = Prioritet.VectorMove;
            }
            else
            {
                en1.findSee = AI.FindPlayerSee(map, ref vm, en1);

                if (en1.findSee)
                {
                    en1.p = Prioritet.VectorSee;

                }
            }

            if (vm != null && en1.countStep == vm.Length)
            {
                en1.countStep = 0;
                en1.p = Prioritet.VectorRandom;
                en1.findVector = false;
                vm = null;
            }
        }


        public static void CheckStatusTile(ref Map map, ref Player pl , int posX = 0, int posY = 0)
        {

            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Wall)
            {
                return;
            }

            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Enemy)
            {
                Logics.endGame = true;
                return;
            }

            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Food)
            {
                ClearFirstPosition(ref map ,ref pl);
                pl.score += 100;
                ChangePosXY(ref pl, posX, posY);
            }

            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.NoDirection)
            {
                ClearFirstPosition(ref map, ref pl);
                ChangePosXY(ref pl, posX, posY);
            }

            map.map[pl.posX, pl.posY].mapValue = pl.mv;
            map.map[pl.posX, pl.posY].statusTile = pl.st;

            Console.SetCursorPosition(pl.posY, pl.posX);
            Console.Write((char)map.map[pl.posX, pl.posY].mapValue);
        }



        public static void ChangePosXY(ref Player pl, int posX, int posY)
        {
            pl.posX += posX;
            pl.posY += posY;
        }



        public static void ClearFirstPosition(ref Map map, ref Player pl, Status s = Status.NoDirection, MapValue mv = MapValue.NoDirection)
        {
            pl.actualStatus = s;
            pl.actualMapValue = mv;

            map.map[pl.posX, pl.posY].statusTile = s;
            map.map[pl.posX, pl.posY].mapValue = mv;

            Console.ForegroundColor = map.map[pl.posX, pl.posY].cc;


            Console.SetCursorPosition(pl.posY, pl.posX);
            Console.Write((char)map.map[pl.posX, pl.posY].mapValue);

            Console.ForegroundColor = pl.cc;


        }



        public static void ChangeVec(ref Enemy pl, ref Map map)
        {

            switch (pl.vec)
            {
                case VectorMove.Up:
                    CheckStatusTile(ref map,ref pl, -1);
                    break;

                case VectorMove.Down:
                    CheckStatusTile(ref map, ref pl, 1);
                    break;

                case VectorMove.Left:
                    CheckStatusTile(ref map, ref pl, 0, -1);
                    break;

                case VectorMove.Right:
                    CheckStatusTile(ref map, ref pl, 0, 1);
                    break;

                default:
                    break;
            }

        }


        public static void CheckStatusTile(ref Map map, ref Enemy pl, int posX = 0, int posY = 0)
        {

            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Wall)
            {
                return;
            }
            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Player )
            {
                Logics.endGame = true;
                return;
            }

            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Enemy && pl.st != Status.Enemy)
            {
                Logics.endGame = true;
                return;
            }

            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.Food )
            {
                ClearFirstPosition(ref map, ref pl, Status.Food, MapValue.Food);
                ChangePosXY(ref pl, posX, posY);
            }

            if (map.map[pl.posX + posX, pl.posY + posY].statusTile == Status.NoDirection )
            {
                ClearFirstPosition(ref map, ref pl);
                ChangePosXY(ref pl, posX, posY);
            }

            map.map[pl.posX, pl.posY].mapValue = pl.mv;
            map.map[pl.posX, pl.posY].statusTile = pl.st;

            Console.SetCursorPosition(pl.posY, pl.posX);
            Console.Write((char)map.map[pl.posX, pl.posY].mapValue);
        }



        public static void ChangePosXY(ref Enemy pl, int posX, int posY)
        {
            pl.posX += posX;
            pl.posY += posY;
        }



        public static void ClearFirstPosition(ref Map map, ref Enemy pl,  Status s = Status.NoDirection , MapValue mv = MapValue.NoDirection)
        {
            pl.actualStatus = s;
            pl.actualMapValue = mv;

            map.map[pl.posX, pl.posY].statusTile = s;
            map.map[pl.posX, pl.posY].mapValue =  mv;     


            Console.ForegroundColor = pl.Actualcc;

            Console.SetCursorPosition(pl.posY, pl.posX);
            Console.Write((char)map.map[pl.posX, pl.posY].mapValue);

            Console.ForegroundColor = pl.cc;


        }



        public static void ChoiceVector(ref Enemy en, VectorMove[] vm, ref int countStep)
        {
            switch (en.p)
            {
                case Prioritet.VectorRandom:
                    en.vec = AI.Move();
                    break;

                case Prioritet.VectorMove:
                    en.vec = vm[countStep++];
                    break;

                case Prioritet.VectorSee:
                    en.vec = vm[countStep++];

                    break;
                default:
                    break;
            }
        }



    }
}
