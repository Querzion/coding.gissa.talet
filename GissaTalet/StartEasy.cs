using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GissaTalet
{
    internal class Easy
    {
        // =======================================================================================================
        // ====================================       HIGHSCORE LISTING       ====================================
        // =======================================================================================================

        public static List<HighScore> _Scores = new List<HighScore>();


        // =======================================================================================================
        // =====================================      GAME SECTION       =========================================
        // =======================================================================================================
        // =====================================    GISSA TALET - EASY    ========================================
        // ======================================================================================================= 

        public static void GissaTalet()
        {
            string Input;                   //  Multipurpose User Inputs.
            int i = 0;                      //  Loop Index variable.
            
            Console.WriteLine("\n*********************** GISSA TALET! - LÄTT ************************\n" +
                              "\n 'Gissa Talet' går ut på att gissa rätt nummer. " +
                              "\nLätt är satt på: 1-100. \n" +
                              "\n Spelregler: Forever young.\n" +
                              "\n********************************************************************\n");

            //  Create Random number:
            Random genNR = new Random();
            int RandomNR = genNR.Next(1, 100);

            //  Create Do-While loop: 
            do
            {
                //  Create user variable input:
                Console.Write("\n Skriv in ett tal: (1-100) >> ");
                Input = Console.ReadLine();
                int Guess = Convert.ToInt32(Input);

                //  Create a difference check variable:
                int difference = RandomNR - Guess;

                //  Statements for the loop:
                if (Guess >= 1 && Guess < 101)                                                                  //  If userInput is above or equal to 1 and less then 101 it's a go.
                {
                    if (Guess == RandomNR)                                                                             //  If userInput is equal to rndNR, then this alternative is applied.
                    {
                        Console.Clear();
                        Console.WriteLine("\n********************************************************************\n" +
                                        "\n GRATTIS! - du gissade rätt, och du behövde {0} gissningar på dig. \n", i);

                        Console.Write(" Numret var: {0} \n Skriv in ditt namn: >> ", RandomNR);

                        var Score = new HighScore() { ScoreValue = Convert.ToInt32(i), PlayerName = Convert.ToString(Console.ReadLine()) };
                        Easy._Scores.Add(Score);

                        var serializer = new XmlSerializer(Easy._Scores.GetType(), "EasyScore.Scores");
                        using (var writer = new StreamWriter("EasyScores.xml", false))
                        {
                            serializer.Serialize(writer.BaseStream, Easy._Scores);
                        }
                        
                        break;                      
                    }
                    else if (Guess < RandomNR)                                                          //  Else If userInput is less then rndNR, then this alternative is applied.
                    {
                        if (-5 <= difference && difference <= 5)                                        //  If the userInput is within 5 number of the random number this alternative is applied.
                        {
                            Console.WriteLine(" Ditt tal var för litet. Gissa på ett större tal." +
                                          "\n Du är dock nära! Det bränns.");
                        }
                        else                                                                            
                        {
                            Console.WriteLine(" Ditt tal var för litet. Gissa på ett större tal.");
                        }
                    }
                    else if (Guess > RandomNR)                                                          //  Else If userInput is more then rndNR, then this alterantive is applied.
                    {
                        if (-5 <= difference && difference <= 5)                                        //  If the userInput is within 5 numbers of the rndNR value this alternative is applied. 
                        {
                            Console.WriteLine(" Ditt tal var för högt. Gissa på ett mindre tal." +
                                          "\n Du är dock nära! Det bränns.");
                        }
                        else                                                                            
                        {
                            Console.WriteLine(" Ditt tal var för högt. Gissa på ett mindre tal.");
                        }
                    }
                }
                else                                                                                     //  If none of the above, this is used.
                {
                    Console.WriteLine(" Du måste välja ett tal mellan 1 och 100!");
                }

                i++;                                                                                     //  Add 1 to index variable after every loop.                  
                continue;

            //  LOOP SETTINGS: 'i < x' (Loop Limiter) or 'Convert.ToInt32(Input) != RandomNR' (Endless Tries)  
            } while (Convert.ToInt32(Input) != RandomNR);


            // =======================================================================================================
            // =======================================================================================================
            // ====================================       HIGHSCORE SECTION       ====================================
            // =======================================================================================================
            // =======================================================================================================


            Console.WriteLine("\n********************************************************************\n" +
                              "\n Tack för att du spelat: GISSA TALET! " +
                              "\n Om du vill spela det igen är det bara att starta en ny omgång.\n" +
                              "\n********************************************************************\n" +
                              "\n Tryck ENTER för att återgå till menyn.");
        }
    }
}
