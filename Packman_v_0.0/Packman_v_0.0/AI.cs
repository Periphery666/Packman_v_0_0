using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    struct AI
    {



        // Выбор вектора движения
        public static VectorMove Move()
        {
            return (VectorMove)Randomaizer.GetRandValue((int)VectorMove.Up, (int)VectorMove.Right);
        }


        /// <summary>
        /// Создания массива движения за игроком
        /// </summary>
        /// <param name="vm">ссылка на вектор движения</param>
        /// <param name="size">количество ходов</param>
        /// <param name="vector">направление движения</param>
        public static void SetVectorMove(ref VectorMove[] vm, int size, VectorMove vector)
        {
            if (vm == null)
            {
                vm = new VectorMove[size];
            }

            vm[size - 1] = vector;
        }



        /// <summary>
        ///  проверка на встречу с игроком
        /// </summary>
        /// <param name="map"> Карта </param>
        /// <param name="posX">Позиция Х </param>
        /// <param name="posY">Позиция У </param>
        /// <returns></returns>
        public static bool IsFindPlayer(Map map, int posX, int posY)
        {
            return map.map[posX, posY].statusTile == Status.Player;
        }



        //public static bool FindPlayerVector(Map map, ref VectorMove[] vm, int posX, int posY, ref bool find, int limitMax = 6, int level = 1)
        //{

        //    if (limitMax < level)
        //    {
        //        return false;
        //    }



        //    //Up find
        //    if ((map.map[posX, posY].statusTile == Status.Food || map.map[posX, posY].statusTile == Status.NoDirection || map.map[posX, posY].statusTile == Status.Enemy)
        //         && !find)
        //    {
        //        find = IsFindPlayer(map,posX - 1, posY);


        //        if (find)
        //        {
        //            SetVectorMove(ref vm, level, VectorMove.Up);
        //            return find;
        //        }
        //        FindPlayerVector(map,ref vm, posX - 1, posY, ref find, limitMax, level + 1);
        //        if (find)
        //        {
        //            SetVectorMove(ref vm, level, VectorMove.Up);
        //            return find;
        //        }
        //    }


        //    // left
        //    if ((map.map[posX, posY].statusTile == Status.Food || map.map[posX, posY].statusTile == Status.NoDirection || map.map[posX, posY].statusTile == Status.Enemy)
        //        && !find)
        //    {

        //        find = IsFindPlayer(map,posX, posY - 1);

        //        if (find)
        //        {
        //            SetVectorMove(ref vm, level, VectorMove.Left);
        //            return find;
        //        }

        //        FindPlayerVector(map,ref vm, posX, posY - 1, ref find, limitMax, level + 1);

        //        if (find)
        //        {
        //            SetVectorMove(ref vm, level, VectorMove.Left);
        //            return find;
        //        }
        //    }


        //    //Right
        //    if ((map.map[posX, posY].statusTile == Status.Food || map.map[posX, posY].statusTile == Status.NoDirection || map.map[posX, posY].statusTile == Status.Enemy)
        //        && !find)
        //    {

        //        find = IsFindPlayer(map,posX, posY + 1);

        //        if (find)
        //        {
        //            SetVectorMove(ref vm, level, VectorMove.Right);
        //            return find;
        //        }

        //        FindPlayerVector(map,ref vm, posX, posY + 1, ref find, limitMax, level + 1);

        //        if (find)
        //        {
        //            SetVectorMove(ref vm, level, VectorMove.Right);
        //            return find;
        //        }

        //    }


        //    // down
        //    if ((map.map[posX, posY].statusTile == Status.Food || map.map[posX, posY].statusTile == Status.NoDirection || map.map[posX, posY].statusTile == Status.Enemy)
        //        && !find)
        //    {

        //        find = IsFindPlayer(map,posX + 1, posY);

        //        if (find)
        //        {
        //            SetVectorMove(ref vm, level, VectorMove.Down);
        //            return find;
        //        }

        //        FindPlayerVector(map,ref vm, posX + 1, posY, ref find, limitMax, level + 1);

        //        if (find)
        //        {
        //            SetVectorMove(ref vm, level, VectorMove.Down);
        //            return find;
        //        }
        //    }

        //    return false;

        //}


        //


        /// <summary>
        /// Рекурсивный поиск игрока с дальнейшим сохранением вектора движения
        /// </summary>
        /// <param name="map">Карта </param>
        /// <param name="vm">Вектор движения </param>
        /// <param name="posX">позиция врага X </param>
        /// <param name="posY">позиция врага Y</param>
        /// <param name="find">Флаг поиска</param>
        /// <param name="limitMax">Глубина поиска игрока</param>
        /// <param name="level">Уровень вхождения рекурсии</param>
        /// <returns></returns>
        public static bool FindPlayerVector(Map map, ref VectorMove[] vm, int posX, int posY, ref bool find, int limitMax , int level = 1)
        {

            if (limitMax < level)
            {
                return false;
            }



            //Up find
            if ((map.map[posX, posY].statusTile == Status.Food || map.map[posX, posY].statusTile == Status.NoDirection || map.map[posX, posY].statusTile == Status.Enemy)
                 && !find)
            {
                find = IsFindPlayer(map, posX - 1, posY);


                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Up);
                    return find;
                }
                FindPlayerVector(map, ref vm, posX - 1, posY, ref find, limitMax, level + 1);
                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Up);
                    return find;
                }
            }


            // left
            if ((map.map[posX, posY].statusTile == Status.Food || map.map[posX, posY].statusTile == Status.NoDirection || map.map[posX, posY].statusTile == Status.Enemy)
                && !find)
            {

                find = IsFindPlayer(map, posX, posY - 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Left);
                    return find;
                }

                FindPlayerVector(map, ref vm, posX, posY - 1, ref find, limitMax, level + 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Left);
                    return find;
                }
            }


            //Right
            if ((map.map[posX, posY].statusTile == Status.Food || map.map[posX, posY].statusTile == Status.NoDirection || map.map[posX, posY].statusTile == Status.Enemy)
                && !find)
            {

                find = IsFindPlayer(map, posX, posY + 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Right);
                    return find;
                }

                FindPlayerVector(map, ref vm, posX, posY + 1, ref find, limitMax, level + 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Right);
                    return find;
                }

            }


            // down
            if ((map.map[posX, posY].statusTile == Status.Food || map.map[posX, posY].statusTile == Status.NoDirection || map.map[posX, posY].statusTile == Status.Enemy)
                && !find)
            {

                find = IsFindPlayer(map, posX + 1, posY);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Down);
                    return find;
                }

                FindPlayerVector(map, ref vm, posX + 1, posY, ref find, limitMax, level + 1);

                if (find)
                {
                    SetVectorMove(ref vm, level, VectorMove.Down);
                    return find;
                }
            }

            return false;

        }


        /// <summary>
        /// Поиск игрока в области прямой видимости до преграды
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="vm">Ссылка на вестор движения </param>
        /// <param name="en">Враг который ищет</param>
        /// <returns></returns>
        public static bool FindPlayerSee(Map map, ref VectorMove[] vm, Enemy en)
        {

            //UP
            vm = AI.FindVectorMove(map, VectorMove.Up, en);
            if (vm != null)
            {
                return true;
            }
            // Down
            vm = AI.FindVectorMove(map, VectorMove.Down, en);
            if (vm != null)
            {
                return true;
            }
            //Left
            vm = AI.FindVectorMove(map, VectorMove.Left, en);
            if (vm != null)
            {
                return true;
            }
            // Right
            vm = AI.FindVectorMove(map, VectorMove.Right, en);
            if (vm != null)
            {
                return true;
            }

            return false;

        }


        /// <summary>
        /// Работа по поиску в области прямой видимости до преграды
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="vm">Ссылка на вестор движения </param>
        /// <param name="en">Враг который ищет</param>
        /// <returns></returns>
        private static VectorMove[] FindVectorMove(Map map, VectorMove vm, Enemy en)
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

            while (map.map[en.posX + moveposX, en.posY + moveposY].statusTile != Status.Wall)
            {
                ++sizeVm;

                if (map.map[en.posX + x, en.posY + y].statusTile == Status.Player)
                {
                    return AI.SetVectorMove(sizeVm, vm);

                }
                moveposX += x;
                moveposY += y;
            }

            return null;
        }


        /// <summary>
        /// Установка вектора движения  в области прямой видимости до преграды
        /// </summary>
        /// <param name="sizeVm">Количество ходов к игроку</param>
        /// <param name="vmValue">Направление движения </param>
        /// <returns></returns>
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
