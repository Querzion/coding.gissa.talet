using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GissaTalet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ==================================================================================================================================
            // ==================================================================================================================================
            // ==================================================       VARIABLE SECTION       ==================================================
            // ==================================================================================================================================
            // ==================================================================================================================================


            // Play Music: Downloaded from https://archive.org/details/TobyFoxMegalovania
            Ambiance.PlayMusic("bgm.wav");

            string Choices;
            int MenuChoice = 0;

            // ==================================================================================================================================
            // ==================================================================================================================================
            // ==================================================       MENU SECTION       ======================================================
            // ==================================================================================================================================
            // ==================================================================================================================================


            //  LOOP THE MENU - TRUE
            while (true)
            {
                //  CLEAR SCREEN
                Console.Clear();

                //  OUTPUT MENU OPTIONS
                Console.WriteLine("\n" +
                                  "\n*************************** GISSA TALET! ***************************\n" +
                                  "\n VÄLJ SVÅRIGHETSGRAD >> \n" +
                                  "\n [1]. Starta Spel: 'Lätt'" +
                                  "\n [2]. Starta Spel: 'Medel'" +
                                  "\n [3]. Starta Spel: 'Svår'" +
                                  "\n [4]. Starta Spel: 'Hardcore'\n" +
                                  "\n [5]. HighScore: Poänglistor \n" +
                                  "\n [6]. Avsluta Programmet: \n" +
                                  "\n********************************************************************\n");

                //  USER INPUT
                Console.Write("\n Skriv in ditt meny val: ");
                MenuChoice = Convert.ToInt32(Console.ReadLine());

                Console.Write("\n********************************************************************\n");

                //  CONDITIONS FOR MENU
                if (MenuChoice == 1)
                {
                    Console.Clear();
                    Easy.GissaTalet();
                    Console.ReadKey();
                }
                else if (MenuChoice == 2)
                {
                    Console.Clear();
                    Medium.GissaTalet();
                    Console.ReadKey();
                }
                else if (MenuChoice == 3)
                {
                    Console.Clear();
                    Hard.GissaTalet();
                    Console.ReadKey();
                }
                else if (MenuChoice == 4)
                {
                    Console.Clear();
                    Hardcore.GissaTalet();
                    Console.ReadKey();
                }
                else if (MenuChoice == 5)   //  HERE STARTS THE HIGHSCORE MENU
                {
                    while(true) {
                        
                        Console.Clear();

                        Console.WriteLine("\n" + 
                                          "\n*************************** HIGHSCORE BOARDS! ***************************\n" +
                                          "\n [1]. HIGHSCORE: 'Lätt'" +
                                          "\n [2]. HIGHSCORE: 'Medel'" +
                                          "\n [3]. HIGHSCORE: 'Svår'" +
                                          "\n [4]. HIGHSCORE: 'Hardcore'\n" +
                                          "\n [6]. Tillbaka: \n" +
                                          "\n********************************************************************\n");

                        Console.Write("\n Skriv in ditt val: ");
                        MenuChoice = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\n********************************************************************\n");

                        if (MenuChoice == 1)            //  EASY
                        {
                            Console.Clear();
                            
                            var serializer = new XmlSerializer(Easy._Scores.GetType(), "EasyScore.Scores");
                            object obj;
                            using (var reader = new StreamReader("EasyScores.xml"))
                            {
                                obj = serializer.Deserialize(reader.BaseStream);
                            }
                            Easy._Scores = (List<HighScore>)obj;
                            
                            Console.WriteLine(Easy._Scores);

                            Console.ReadKey();
                        }
                        else if (MenuChoice == 2)       //  MEDIUM
                        {
                            Console.Clear();

                            var serializer = new XmlSerializer(Medium._Scores.GetType(), "MediumScore.Scores");
                            object obj;
                            using (var reader = new StreamReader("MediumScores.xml"))
                            {
                                obj = serializer.Deserialize(reader.BaseStream);
                            }
                            Medium._Scores = (List<HighScore>)obj;

                            Console.WriteLine(Medium._Scores);

                            Console.ReadKey();
                        }
                        else if (MenuChoice == 3)       //  HARD
                        {
                            Console.Clear();

                            var serializer = new XmlSerializer(Hard._Scores.GetType(), "HardScore.Scores");
                            object obj;
                            using (var reader = new StreamReader("HardScores.xml"))
                            {
                                obj = serializer.Deserialize(reader.BaseStream);
                            }
                            Hard._Scores = (List<HighScore>)obj;

                            Console.WriteLine(Hard._Scores);

                            Console.ReadKey();
                        }
                        else if (MenuChoice == 4)       //  HARDCORE
                        {
                            Console.Clear();

                            var serializer = new XmlSerializer(Hardcore._Scores.GetType(), "HardcoreScore.Scores");
                            object obj;
                            using (var reader = new StreamReader("HardcoreScores.xml"))
                            {
                                obj = serializer.Deserialize(reader.BaseStream);
                            }
                            Hardcore._Scores = (List<HighScore>)obj;

                            Console.WriteLine(Hardcore._Scores);

                            Console.ReadKey();
                        }
                        //  EXIT THE HIGHSCORE SECTION
                        else if (MenuChoice == 6)   
                        {
                            Console.Clear();
                            break;
                        }
                        //  IF THE USER VALUE IS OUTSIDE MENU SCOPE/SIZE
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n Du gjorde inget giltilgt val!" +
                                              "\n Gå tillbaka till menyn och gör ett nytt val!\n" +
                                              "\n********************************************************************\n" +
                                              "\n Tryck enter för att gå tillbaka till menyn.");

                            Console.ReadKey();
                        }

                    }
                }

                //  EXIT THE APPLICATION
                else if (MenuChoice == 6)
                {
                    Console.Clear();
                    Console.WriteLine("\n Du har valt att avsluta programmet! \n" +
                                      "\n********************************************************************\n" +
                                      " Tryck enter för att Avsluta programmet.");
                    Console.ReadKey();
                    break;
                }
                //  IF THE USER VALUE IS OUTSIDE MENU SCOPE/SIZE
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n Du gjorde inget giltilgt val!" +
                                      "\n Gå tillbaka till menyn och gör ett nytt val!\n" +
                                      "\n********************************************************************\n" +
                                      "\n Tryck enter för att gå tillbaka till menyn.");

                    Console.ReadKey();
                }
            }
        }
    }
}