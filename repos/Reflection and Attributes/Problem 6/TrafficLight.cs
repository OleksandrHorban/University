namespace TrafficLights.Models
{
    using System;
    using Enums;

    public class TrafficLight
    {
        public TrafficLight(string color)
        {
            this.Color = Enum.Parse<Color>(color);
        }

        public Color Color { get; protected set; }

        public void ChangeColor()
        {
            this.Color += 1;
            if ((int)this.Color > 2)
            {
                this.Color = 0;
            }
        }

        public override string ToString()
        {
            return $"{this.Color}";
        }
    }
}
