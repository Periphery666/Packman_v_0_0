using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    struct Enemy
    {
        public int posX;
        public int posY;
       // public string NamePlayer;
        public MapValue mv;
        public Status st;
        public VectorMove vec;

        public MapValue actualMapValue;
        public Status actualStatus;
        public Prioritet p;

        public ConsoleColor cc;
        public VectorMove[] vm;


        public bool findVector;
        public bool findSee;
        public int countStep;

        public static int level;

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

        }

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





    }
}
