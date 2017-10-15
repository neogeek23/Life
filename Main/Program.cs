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
//            Region game = new Region(2,12);
//            game.AddInitialCoordinate(new int[] { 0, 0 }, State.Green);
//            game.AddInitialCoordinate(new int[] { 3, 2 }, State.Blue);
//            game.AddInitialCoordinate(new int[] { 9, 0 }, State.Red);
//            game.AddInitialCoordinate(new int[] { 0, 1 }, State.Red);
//            game.AddInitialCoordinate(new int[] { 0, 2 }, State.Blue);
//            game.AddInitialCoordinate(new int[] { 5, 5 }, State.Red);
//            game.AddInitialCoordinate(new int[] { 9, 9 }, State.Blue);
//            game.AddInitialCoordinate(new int[] { 4, 4 }, State.Green);
//            game.AddInitialCoordinate(new int[] { 7, 6 }, State.Green);
//
//            Region game = new Region(3, 12);
//            game.AddInitialCoordinate(new int[] { 0, 0, 0 }, State.Green);
//            game.AddInitialCoordinate(new int[] { 3, 2, 1 }, State.Blue);
//            game.AddInitialCoordinate(new int[] { 9, 0, 2 }, State.Red);
//            game.AddInitialCoordinate(new int[] { 0, 1, 3 }, State.Red);
//            game.AddInitialCoordinate(new int[] { 0, 2, 4 }, State.Blue);
//            game.AddInitialCoordinate(new int[] { 5, 5, 5 }, State.Red);
//            game.AddInitialCoordinate(new int[] { 9, 9, 6 }, State.Blue);
//            game.AddInitialCoordinate(new int[] { 4, 4, 7 }, State.Green);
//            game.AddInitialCoordinate(new int[] { 7, 6, 8 }, State.Green);

            Region game = new Region(5, 5);
            game.AddInitialCoordinate(new int[] { 0, 0, 0, 0, 0 }, State.Green);
            game.AddInitialCoordinate(new int[] { 3, 2, 2, 0, 0 }, State.Blue);
            game.AddInitialCoordinate(new int[] { 1, 0, 1, 0, 0 }, State.Red);
            game.AddInitialCoordinate(new int[] { 0, 1, 0, 2, 0 }, State.Red);
            game.AddInitialCoordinate(new int[] { 0, 2, 0, 0, 0 }, State.Blue);
            game.AddInitialCoordinate(new int[] { 3, 2, 0, 1, 0 }, State.Red);
            game.AddInitialCoordinate(new int[] { 1, 1, 0, 2, 0 }, State.Blue);
            game.AddInitialCoordinate(new int[] { 3, 3, 0, 3, 0 }, State.Green);
            game.AddInitialCoordinate(new int[] { 2, 1, 3, 1, 0 }, State.Green);

            Console.WriteLine("This game of life has a max size of {0} in {2} dimension(s), with a default state of {1}.", game.GetSize(), game.GetDefaultState(), game.GetDimensionCount());
            game.PrintSpace();
        }
    }
}
