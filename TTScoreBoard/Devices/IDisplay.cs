using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTScoreBoard.Devices
{
    interface IDisplay
    {
        void init(int height, int width);
        void showScreen(Screen screen);

        // Events des Geräts
        void onPointForPlayerA();
        void onPointForPlayerB();
        void onUndoLastPoint();
        void onNewGame(GameConfig gameConfig);

    }
}
