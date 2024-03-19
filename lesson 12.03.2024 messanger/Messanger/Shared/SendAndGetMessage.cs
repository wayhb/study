﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared
{
    public abstract class SendAndGetMessage
    {
        protected NetworkStream __stream;
        public void SendMessage(NetMessage message)
        {
            JsonSerializer.Serialize(__stream, message);
            __stream.Flush();
        }

    }
}
