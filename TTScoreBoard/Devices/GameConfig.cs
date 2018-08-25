using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTScoreBoard.Devices
{
    public class GameConfig
    {
        int mFirstToServe;
        public int firstToServe
        {
            get
            {
                return this.mFirstToServe;
            }
            set
            {
                this.mFirstToServe = value;
            }
        }
    }
}
