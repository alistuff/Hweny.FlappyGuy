using System.Drawing;
using System.IO;
using System;
using System.Text;

namespace Hweny.FlappyGuy.Entity
{
    public class ScoreRecord
    {
        private int scoreRecord = 0;

        public int Score
        {
            get;
            private set;
        }
        public int HighScore
        {
            get;
            private set;
        }

        public ScoreRecord()
        {
            Score = 0;
            HighScore = 0;
        }

        public void Load(string fileName)
        {
            if (!File.Exists(fileName)) return;

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    byte[] buffer = Convert.FromBase64String(sr.ReadToEnd());
                    HighScore = int.Parse(Encoding.Default.GetString(buffer));
                }
            }
            catch(Exception e) 
            {
#if DEBUG
                Console.WriteLine(e.Message);
#endif
            }
        }
        public void Save(string fileName)
        {
            if (scoreRecord < HighScore) return;

            try
            {
                HighScore = scoreRecord;
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    byte[] buffer = Encoding.Default.GetBytes(HighScore.ToString());
                    sw.Write(Convert.ToBase64String(buffer));
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.Message);
#endif
            }
        }
        public void Reset()
        {
            AdjustHighScore();
            Score = 0;
        }
        public void Increase()
        {
            Score += 1;
            AdjustHighScore();
        }
        public void Render(Graphics g)
        {
            using (Font font = new Font("微软雅黑", 35f, FontStyle.Bold))
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                g.DrawString(Score.ToString(), font, Brushes.Snow, new Rectangle(0, 50, MyGame.WIDTH, 50), format);
                format.Dispose();
                format = null;
            }
        }

        private void AdjustHighScore()
        {
            scoreRecord = Score;
            if (scoreRecord > HighScore)
            {
                HighScore = scoreRecord;
            }
        }
    }
}
