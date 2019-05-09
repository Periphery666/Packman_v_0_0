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
        public static Logics logicGame = new Logics();  // хз надо или нет


        public static void InitData( /*ref*/ Enemy[] en)
        {
            Map.InitMap();
            Map.RandomBlock();

            for (int i = 0; i < en.Length; i++)
            {
                Map.InitPlayers(ref en[i]);

            }
            Map.Print();
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


        public static void Start()
        {

            Player pl = new Player();
            pl.level = SetLevelGame();

            Map.InitPlayers(ref pl);
            Enemy.level = pl.level;

            Enemy[] enVec = Enemy.CreateEnemy(Enemy.level);
            pl.InitPlayer();

            InitData(enVec);


            while (!Logics.endGame)
            {

                pl.vec = Logics.Move(Game.GetMove());
                Logics.ChangeVec(ref pl);

                InitVecEnemy(enVec);

                SetCursoreToMove();

            }
        }



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


        public static void InitVecEnemy(Enemy[] en)
        {
            for (int i = 0; i < en.Length; i++)
            {
                SetVector(ref en[i], ref en[i].vm);
                ChoiceVector(ref en[i], en[i].vm, ref en[i].countStep);
                Logics.ChangeVec(ref en[i]);

            }
        }


        public static void SetVector(ref Enemy en1, ref VectorMove[] vm)
        {

            if (en1.p == Prioritet.VectorRandom)
            {
                AI.FindPlayerVector(ref vm, en1.posX, en1.posY, ref en1.findVector, Enemy.level);

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
                en1.findSee = AI.FindPlayerSee(ref vm, en1);

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



        public static ConsoleKey GetMove()
        {
            return Console.ReadKey().Key;
        }



        public static void SetCursoreToMove()
        {
            Console.SetCursorPosition(35, 35);
        }










    }
}
