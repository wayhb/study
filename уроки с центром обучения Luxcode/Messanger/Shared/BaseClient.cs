using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Shared.Messages;

namespace Shared {
  public abstract class BaseClient : IDisposable {
    protected TcpClient _tcp_client;
    protected NetworkStream _stream;
    BinaryReader __reader;
    BinaryWriter __writer;
    public bool Active { get; protected set; }
    protected void _Activate(TcpClient tcp_client) {
      _tcp_client = tcp_client;
      _stream = tcp_client.GetStream();
      __reader = new(_stream);
      __writer = new(_stream);
      Console.WriteLine("Клиент: активирован.");
    }
    public void Deactivate() {
      Active = false;
      Console.WriteLine("Клиент: деактивирован.");
    }

    readonly Stack<BaseMessage> __messages = new();
    readonly MemoryStream __buffer = new(1024);
    public void SendMessage(BaseMessage message)
      => __messages.Push(message);
    protected abstract void _ReceiveMessage(BaseMessage message);

    public bool Tick() {
      if(_stream.DataAvailable) {
        try {
          var length = __reader.ReadUInt16();
          if(length > 0) {
            __buffer.SetLength(length);
            __buffer.Position = 0;
            _stream.ReadExactly(__buffer.GetBuffer().AsSpan(0, length));
            try {
              var message = JsonSerializer.Deserialize<BaseMessage>(__buffer);
              Console.WriteLine($"{message.GetType().Name}[{length}]: получено.");
              _ReceiveMessage(message);
            } catch {
              Console.WriteLine($"[{length}]: не получено.");
            }
          }
        } catch {
          return false;
        }
      }
      if(__messages.Count > 0) {
        var message = __messages.Pop();
        do {
          __buffer.SetLength(0);
          __buffer.Position = 0;
          JsonSerializer.Serialize(__buffer, message);
          try {
            __writer.Write((ushort)__buffer.Length);
            __buffer.Position = 0;
            __buffer.CopyTo(_stream);
            Console.WriteLine($"{message.GetType().Name}[{(ushort)__buffer.Length}]: отправлено.");
          } catch {
            return false;
          }
        } while(__messages.TryPop(out message));
      } else
        try {
          __writer.Write((ushort)0);
        } catch {
          return false;
        }
      return true;
    }

    public void Dispose() {
      __buffer.Dispose();
      _stream.Dispose();
      _tcp_client.Dispose();
    }
  }
}
