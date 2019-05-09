using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    struct AI
    {

        public static Prioritet prior = Prioritet.NoDirection;

        private static Random rand = new Random();



        public static VectorMove Move()
        {
            return (VectorMove)rand.Next(1, 6);
        }


        public static void SetVectorMove(ref VectorMove[] vm, int size, VectorMove vector)
        {
            if (vm == null)
            {
                vm = new VectorMove[size];
            }

            vm[size - 1] = vector;
        }


        public static bool IsFindPlayer(int posX, int posY)
        {
            //if (Map.map[posX, posY].statusTile == Status.Player)
            //{
            //    return true;
            //}

            return Map.map[posX, posY].statusTile == Status.Player;
        }


        public static bool FindPlayerVector(ref VectorMove[] vm, int posX, int posY, ref bool find, int limitMax = 6, int level = 1)
        {

            if (limitMax < level)
            {
                return false;
            }



            //Up find
            if ((Map.map[posX, posY].statusTile == Status.Food || Map.map[posX, posY].statusTile == Status.NoDirection || Map.map[posX, posY].statusTile == Status.Enemy)
                 && !find)
            {
                find = IsFindPlayer(posX - 1, posY);


                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Up);
                    return find;
                }
                FindPlayerVector(ref vm, posX - 1, posY, ref find, limitMax, level + 1);
                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Up);
                    return find;
                }
            }


            // left
            if ((Map.map[posX, posY].statusTile == Status.Food || Map.map[posX, posY].statusTile == Status.NoDirection || Map.map[posX, posY].statusTile == Status.Enemy)
                && find == false)
            {

                find = IsFindPlayer(posX, posY - 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Left);
                    return find;
                }

                FindPlayerVector(ref vm, posX, posY - 1, ref find, limitMax, level + 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Left);
                    return find;
                }
            }



            //Right
            if ((Map.map[posX, posY].statusTile == Status.Food || Map.map[posX, posY].statusTile == Status.NoDirection || Map.map[posX, posY].statusTile == Status.Enemy)
                && find == false)
            {

                find = IsFindPlayer(posX, posY + 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Right);
                    return find;
                }

                FindPlayerVector(ref vm, posX, posY + 1, ref find, limitMax, level + 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Right);
                    return find;
                }

            }



            // down
            if ((Map.map[posX, posY].statusTile == Status.Food || Map.map[posX, posY].statusTile == Status.NoDirection || Map.map[posX, posY].statusTile == Status.Enemy)
                && find == false)
            {

                find = IsFindPlayer(posX + 1, posY);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Down);
                    return find;
                }

                FindPlayerVector(ref vm, posX + 1, posY, ref find, limitMax, level + 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Down);
                    return find;
                }

            }


            return false;

        }


        public static bool FindPlayerSee(ref VectorMove[] vm, Enemy en)
        {

            //UP
            vm = AI.FindVectorMove(VectorMove.Up, en);
            if (vm != null)
            {
                return true;
            }
            // Down
            vm = AI.FindVectorMove(VectorMove.Down, en);
            if (vm != null)
            {
                return true;
            }
            //Left
            vm = AI.FindVectorMove(VectorMove.Left, en);
            if (vm != null)
            {
                return true;
            }
            // Right
            vm = AI.FindVectorMove(VectorMove.Right, en);
            if (vm != null)
            {
                return true;
            }

            return false;

        }


        private static VectorMove[] FindVectorMove(VectorMove vm, Enemy en)
        {

            int x = 0;
            int y = 0;

            #region FindVectorMove

            switch (vm)
            {
                case VectorMove.Up:
                    x = -1;
                    break;
                case VectorMove.Down:
                    x = 1;
                    break;
                case VectorMove.Left:
                    y = -1;
                    break;
                case VectorMove.Right:
                    y = 1;
                    break;
                default:
                    break;
            }
            #endregion

            int sizeVm = 0;

            int moveposX = x;
            int moveposY = y;

            while (Map.map[en.posX + moveposX, en.posY + moveposY].statusTile != Status.Wall)
            {
                ++sizeVm;

                if (Map.map[en.posX + x, en.posY + y].statusTile == Status.Player)
                {
                    return AI.SetVectorMove(sizeVm, vm);

                }
                moveposX += x;
                moveposY += y;
            }

            return null;
        }


        public static void PrioritetVectorMove(Prioritet p)
        {
            AI.prior = p;
        }


        private static VectorMove[] SetVectorMove(int sizeVm, VectorMove vmValue)
        {



            VectorMove[] vm = new VectorMove[sizeVm];
            for (int i = 0; i < sizeVm; i++)
            {
                vm[i] = vmValue;
            }
            return vm;
        }




    }
}
