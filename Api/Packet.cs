using System;

namespace Matriks.API.Shared
{
    [Serializable]
    public class Packet
    {
        public int ApiCommands { get; set; }

        [NonSerialized] public string Text;
        [NonSerialized] public byte[] Payload;


    }
}