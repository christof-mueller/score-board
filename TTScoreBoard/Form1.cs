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


namespace TTScoreBoard
{
    public partial class Form1 : Form
    {
        private static string HOST = "localhost";
        private static int PORT = 4223;
        private static string UID = "FQz"; // Change XYZ to the UID of your LED Strip Bricklet 2.0

        Score mActualScore;

        // Use frame started callback to move the active LED every frame
        static void FrameStartedCB(BrickletLEDStripV2 sender, int length)
        {
            byte[] field1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0, 0,
                             0, 0, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0, 0,
                             0, 0, 0, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            int ledCount = 0;
            for (int i=0; i < length; i=i+3)
            {
                if (ledCount >= 256) break;
                sender.SetLEDValues(i, new byte[] { field1[ledCount] });
                ledCount++;
            }
            
        }


        public Form1()
        {
            InitializeComponent();
            mActualScore = new Score(rbServiceA.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPConnection ipcon = new IPConnection(); // Create IP connection
            BrickletLEDStripV2 ls = new BrickletLEDStripV2(UID, ipcon); // Create device object

            ipcon.Connect(HOST, PORT); // Connect to brickd

            ls.SetChipType(BrickletLEDStripV2.CHIP_TYPE_WS2812);
            ls.SetChannelMapping(BrickletLEDStripV2.CHANNEL_MAPPING_GRB);

            // Set frame duration to 50ms (20 frames per second)
            ls.SetFrameDuration(50);
         
            // Register frame started callback to function FrameStartedCB
            ls.FrameStartedCallback += FrameStartedCB;

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            mActualScore.newGame(rbServiceA.Checked);
            updateScore();
        }

        private void btnPlayerA_Click(object sender, EventArgs e)
        {
            mActualScore.pointForPlayerA();
            updateScore();
        }

        private void btnPlayerB_Click(object sender, EventArgs e)
        {
            mActualScore.pointForPlayerB();
            updateScore();
        }

        private void updateScore()
        {
            String score = "";

            for(int i=0; i < mActualScore.playerA().sets(); i++)
            {
                score += "*";
            }

            score += " | " + mActualScore.playerA().points();
            score += " : " + mActualScore.playerB().points();
            score += " | "; 

            for (int i = 0; i < mActualScore.playerB().sets(); i++)
            {
                score += "*";
            }
            
            if (mActualScore.playerAToServeNow())
            {
                score += 'A';
            }
            else
            {
                score += 'B';
            }

            scoreDisplay.Text = score;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
