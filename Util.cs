using System;
using System.Collections.Generic;
using System.Text;

namespace MudkipzCraft
{
    class Util
    {
        public static void PrintBanner()
        {
            Console.WriteLine("    /|    //| |                                                    ");
            Console.WriteLine("   //|   // | |              ___   / / ___     ( )  ___     ___    ");
            Console.WriteLine("  // |  //  | |   //   / / //   ) / //\\ \\     / / //   ) )    / /  ");
            Console.WriteLine(" //  | //   | |  //   / / //   / / //  \\ \\   / / //___/ /    / /   ");
            Console.WriteLine("//   |//    | | ((___( ( ((___/ / //    \\ \\ / / //          / /__  ");
            Console.WriteLine();
        }
        public static void DebugPause()
        { 
            Console.ReadKey();
        }
    }
}
