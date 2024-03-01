namespace NetClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Listen();
            while(true)
            {

            }
        }
    }
}
