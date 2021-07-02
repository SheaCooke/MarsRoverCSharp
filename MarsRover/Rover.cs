using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public string ReceiveMessage(Message message)
        {
            foreach (var i in message.Commands)
            {
                if (i.CommandType == "MODE_CHANGE")
                {
                    if (i.NewMode == "LOW_POWER")
                    {

                        this.Mode = "LOW_POWER";

                        return "Mode changed to LOW_POWER";

                    }
                    else if (i.NewMode == "NORMAL")
                    {
                        this.Mode = "NORMAL";
                        return "Mode changed to NORMAL";
                    }
                    else
                    {
                        return "Invalid Entry.";
                    }
                }
                else if (i.CommandType == "MOVE")
                {
                    if (i.NewPostion <= 0 || i.NewPostion.GetType() != typeof(int))
                    {
                        return "Invalid Entry.";
                    }

                    else if (this.Mode != "LOW_POWER")
                    {
                        Position = i.NewPostion;
                        return "Position changed";
                    }
                    else
                    {
                        return "Cannot change position while in LOW_POWER mode.";
                    }
                    
                }

                else
                {
                    
                    return "Invalid Entry.";
                }
            }
            return "No commands were provided";

        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
