using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedialPlayer
{
    class Bird
    {
        public string name;

        public Bird(string name)
        {
            this.name = name;
        }
    }

    public interface Fly
    {
        public void Fly();
        
    }

    class Penguin : Bird 
    {
        public Penguin(string name) : base(name)
        {
        }

        public void show() {
            Console.WriteLine(this.name);
        }
    }

    class KingFisher : Bird , Fly
    {
        public KingFisher(string name) : base(name)
        {
        }

        public void Fly()
        {
            Console.WriteLine($"{name} can fly");
        }

        public void show()
        {
            Console.WriteLine(this.name);
        }
    }
}
