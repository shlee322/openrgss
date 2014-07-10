using System.Collections.Generic;

namespace OpenRGSS.Runtime.RGSS.RPG
{
    public class CommonEvent
    {
        public int id;
        public string name;
        public int trigger;
        public int switch_id;
        public IList<EventCommand> list;
    }
}
