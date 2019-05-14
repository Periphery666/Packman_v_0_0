using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Packman_v_0._0
{
    struct Game
    {
        /// <summary>
        /// Печать карты
        /// </summary>
        /// <param name="map">Карта </param>
        public static void Print( Map map)
        {
            for (int i = 0; i < map.sizeRow; i++)
            {
                for (int j = 0; j < map.sizeCol; j++)
                {
                    Console.ForegroundColor = map.map[i, j].cc;
                    Console.Write((char)map.map[i, j].mapValue);
                }
                Console.WriteLine();
            }

        }


        /// <summary>
        /// Выбор пользователем уровня сложности
        /// </summary>
        /// <returns></returns>
        public static int SetLevelGame()
        {
            Console.WriteLine("Выбери уровень сложности ");
            Console.WriteLine("1 МАЛЫШ");
            Console.WriteLine("2 ШКОЛОЛО");
            Console.WriteLine("3 МУЖИГ");
            Console.WriteLine("4 УМЕЛЫЙ");
            Console.WriteLine("5 БЫВАЛЫй");
            Console.WriteLine("6 ВЕТЕРАН");
            Console.WriteLine("7 МАРИО МАСТЕР ");
            Console.WriteLine("8 КРУЧЕ ЯИЦ");
            Console.WriteLine("9 БАТЯ В ЗДАНИИ");


            int choise = 0;

            while (choise == 0)
            {
                char tmp = Console.ReadKey().KeyChar;
                if (!int.TryParse(tmp.ToString(), out choise))
                    Console.WriteLine("Нет такогоб давай еще раз");
            }
            Console.Clear();

            return choise;
        }


        /// <summary>
        /// Создание карты 
        /// </summary>
        /// <param name="map">Ссылка на карту</param>
        public static void CreateMap(ref Map map)
        {
            

            while ((map.sizeCol  == 0 || map.sizeCol < -1) || (map.sizeRow == 0 || map.sizeRow < -1))
            {
                Console.WriteLine("Enter size of map. Not less 15");
                Console.WriteLine("Enter size col=>");
                string tmp = Console.ReadLine();

                if ( !int.TryParse(tmp.ToString(), out map.sizeCol))
                {
                    Console.WriteLine("Не то пальто");
                }

                Console.WriteLine("Enter size row=>");
                tmp = Console.ReadLine();

                if (!int.TryParse(tmp.ToString(), out map.sizeRow))
                {
                    Console.WriteLine("Не то пальто");
                }
            }
            map.map = new Tile[map.sizeCol, map.sizeRow];

            Console.CursorVisible = false;

            Console.Clear();

        }


        /// <summary>
        /// Считывание нажатой клавиши
        /// </summary>
        /// <returns></returns>
        public static ConsoleKey GetMove()
        {
            return Console.ReadKey(true).Key;
        }



    



    }
}
