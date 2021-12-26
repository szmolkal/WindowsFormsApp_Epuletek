using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp_Epuletek
{
    static class Program
    {

        public static Form_Nyito form_Nyito = null; //-- Deklarálás
        public static Form_Csaladihaz form_csaladihaz = null; //-- Deklarálás
        public static Form_Tombhaz form_Tombhaz = null; //-- Deklarálás
        static void Main()
        {
            /*-- https://docs.microsoft.com/en-us/dotnet/api/system.enum.parse?view=net-6.0
            *[Flags]
            *enum Colors { Red = 1, Green = 2, Blue = 4, Yellow = 8 };
            *
            *-- Enum.Parse Method
             *
            *Console.WriteLine("The entries of the Colors enumeration are:");
            *foreach (string colorName in Enum.GetNames(typeof(Colors)))
            *{
            *    Console.WriteLine("{0} = {1:D}", colorName,
            *                                 Enum.Parse(typeof(Colors), colorName));
            *}
            *Console.WriteLine();
            *
            *Colors orange = (Colors)Enum.Parse(typeof(Colors), "Red, Yellow"); //-- Típuskényszerítés!
            *Console.WriteLine("The orange value {0:D} has the combined entries of {0}",
            *                   orange);
            *Console.WriteLine();
            *
            * //-- Az orange nem kerül be a felsorolásba, lásd az újbóli kiíratást:
            *foreach (string colorName in Enum.GetNames(typeof(Colors)))
            *{
            *    Console.WriteLine("{0} = {1:D}", colorName,
            *                                 Enum.Parse(typeof(Colors), colorName));
            *}
            *
            *Console.WriteLine();
            */

            Application.EnableVisualStyles(); //Ez itt micsoda?
            Application.SetCompatibleTextRenderingDefault(false); //Ez itt micsoda?
            form_Nyito = new Form_Nyito(); //-- Példányosítás
            form_csaladihaz = new Form_Csaladihaz(); //-- Példányosítás
            form_Tombhaz = new Form_Tombhaz(); //-- Példányosítás

            Application.Run(form_Nyito);
        }
    }
}
