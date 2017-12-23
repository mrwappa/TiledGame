using System.Collections.Generic;

namespace TileGame.Code
{
    class Alarm
    {
        public int Tick { get; set; }

        public static List<Alarm> Alarms = new List<Alarm>();

        public Alarm()
        {
            Alarms.Add(this);
            Tick = -1;
        }

        public void Decrement()
        {
            Tick--;
            if(Tick <= -1)
            {
                Tick = -1;
            }
        }
    }
}
