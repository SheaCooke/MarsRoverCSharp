using System;
namespace MarsRover
{
    public class Message
    {
        public string Name { get; set; }
        public Command[] Commands { get; set; }

        public Message(string name, Command[] commands)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name, "Message required.");
            }
            else
            {
                Name = name;
                Commands = commands;
            }
        }
    }
}
