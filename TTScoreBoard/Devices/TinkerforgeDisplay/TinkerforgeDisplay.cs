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

            int pixelNumber = mHeight * mWidth;

            // alles aus
            byte[] pixelPuffer = new byte[pixelNumber * 3];
            for (int i = 0; i < pixelPuffer.Length; i++)
            {
                pixelPuffer[i] = 0;
            }
            ls.SetLEDValues(0, pixelPuffer);
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
                byte[] pixelPuffer = new byte[length];
                for (int i = 0; i < length; i = i + 3)
                {
                    Byte col = findPixelInScreen(i / 3, TinkerforgeDisplay.nextScreen);
                    try {
                        switch (col)
                        {
                            case 0: // BLACK
                                pixelPuffer[i] = 0;
                                pixelPuffer[i + 1] = 0;
                                pixelPuffer[i + 2] = 0;
                                break;
                            case 1: // RED
                                pixelPuffer[i] = 10;
                                pixelPuffer[i + 1] = 0;
                                pixelPuffer[i + 2] = 0;
                                break;
                            case 2: // GREEN
                                pixelPuffer[i] = 0;
                                pixelPuffer[i + 1] = 10;
                                pixelPuffer[i + 2] = 0;
                                break;
                            case 3: // BLUE
                                pixelPuffer[i] = 0;
                                pixelPuffer[i + 1] = 0;
                                pixelPuffer[i + 2] = 10;
                                break;
                            case 4: // TÜRKIS
                                pixelPuffer[i] = 0;
                                pixelPuffer[i + 1] = 10;
                                pixelPuffer[i + 2] = 10;
                                break;
                            case 5: // MAGENTA
                                pixelPuffer[i] = 10;
                                pixelPuffer[i + 1] = 0;
                                pixelPuffer[i + 2] = 10;
                                break;
                            case 6: // WHITE
                                pixelPuffer[i] = 5;
                                pixelPuffer[i + 1] = 10;
                                pixelPuffer[i + 2] = 5;
                                break;
                            case 7: // YELLOW
                                pixelPuffer[i] = 5;
                                pixelPuffer[i + 1] = 10;
                                pixelPuffer[i + 2] = 0;
                                break;
                        }
                    } catch(IndexOutOfRangeException)
                    {
                        // WARUM?
                    }
                }
                sender.SetLEDValues(0, pixelPuffer);
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
