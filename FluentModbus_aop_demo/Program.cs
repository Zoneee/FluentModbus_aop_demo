using System;

namespace FluentModbus_aop_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var requestMessage = "01 06 00 01 00 32 A8 3D";
            var redLogger = new Logger(ConsoleColor.Red);
            var yellowLogger = new Logger(ConsoleColor.Yellow);
            var client = new Client()
            {
                RequestEventHandler = new EventHandler<string>((e, c) =>
                {
                    redLogger.Log(c);
                }),
                ResponseEventHandler = new EventHandler<string>((e, c) =>
                 {
                     yellowLogger.Log(c);
                 }),
                RequestHandler = ModifyMessage,
                ResponseHandler = ModifyMessage,
            };

            Console.WriteLine($"Modify before");
            Console.WriteLine(requestMessage);
            Console.WriteLine();
            Console.WriteLine($"Modify after");
            var result = client.ReadCoils(requestMessage);
        }

        private static string ModifyMessage(string message)
        {
            message = "00 00 00 00 00 00 00 00";
            return message;
        }
    }
}