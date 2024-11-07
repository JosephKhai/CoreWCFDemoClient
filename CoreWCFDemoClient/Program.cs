using ServiceReference1;

namespace CoreWCFDemoClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WCF().GetAwaiter().GetResult();
        }


        public static async Task WCF()
        {
            while (true)
            {
                var client = new EchoServiceClient(EchoServiceClient.EndpointConfiguration.BasicHttpBinding_IEchoService, "http://localhost:6000/EchoService/basichttp");

                //Console.WriteLine("Enter a message!");
                //string input = Console.ReadLine();

                //var simpleResult = await client.EchoAsync(input);


                Console.WriteLine("Enter a message!");
                string input2 = Console.ReadLine();

                var msg = new EchoMessage()
                {
                    Text = input2
                };

                var msgResult = await client.ComplexEchoAsync(msg);
            }

        }
    }
}