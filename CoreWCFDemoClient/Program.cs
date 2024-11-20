
//using PareXPlusWCFServer;
using System.ServiceModel;
using ServiceReference4;

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

                // Instantiate the Service wrapper specifying the binding and optionally the Endpoint URL. The BasicHttpBinding could be used instead.

                //var client = new EchoServiceClient(EchoServiceClient.EndpointConfiguration.BasicHttpBinding_IEchoService, "http://localhost:6000/EchoService/basichttp");
                //var client = new PublisherClient(PublisherClient.EndpointConfiguration.BasicHttpBinding_Publisher, "http://parexplus-uat.pentanasolutions.com/PareXPlus.WCFService.Publisher/Publisher.svc");
                //var client = new PublisherClient(PublisherClient.EndpointConfiguration.BasicHttpBinding_Publisher, "http://localhost:6000/Publisher.svc");

                //var client = new PublisherClient(PublisherClient.EndpointConfiguration.BasicHttpBinding_Publisher, "http://localhost:6000/Publisher.svc");

                var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport); // Transport mode for HTTPS
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None; // or set as needed

                // Configure the endpoint address
                var endpointAddress = new EndpointAddress("https://parexplus-uat.pentanasolutions.com/PAREXPLUS.WCFSERVICE.PUBLISHER/Publisher.svc");

                // Initialize the PublisherClient with the binding and endpoint
                var client = new PublisherClient(binding, endpointAddress);


                Console.WriteLine("Enter a message!");
                string input2 = Console.ReadLine();

                //var msg = new EchoMessage()
                //{
                //    Text = input2
                //};

                //PublisherClient client = new PublisherClient();

                var webService = new WebserviceProcess()
                {
                    Entity_Type = input2,
                    Entity_Name = "FIARNZ",

                    Entity_Level1_Type = "Org",
                    Entity_Level1_Name = "ATECO",
                    Entity_Level2_Type = "",
                    Entity_Level2_Name = "",

                    Integration_Type = "FTP",
                    Primary_File_Name = "FIARNZ-Factory Master-Fullset-20241014013001.csv",
                    Secondary_File_Name = "FIARNZ-Factory Master-Fullset-20241014013001.csv",
                    File_Location = "/CHINTEST/ATECO/LDVPDC/Inbound/FactoryMaster/",
                    Created_Date_Time = DateTime.Now,
                    File_Type = "Factory Master",
                    Format_Type = "Existing",
                    Error_Message = ""
                };


                try
                {

                    var simpleResult = await client.NotifyInboundDataAsync(webService);
                    Console.WriteLine(simpleResult);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    client.Close();
                }

            }

        }
    }
}