using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Packman_v_0._0
{
    struct Map
    {

        //public static Map Create(int rowsCount, int colummnsCount)
        //{ 

        //}

        // добавить и инит 
        public const int sizeRow = 30;
        public const int sizeCol = 60;


        public static Tile[,] map = new Tile[sizeRow, sizeCol];

        public static Random rand = new Random(); // отдельно инивйциализ


      

        // отдельно инивйциализ
        public static void InitPlayers(ref Player pl)
        {

            while (pl.posX == 0 && pl.posY == 0)
            {
                int posX = rand.Next(1, sizeRow - 1);
                int posY = rand.Next(1, sizeCol - 1);

                if (Map.map[posX, posY].statusTile != Status.Wall || Map.map[posX, posY].statusTile != Status.Enemy)
                {
                    pl.posX = posX;
                    pl.posY = posY;

                    Map.map[pl.posX, pl.posY].statusTile = pl.st;
                    Map.map[pl.posX, pl.posY].mapValue = pl.mv;
                }

            }

        }

        // отдельно инивйциализ
        public static void InitPlayers(ref Enemy en)
        {

            while (en.posX == 0 && en.posY == 0)
            {
                int posX = rand.Next(1, sizeRow - 1);
                int posY = rand.Next(1, sizeCol - 1);

                if (Map.map[posX, posY].statusTile != Status.Wall)
                {
                    en.posX = posX;
                    en.posY = posY;

                    Map.map[en.posX, en.posY].statusTile = en.st;
                    Map.map[en.posX, en.posY].mapValue = en.mv;
                }
            }

        }


        // без for
        public static void InitMap()
        {

            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeCol; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        map[i, j].mapValue = MapValue.LeftUpCorner;
                        map[i, j].statusTile = Status.Wall;
                        map[i, j].cc= ConsoleColor.Yellow;

                        continue;
                    }

                    if (i == 0 && j == sizeCol - 1)
                    {
                        map[i, j].mapValue = MapValue.RightUpCorner;
                        map[i, j].statusTile = Status.Wall;
                        map[i, j].cc= ConsoleColor.Yellow;
                        continue;
                    }

                    if (i == sizeRow - 1 && j == 0)
                    {
                        map[i, j].mapValue = MapValue.LeftDownCorner;
                        map[i, j].statusTile = Status.Wall;
                        map[i, j].cc= ConsoleColor.Yellow;
                        continue;
                    }

                    if (i == sizeRow - 1 && j == sizeCol - 1)
                    {
                        map[i, j].mapValue = MapValue.RightDownpCorner;
                        map[i, j].statusTile = Status.Wall;
                        map[i, j].cc= ConsoleColor.Yellow;
                        continue;
                    }

                    if (i == 0 || i == sizeRow - 1)
                    {
                        map[i, j].mapValue = MapValue.GorizontWall;
                        map[i, j].statusTile = Status.Wall;
                        map[i, j].cc= ConsoleColor.Yellow;
                        continue;
                    }

                    if (j == 0 || j == sizeCol - 1)
                    {
                        map[i, j].mapValue = MapValue.VerticaltWall;
                        map[i, j].statusTile = Status.Wall;
                        map[i, j].cc= ConsoleColor.Yellow;
                        continue;
                    }

                    map[i, j].mapValue = MapValue.Food;
                    map[i, j].statusTile = Status.Food;
                    map[i, j].cc = ConsoleColor.Cyan;

                }
            }

        }


        // в UI
        public static void Print()
        {
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeCol; j++)
                {
                    ChangeColor(map[i, j].cc);
                    Console.Write((char)map[i, j].mapValue );
                }
                Console.WriteLine();
            }


        }

        // тупость , посменять 
        public static void ChangeColor(ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
        }
      

        public static void RandomBlock(int countBlock = 1000)
        {
            int sizeblock = 8;

            for (int b = sizeblock; b > 0; b--)
            {

                for (int f = 0; f < countBlock; f++)
                {

                    int sizeX = rand.Next(1, b);
                    int sizeY = rand.Next(1, b);

                    int positionX = rand.Next(2, sizeRow - sizeX - 1);
                    int positionY = rand.Next(2, sizeCol - sizeY - 1);

                    bool good = true;

                    // в отдельную функцию
                    for (int i = positionX - 1; i < sizeX + positionX + 1; i++)
                    {
                        for (int j = positionY - 1; j < sizeY + positionY + 1; j++)
                        {
                            if (Map.map[i, j].statusTile == Status.Wall)
                            {
                                good = false;

                            }
                        }
                    }
                    //

                    if (good)
                    {
                        for (int g = positionX; g < sizeX + positionX; g++)
                        {
                            for (int v = positionY; v < sizeY + positionY; v++)
                            {
                                Map.map[g, v].statusTile = Status.Wall;
                                Map.map[g, v].mapValue = MapValue.GorizontWall;
                                Map.map[g, v].cc = ConsoleColor.Yellow;


                            }
                        }

                    }

                }

            }
        }


    }
}
