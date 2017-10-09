using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Space;

namespace Life{
    class Program{
        static void Main(string[] args){
            Region game = new Region(2,10);
            Console.WriteLine("This game of life has a max size of {0}, with a default state of {1}.", game.GetSize(), game.GetDefaultState());
            game.AddInitialCoordinate(new int[] { 0, 0 }, State.Green);
            game.AddInitialCoordinate(new int[] { 3, 2 }, State.Blue);
            game.AddInitialCoordinate(new int[] { 9, 0 }, State.Red);
            game.AddInitialCoordinate(new int[] { 0, 1 }, State.Red);
            game.AddInitialCoordinate(new int[] { 0, 2 }, State.Blue);
            game.AddInitialCoordinate(new int[] { 5, 5 }, State.Red);
            game.AddInitialCoordinate(new int[] { 9, 9 }, State.Blue);
            game.AddInitialCoordinate(new int[] { 4, 4 }, State.Green);
            game.AddInitialCoordinate(new int[] { 7, 6 }, State.Green);
            game.PrintSpace();
        }
    }
}
