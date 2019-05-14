using System;
using SplunkLogger.Writer;

namespace SplunkLogger.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to send the message to splunk");
            Console.ReadLine();
            Serilog.Debugging.SelfLog.Enable(Console.Error);

            try
            {
                using (var logService = new MicrosoftSplunkLogService())
                {
                    logService.WriteInformation("JSON message from HMDAWiz SplunkLogger.Client");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.WriteLine("Message is sent without exception. Press any key to exit");
            Console.Read();
        }
    }
}
