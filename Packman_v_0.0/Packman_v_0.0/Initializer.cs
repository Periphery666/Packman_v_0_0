using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    struct Initializer
    {

        /// <summary>
        /// Позиционирование игрока на карте
        /// </summary>
        /// <param name="pl">Игрок</param>
        /// <param name="map">Карту</param>
        public static void SetPlayers(ref Player pl, ref Map map)
        {
            while (pl.posX == 0 && pl.posY == 0)
            {
                int posX = Randomaizer.GetRandValue(1, map.sizeRow - 1);
                int posY = Randomaizer.GetRandValue(1, map.sizeCol - 1);

                if (map.map[pl.posX, pl.posY].statusTile != Status.Wall
                    || map.map[posX, posY].statusTile != Status.Enemy)
                {
                    pl.posX = posX;
                    pl.posY = posY;

                    map.map[pl.posX, pl.posY].statusTile = pl.st;
                    map.map[pl.posX, pl.posY].mapValue = pl.mv;
                }
            }
        }


        /// <summary>
        /// Позиционирование врага на карте
        /// </summary>
        /// <param name="en">Враг</param>
        /// <param name="map">Карта</param>
        private static void InitEnemy(ref Enemy en, ref Map map)
        {

            while (en.posX == 0 && en.posY == 0)
            {
                int posX = Randomaizer.GetRandValue(1, map.sizeRow - 1);
                int posY = Randomaizer.GetRandValue(1, map.sizeCol - 1);

                if (map.map[posX, posY].statusTile != Status.Wall)
                {
                    en.posX = posX;
                    en.posY = posY;

                    map.map[en.posX, en.posY].statusTile = en.st;
                    map.map[en.posX, en.posY].mapValue = en.mv;
                    map.map[en.posX, en.posY].cc = en.cc;
                    en.Actualcc = ConsoleColor.Cyan;
                    
                }
            }

        }


        /// <summary>
        /// Заполнение карты значениями 
        /// </summary>
        /// <param name="map">ссылка на карту</param>
        public static void InitMap(ref Map map)
        {

            for (int i = 0; i < map.sizeRow; i++)
            {
                for (int j = 0; j < map.sizeCol; j++)
                {

                    if (i == 0 || i == map.sizeRow - 1)
                    {
                        map.map[i, j].mapValue = MapValue.GorizontWall;
                        map.map[i, j].statusTile = Status.Wall;
                        map.map[i, j].cc = ConsoleColor.Yellow;
                        continue;
                    }

                    if (j == 0 || j == map.sizeCol - 1)
                    {
                        map.map[i, j].mapValue = MapValue.VerticaltWall;
                        map.map[i, j].statusTile = Status.Wall;
                        map.map[i, j].cc = ConsoleColor.Yellow;
                        continue;
                    }

                    map.map[i, j].mapValue = MapValue.Food;
                    map.map[i, j].statusTile = Status.Food;
                    map.map[i, j].cc = ConsoleColor.Cyan;

                }
            }

            InitCorner(ref map);
        }

        /// <summary>
        /// Установка углов карты
        /// </summary>
        /// <param name="map">ссылка на карту</param>
        private static void InitCorner (ref Map map)
        {

            map.map[0, 0].mapValue = MapValue.LeftUpCorner;
            map.map[0, 0].statusTile = Status.Wall;
            map.map[0, 0].cc = ConsoleColor.Yellow;

            map.map[0, map.sizeCol - 1].mapValue = MapValue.RightUpCorner;
            map.map[0, map.sizeCol - 1].statusTile = Status.Wall;
            map.map[0, map.sizeCol - 1].cc = ConsoleColor.Yellow;

            map.map[map.sizeRow - 1, 0].mapValue = MapValue.LeftDownCorner;
            map.map[map.sizeRow - 1, 0].statusTile = Status.Wall;
            map.map[map.sizeRow - 1, 0].cc = ConsoleColor.Yellow;

            map.map[map.sizeRow - 1, map.sizeCol - 1].mapValue = MapValue.RightDownpCorner;
            map.map[map.sizeRow - 1, map.sizeCol - 1].statusTile = Status.Wall;
            map.map[map.sizeRow - 1, map.sizeCol - 1].cc = ConsoleColor.Yellow;
        }


        /// <summary>
        /// Позиционирование массива врагов на карте
        /// </summary>
        /// <param name="en"></param>
        /// <param name="map"></param>
        public static void InitVecEnemy(Enemy[] en, ref Map map)
        {

            for (int i = 0; i < en.Length; i++)
            {
                Initializer.InitEnemy(ref en[i], ref map);
            }
        }



       









    }
}
