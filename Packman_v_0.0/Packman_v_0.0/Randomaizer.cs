using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    struct Randomaizer
    {

        public static Random rand = new Random();

        /// <summary>
        /// Создание рандомного числа
        /// </summary>
        /// <param name="start">С</param>
        /// <param name="finish">По</param>
        /// <returns></returns>
        public static int GetRandValue(int start, int finish)
        {
            return rand.Next(start, finish);
        }



        /// <summary>
        /// Заполнение карты блоками (рандомно)
        /// </summary>
        /// <param name="map">Ссылка на карту</param>
        public static void RandomBlock(ref Map map)
        {

            for (int i = (int)BlockValue.MaxSizeBlock; i > 0; i--)
            {

                for (int j = 0; j < (int)BlockValue.CountBlock; j++)
                {

                    int sizeX = rand.Next(1, i);
                    int sizeY = rand.Next(1, i);

                    int positionX = rand.Next(2, map.sizeRow - sizeX - 1);
                    int positionY = rand.Next(2, map.sizeCol - sizeY - 1);

                    bool checkBlock = CheckMapBlock(map, positionX, positionY, sizeX, sizeY);

                    if (checkBlock)
                    {
                        SetBlock(ref map, positionX, positionY, sizeX, sizeY);
                    }
                }
            }
        }


        /// <summary>
        /// Проверка на рядом стоящие блоки
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="positionX"> Позиция Х</param>
        /// <param name="positionY">Позиция У</param>
        /// <param name="sizeX">Размер Блока Х</param>
        /// <param name="sizeY">Размер Блока У</param>
        /// <returns></returns>
        private static bool CheckMapBlock(Map map, int positionX, int positionY, int sizeX, int sizeY)
        {

            bool checkBlock = true;
            for (int i = positionX - 1; i < sizeX + positionX + 1; i++)
            {
                for (int j = positionY - 1; j < sizeY + positionY + 1; j++)
                {
                    if (map.map[i, j].statusTile == Status.Wall)
                    {
                        checkBlock = false;
                        return checkBlock;
                    }
                }
            }

            return checkBlock;
        }


        /// <summary>
        /// Вставка блока в карту
        /// </summary>
        /// <param name="map">карта</param>
        /// <param name="positionX">Позиция вставки Х</param>
        /// <param name="positionY">Позиция вставки У</param>
        /// <param name="sizeX">Размер по оси Х</param>
        /// <param name="sizeY">Размер по оси У</param>
        private static void SetBlock(ref Map map, int positionX, int positionY, int sizeX, int sizeY)
        {

            for (int i = positionX; i < sizeX + positionX; i++)
            {
                for (int j = positionY; j < sizeY + positionY; j++)
                {
                    map.map[i, j].statusTile = Status.Wall;
                    map.map[i, j].mapValue = MapValue.GorizontWall;
                    map.map[i, j].cc = ConsoleColor.Yellow;
                }
            }

        }


    }






}
