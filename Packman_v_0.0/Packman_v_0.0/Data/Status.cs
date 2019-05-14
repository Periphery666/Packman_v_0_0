using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packman_v_0._0
{
    // Статус плитки карты
    enum Status
    {
        NoDirection = 0x00,
        Food = 0x01,
        Wall = 0x02,
        Player = 0x03,
        Enemy = 0x04
    }
}
