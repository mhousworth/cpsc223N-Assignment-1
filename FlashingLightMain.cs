//Author: Michael Housworth
//Email: mhousworth@csu.fullerton.edu
//Course: CPSC 223n
//Semester: Fall 2019
//Assignment #: 1
//Program name: Flashing Red Stop Light

//Hardcopy of source files: The sources files of this program are best printed using 7-point monospaced font in protrait orientation.
//
using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main

public class FlashingLightMain{
  static void Main(string[] args){
    System.Console.WriteLine("Welcome to the Main method of the Flashing Red Stop Light program.");
    FlashingLightInterface FLapp = new FlashingLightInterface();
    Application.Run(FLapp);
    System.Console.WriteLine("Main method will now shutdown.");
  }//End of Main
}//End of Fibonaccimain
