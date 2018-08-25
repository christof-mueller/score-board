using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTScoreBoard
{
    class Player
    {
        private int mPoints = 0;
        private int mSets = 0;
        private bool mHasTimeoutTaken = false;

        public bool hasTimeoutTaken() { return mHasTimeoutTaken; }
        public int points() { return mPoints; }
        public int sets() { return mSets; }

        public void incPoints()
        {
            mPoints++;
        }

        public void incSets()
        {
            mSets++;
        }

        public void newSet()
        {
            mPoints = 0;
        }

    }

    class Score
    {
        private Player mPlayerA;
        private Player mPlayerB;
        private bool mGameOver;
        private Player mWinner;
        private Player mFirstService;

        public Score(bool playerAToServe)
        {
            newGame(playerAToServe);
        }

        public bool isGameOver() { return mGameOver; }
        public Player winner() { return mWinner; }

        public Player playerA() { return mPlayerA; }
        public Player playerB() { return mPlayerB; }

        public bool playerAToServeNow()
        {
            int pointsInSet = playerA().points() + playerB().points();
            int setNumber = playerA().sets() + playerB().sets() + 1;

            int mod = 4;
            int modRes = 1;
            if (pointsInSet >= 20)
            {
                mod = 2;
                modRes = 0;
            }

            bool result = false;
            result = (pointsInSet % mod <= modRes);

            if (mFirstService == mPlayerA)
            {
                return (setNumber % 2 == 1) ? result : !result;
            }
            else
            {
                return (setNumber % 2 == 1) ? !result : result;
            }
        }

        public void newGame(bool playerAToServe)
        {
            mPlayerA = new Player();
            mPlayerB = new Player();
            mWinner = null;
            mGameOver = false;

            mFirstService = playerAToServe ? mPlayerA : mPlayerB;
        }

        private void handlePoint(Player winner, Player loser)
        {
            winner.incPoints();
            
            // 11 oder mehr und 2 Vorsprung?
            if (winner.points() >= 11 && winner.points() - loser.points() >= 2)
            {
                // Satz für "winner"
                winner.incSets();
                winner.newSet();
                loser.newSet();

                if (winner.sets() >= 3)
                {
                    mGameOver = true;
                    mWinner = winner;
                }
            }
        }

        public void pointForPlayerA()
        {
            handlePoint(mPlayerA, mPlayerB);
        }

        public void pointForPlayerB()
        {
            handlePoint(mPlayerB, mPlayerA);
        }
    }
}
