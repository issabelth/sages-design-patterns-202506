using NGeoHash;
using System;

namespace AdapterPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Adapter Pattern!");

            MotorolaRadioTest();

            HyteraRadioTest();

        }

        private static void MotorolaRadioTest()
        {
            MotorolaRadio radio = new MotorolaRadio();
            radio.PowerOn("1234");
            radio.SelectChannel(10);
            radio.Send("Hello World!");
            radio.PowerOff();
        }

        private static void HyteraRadioTest()
        {
            HyteraRadio radio = new HyteraRadio();
            radio.Init();
            radio.SendMessage(10, "Hello World!");
            radio.Release();
        }
    }

    


}
