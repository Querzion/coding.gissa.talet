using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GissaTalet
{
    // =======================================================================================================
    // =======================================================================================================
    // ====================================       HIGHSCORE SECTION       ====================================
    // =======================================================================================================
    // =======================================================================================================
    //      https://stackoverflow.com/questions/19456408/add-a-highscore-system-thats-saves-the-data

    [Serializable()]
    public class HighScore
    {
        public int ScoreValue { get; set; }

        public string PlayerName { get; set; } = string.Empty;
    }
}
