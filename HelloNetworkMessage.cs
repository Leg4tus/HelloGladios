using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGladios
{
    public struct HelloNetworkMessage : IMultiplayerModMessage
    {
        public ushort GetMessageId()
        {
            return 34081; //this needs to be a unique value for your mod and message. If the value conflicts with another mod, then mods will not work correctly.
        }

        public int value;

    }
}
