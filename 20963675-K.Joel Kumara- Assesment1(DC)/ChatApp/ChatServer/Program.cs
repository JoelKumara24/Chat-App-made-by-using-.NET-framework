using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hey so like welcome to my server");

            // Declare a ServiceHost instance
            ServiceHost host;

            // Create a TCP binding
            NetTcpBinding tcp = new NetTcpBinding();

            // Bind the server to the implementation of DataServer
            host = new ServiceHost(typeof(DataserverInterfaceImpl));
            tcp.MaxReceivedMessageSize = 100000000;
            // Add a service endpoint to the host
            // DataServerInterface is the interface defined in the previous steps
            host.AddServiceEndpoint(typeof(DataserverInterface), tcp, "net.tcp://0.0.0.0:8100/DataService");

            // Open the host for business
            host.Open();

            // Display a message that the system is online
            Console.WriteLine("System Online");

            // Wait for user input to exit the application
            Console.ReadLine();

            // Close the host when the application is done
            host.Close();
        }
    }
}
