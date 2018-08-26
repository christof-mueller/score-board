using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tinkerforge;

namespace TTScoreBoard.Devices
{
    public partial class VirtualDisplay : Form, IDisplay
    {
        List<Button> pixels = new List<Button>();
        private int mHeight;
        private int mWidth;

        public void onPointForPlayerA() { }
        public void onPointForPlayerB() { }
        public void onUndoLastPoint() { }
        public void onNewGame(GameConfig gameConfig) { }

        public void showScreen(Screen screen)
        {
            clearDisplay();
            for (int y = 0; y < mHeight; y++)
            {
                for (int x = 0; x < mWidth; x++)
                {
                    Byte col = screen.pixelAt(x, y);
                    if (col > 0) setDisplayPixel(x, y, col);
                }
            }
        }

        public VirtualDisplay()
        {
            InitializeComponent();
        }

        public void init(int height, int width)
        {
            mHeight = height;
            mWidth = width;
            int xOffset = 10;
            int yOffset = 10;
            int pixelSize = 20;
            int pixelDistance = 15;

            // Zeile für Zeile
            for (int y = 0; y < mHeight; y++)
            {
                // Pro Pixel einer Zeile
                for (int x = 0; x < mWidth; x++)
                {
                    Button pixel = new Button();
                    pixel.Location = new System.Drawing.Point(  xOffset + (x * (pixelSize + pixelDistance)),
                                                                yOffset + (y * (pixelSize + pixelDistance)));
                    pixel.BackColor = System.Drawing.Color.Green;
                    pixel.FlatAppearance.BorderSize = 0;
                    pixel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    pixel.ForeColor = System.Drawing.Color.Black;
                    pixel.Margin = new System.Windows.Forms.Padding(0);
                    pixel.Size = new System.Drawing.Size(pixelSize, pixelSize);
                    pixel.UseVisualStyleBackColor = false;

                    pixels.Add(pixel);
                    Controls.Add(pixel);
                }
            }
        }

        private void clearDisplay()
        {
            foreach(Button pixel in pixels)
            {
                pixel.BackColor = Color.Black;
            }
        }

        private int pixelNumberByXY(int x, int y)
        {
            return (y * mWidth) + x;
        }

        private void setDisplayPixel(int x, int y, Byte col)
        {
            if (x < 0 || x > mWidth || y < 0 || y > mHeight) throw new IndexOutOfRangeException();

            Button pixel = pixels[pixelNumberByXY(x, y)];
            switch(col)
            {
                case 0: pixel.BackColor = Color.Black; break;
                case 1: pixel.BackColor = Color.Red; break;
                case 2: pixel.BackColor = Color.Green; break;
                case 3: pixel.BackColor = Color.Blue; break;
                case 4: pixel.BackColor = Color.BlueViolet; break;
                case 5: pixel.BackColor = Color.Magenta; break;
                case 6: pixel.BackColor = Color.White; break;
                case 7: pixel.BackColor = Color.Yellow; break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Screen screen = new Screen(16, 32);
            screen.write("CCM");
          
            
            IDisplay realDisplay = new TinkerforgeDisplay.TinkerforgeDisplay();
            IDisplay virtualDisplay = this;

            
            realDisplay.init(screen.height, screen.width);
            virtualDisplay.init(screen.height, screen.width);

            realDisplay.showScreen(screen);
            virtualDisplay.showScreen(screen);
        }
    }
}
