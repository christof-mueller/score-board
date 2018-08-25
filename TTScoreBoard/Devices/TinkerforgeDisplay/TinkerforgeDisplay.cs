using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinkerforge;

namespace TTScoreBoard.Devices.TinkerforgeDisplay
{
    class TinkerforgeDisplay : IDisplay
    {
        private static string HOST = "localhost";
        private static int PORT = 4223;
        private static string UID = "FQz";
        private BrickletLEDStripV2 ls;
        private IPConnection ipcon;
        private static Screen nextScreen;

        public void onPointForPlayerA() { }
        public void onPointForPlayerB() { }
        public void onUndoLastPoint() { }
        public void onNewGame(GameConfig gameConfig) { }

        private int mHeight;
        private int mWidth;


        public void init(int height, int width)
        {
            mHeight = height;
            mWidth = width;
            ipcon = new IPConnection(); // Create IP connection
            ls = new BrickletLEDStripV2(UID, ipcon); // Create device object

            ipcon.Connect(HOST, PORT); // Connect to brickd

            ls.SetChipType(BrickletLEDStripV2.CHIP_TYPE_WS2812);
            ls.SetChannelMapping(BrickletLEDStripV2.CHANNEL_MAPPING_GRB);

            // Set frame duration to 50ms (20 frames per second)
            ls.SetFrameDuration(50);

            // Register frame started callback to function FrameStartedCB
            ls.FrameStartedCallback += FrameStartedCB;
        }

        public void showScreen(Screen screen)
        {
            nextScreen = screen;
        }

        // Use frame started callback to move the active LED every frame
        static void FrameStartedCB(BrickletLEDStripV2 sender, int length)
        {
            if (TinkerforgeDisplay.nextScreen != null)
            { 
                for (int i = 0; i < length; i = i + 3)
                {
                    Byte pixelValue = findPixelInScreen(i / 3, TinkerforgeDisplay.nextScreen);
                    if (pixelValue > 0)
                    {
                        sender.SetLEDValues(i, new byte[] { 5, 0, 0 });
                    }
                    else
                    {
                        sender.SetLEDValues(i, new byte[] { 0, 0, 0 });
                    }
                    
                }
            }
        }

        private static byte findPixelInScreen(int pixelNumberOnDisplay, Screen screen)
        {
            int x = pixelNumberOnDisplay / screen.height;
            int y = 0;
            if (x % 2 == 0)
            {
                y = pixelNumberOnDisplay - (x * screen.height);
            }
            else
            {
                y = (screen.height - 1) - (pixelNumberOnDisplay - (x * screen.height));
            }
            return screen.pixelAt(x, y);
        }
        
        private int pixelNumberByXY(int x, int y)
        {
            if (x % 2 == 0)
            {
                return (x * mHeight) + y;
            }
            else
            {
                return (x * mHeight) + ((mHeight - 1) - y);
            }
        }
    }
}
