using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Day_Week_6
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            Console.WriteLine("Please choose a menu item.");

            List<string> teams = new List<string>() { "Marketing Team", "Administration Team", "All Team" };
            List<string> all = new List<string>() { "Addy Mince", "Yurdi Boss", "Bob From Accounting", "Mark Ketting", "Salya DeTings", "Cam Mershal" };
            List<string> marketing = new List<string>() { "Mark Ketting", "Salya DeTings", "Cam Mershal" };
            List<string> admin = new List<string>() { "Addy Mince", "Yurdi Boss", "Bob From Accounting" };

            Dictionary<string, string> zoo = new Dictionary<string, string>()
            {
                { "Mark Ketting", "Marketing Team" },
                { "Salya DeTings", "Marketing Team" },
                { "Cam Mershal", "Marketing Team" },
                { "Addy Mince", "Administration Team" },
                { "Yurdi Boss", "Administration Team" },
                { "Bob From Accounting", "Administration Team" }
            };


            string menuChoice;
            bool menuLoop = true;

            while (menuLoop)
            {
                PrintHeader();
                Console.WriteLine("Menu:\n\n1. Create Meeting\n2. View Team\n3. Exit\n\n");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        PrintHeader();

                        Console.WriteLine("For what date will these minutes be written?");
                        Console.WriteLine("Please enter in this format: MMDDYY");
                        string textFileName = "Minutes" + Console.ReadLine();
                        StreamWriter writer = new StreamWriter(textFileName + ".txt");
                        using (writer)
                        {
                            //Header
                            writer.WriteLine("MinuteMen Inc.");
                            writer.WriteLine("123 Type Street");
                            writer.WriteLine("Springfield, KV 43210");
                            writer.WriteLine("\"Meeting Minutes\"");
                            writer.WriteLine();
                            writer.WriteLine();

                            PrintHeader();

                            Console.WriteLine("\n\nSelect a Team");
                            foreach (string team in teams)
                            {
                                Console.WriteLine((teams.IndexOf(team) + 1) + ". " + team);

                            }
                            int teamSelect = int.Parse(Console.ReadLine()) - 1;
                            writer.WriteLine(teams[teamSelect] + " Meeting");


                            PrintHeader();

                            Console.WriteLine("Select a Team Lead");
                            foreach (string lead in all)
                            {
                                Console.WriteLine((all.IndexOf(lead) + 1) + ". " + lead);

                            }
                            int leadSelect = int.Parse(Console.ReadLine()) - 1;
                            writer.WriteLine("Team Lead: " + all[leadSelect]);


                            PrintHeader();

                            Console.WriteLine("Select a Team Scribe");

                            foreach (string scribe in all)
                            {
                                Console.WriteLine((all.IndexOf(scribe) + 1) + ". " + scribe);

                            }
                            int scribeSelect = int.Parse(Console.ReadLine()) - 1;
                            writer.WriteLine("Team Scribe: " + all[scribeSelect]);
                            writer.WriteLine();



                            bool notesloop = true;
                            bool titleloop = true;
                            bool newtopicloop = true;
                            while (newtopicloop)
                            {
                                PrintHeader();

                                Console.WriteLine("What is the Topic for this meeting?");
                                string topicSelect = Console.ReadLine();
                                writer.WriteLine("Meeting Topic: " + topicSelect);
                                writer.WriteLine();
                                titleloop = true;
                                while (titleloop)
                                {
                                    PrintHeader();

                                    Console.WriteLine("Meeting Topic: " + topicSelect);
                                    Console.WriteLine("(To Exit, type \"X\" on a new line and hit Enter.)");
                                    Console.WriteLine("\nEnter Meeting Notes:");
                                    notesloop = true;

                                    while (notesloop)
                                    {
                                        string a = Console.ReadLine();
                                        if (a == "X" || a == "x")
                                        {
                                            writer.WriteLine();
                                            notesloop = false;
                                            break;
                                        }
                                        writer.WriteLine(a);
                                    }

                                    PrintHeader();

                                    Console.WriteLine("Do you want to write another topic? y/n");
                                    string b = Console.ReadLine().ToUpper();
                                    if (b == "N")
                                    {
                                        titleloop = false;
                                        newtopicloop = false;
                                    }
                                    else
                                    {
                                        titleloop = false;
                                    }
                                }
                            }
                        }

                        PrintHeader();

                        Console.WriteLine("Summary of Meeting Notes:\n\n");
                        StreamReader reader = new StreamReader(textFileName + ".txt");
                        using (reader)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine(reader.ReadToEnd());
                            Console.ResetColor();

                            Console.WriteLine("Hit any key to continue.");
                            Console.ReadKey();
                        }

                        break;

                    //end of thing////////////////////////////////////////////////////////////

                    case "2":

                        bool viewLoop = true;
                        while (viewLoop)
                        {
                            PrintHeader();

                            Console.WriteLine("View Team");
                            Console.WriteLine("\n\nSelect a Team:\n");
                            int i = 1;
                            string[] teamNameArray = new string[teams.Count];
                            foreach (string team in teams)
                            {
                                Console.WriteLine(i + ". " + team);
                                teamNameArray[i - 1] = team; //team name
                                i++;
                            }
                            int viewTeamSelect = int.Parse(Console.ReadLine()) - 1;

                            PrintHeader();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(teamNameArray[viewTeamSelect] + ":\n");
                            Console.ResetColor();

                            i = 1;
                            foreach (KeyValuePair<string, string> name in zoo)
                            {
                                if (teamNameArray[viewTeamSelect] == "All Team")
                                {
                                    Console.WriteLine(i + ". " + name.Key + " (" + name.Value + ")");
                                    i++;
                                }
                                else
                                {
                                    if (name.Value == teamNameArray[viewTeamSelect])
                                    {
                                        Console.WriteLine(i + ". " + name.Key);
                                        i++;
                                    }
                                }
                            }

                            Console.WriteLine("\n\nView another team? y/n");
                            string viewAnother = Console.ReadLine().ToUpper();

                            if (viewAnother == "N")
                            {
                                viewLoop = false;
                            }
                        }

                        break;

                    case "3":
                        menuLoop = false;
                        break;

                    default:
                        break;
                }

            }

            PrintHeader();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n\n\n************  Goodbye  ************");
            Console.ResetColor();

            System.Threading.Thread.Sleep(1000);
            return;
        }

        static void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("\n***********************************************\n****  MEETING MINUTES MANAGEMENT SOFTWARE  ****\n***********************************************\n\n\n\n\n");
        }
    }
}
