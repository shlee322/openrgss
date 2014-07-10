namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class AudioFile
    {
        public string name="";
        public int volume=100;
        public int pitch=100;

        public AudioFile()
        {
        }

        public AudioFile(string name = "", int volume = 100, int pitch = 100)
        {
            this.name = name;
            this.volume = volume;
            this.pitch = pitch;
        }
    }
}
