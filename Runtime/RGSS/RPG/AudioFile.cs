using IronRuby.Builtins;
using System;
using System.Runtime.Serialization;
namespace OpenRGSS.Runtime.RGSS.RPG
{
    [Serializable]
    public class AudioFile : ISerializable
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

        public AudioFile(SerializationInfo info, StreamingContext context)
        {
            this.name = ((MutableString)info.GetValue("@name", typeof(MutableString))).ConvertToString();
            this.volume = (int)info.GetValue("@volume", typeof(int));
            this.pitch = (int)info.GetValue("@pitch", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}
