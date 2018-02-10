using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Car
    {
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        private bool carIsDead;
        private Radio theMusicBox = new Radio();
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }
        public void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
                CurrentSpeed += delta;
            if (CurrentSpeed > MaxSpeed)
            {
                carIsDead = true;
                CurrentSpeed = 0;
                Exception ex = new Exception(string.Format("{0} has overheated!", PetName));
                ex.HelpLink = "http://www.CarsRUs.com";
                ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
                ex.Data.Add("Cause", "You hav a lead foot");
                throw ex;
            }
            else
                Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
        }
    }
}
