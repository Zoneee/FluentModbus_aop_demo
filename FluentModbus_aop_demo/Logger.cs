using System;

namespace FluentModbus_aop_demo
{
    public class Logger : ILogger
    {
        public Logger(ConsoleColor color)
        {
            Color = color;
        }

        public ConsoleColor Color { get; set; }

        public void Log(string message)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}