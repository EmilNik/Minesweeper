using Minesweeper.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class TextFileDataManager : IDataManager
    {

        private const string DefaultScorePath = "../../../Minesweeper/files/scores.txt";

        private readonly string scoreFilePath;

        public TextFileDataManager()
        {
            this.scoreFilePath = DefaultScorePath;
        }

        public TextFileDataManager(string filePath)
        {
            this.scoreFilePath = filePath;
        }

        public Dictionary<string, int> Read()
        {
            StreamReader reader = new StreamReader(this.scoreFilePath);

            var resultScoreBoard = new Dictionary<string, int>();
            using (reader)
            {
                while (true)
                {
                    var currentLane = reader.ReadLine();
                    if (currentLane == null || currentLane.Trim() == string.Empty)
                    {
                        break;
                    }
                    var key = currentLane.Split('-')[0];
                    var value = int.Parse(currentLane.Split('-')[1]);
                    resultScoreBoard.Add(key, value);
                }
               
            }
            return resultScoreBoard;
        }

        public void Write(Dictionary<string, int> scoreBoard)
        {
            StreamWriter writer = new StreamWriter(this.scoreFilePath, false);
            
            using (writer)
            {
                foreach (var item in scoreBoard)
                {
                    writer.WriteLine("{0}-{1}", item.Key, item.Value);
                }
            }
        }
    }
}
