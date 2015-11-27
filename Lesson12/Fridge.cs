using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson12
{   
    [Serializable]
    //public 
        class Fridge
    {
        private bool power;
        private FridgeModes mode;
        private string powerMess;

        public bool Power
        {
            get
            {
                string readPath = "lol.txt";
                    using (BinaryReader sr = new BinaryReader(File.Open(readPath, FileMode.Open)))
                    {
                        return sr.ReadBoolean();
                    }
            }
            set
            {
                string writePath = "lol.txt";
                    using (BinaryWriter sr = new BinaryWriter (File.Open(writePath, FileMode.OpenOrCreate)))
                    {
                        sr.Write(value);
                    }
            }
        }

        public Fridge(bool power, FridgeModes mode)
        {
            this.power = power;
            this.mode = mode;
            this.powerMess = " ";
        }

        public Fridge() { }
        public void On()
        {
            if (!Power)
            {
                Power = true;
                mode = FridgeModes.normal;
                powerMess = " ";
            }


        }

        public void Off()
        {
            if (Power)
            {
                Power = false;
                mode = FridgeModes.south;
                powerMess = "Холодильник выключен, продукты портятся!";
            }

        }


        public void Normal()
        {
            if (Power)
            {
                mode = FridgeModes.normal;
            }
            else
            {
                powerMess = "Включите холодос!";
            }

        }

        public void North()
        {
            if (Power)
            {
                mode = FridgeModes.north;
            }
            else
            {
                powerMess = "Включите холодос!";
            }
        }

        public void South()
        {
            if (Power)
            {
                mode = FridgeModes.south;
            }
            else
            {
                powerMess = "Включите холодос!";
            }
        }


        public string Info()
        {
            string power;
            if (Power)
            {
                power = "включен";
            }
            else
            {
                power = "выключен";
            }

            string mode;
            if (this.mode == FridgeModes.normal)
            {
                mode = "нормальный";
            }
            else if (this.mode == FridgeModes.north)
            {
                mode = "заморозки к чертям";
            }
            else
            {
                mode = "разморозки к лужам";
            }

            return "Состояние холодильника: " + Power + ", режим: " + mode + "\n" + powerMess;
        }

    }
}
