using System.Media;

namespace GissaTalet
{
    internal class Ambiance
    { 

        public static void PlayMusic(string filepath)
        {

            SoundPlayer BGM = new SoundPlayer();

            BGM.SoundLocation = filepath;
            BGM.PlayLooping();
        }
    }
}
