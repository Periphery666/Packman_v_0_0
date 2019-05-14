using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    struct Enemy
    {
        // Поля врага
        public int posX;
        public int posY;
     
        public MapValue mv;
        public Status st;
        public VectorMove vec;

        public MapValue actualMapValue;
        public Status actualStatus;
        public ConsoleColor Actualcc;
        public Prioritet p;

        public ConsoleColor cc;
        public VectorMove[] vm;


        public bool findVector;
        public bool findSee;
        public int countStep;

        public static int level;

        /// <summary>
        /// Инициализация полямили для старта
        /// </summary>
        public void InitEnemy()
        {
            p = Prioritet.VectorRandom;
            vec = VectorMove.NoDirection;
            mv = MapValue.Enemy;
            st = Status.Enemy;
            actualMapValue = MapValue.Food;
            actualStatus = Status.Food;
            cc = ConsoleColor.Red;
            findVector = false;
            findSee = false;
            countStep = 0;
            Actualcc = ConsoleColor.Cyan;

        }


        /// <summary>
        /// Создание массива врагов 
        /// </summary>
        /// <param name="count"> количество врагов</param>
        /// <returns></returns>
        public static Enemy[] CreateEnemy(int count)
        {
            Enemy[] enVec = new Enemy[count];

            for (int i = 0; i < count; i++)
            {
                enVec[i] = new Enemy();
                enVec[i].InitEnemy();

            }
            return enVec;

        }

        /// <summary>
        /// Поиск вектора движения
        /// </summary>
        /// <param name="en">Массив врагов</param>
        /// <param name="map"> ссылка на карту</param>
        public static void InitVecEnemy(Enemy[] en, ref Map map)
        {
            for (int i = 0; i < en.Length; i++)
            {
                Logics.SetVector(ref map,ref en[i], ref en[i].vm);
                Logics.ChoiceVector(ref en[i], en[i].vm, ref en[i].countStep);
                Logics.ChangeVec(ref en[i], ref map);

            }
        }



    }
}
