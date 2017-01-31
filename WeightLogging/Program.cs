using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "weightlog.txt");
            Workout w = new Workout();
            string old = "";
            string choice = "";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to weight logger. Type !help for a list of commands.");
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.Write(">");
                choice = Console.ReadLine().ToLower();

                if (choice == "help")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\tCommand\t\tDescription");
                    Console.WriteLine("");
                    Console.WriteLine("\tview\t\t View past workouts");
                    Console.WriteLine("\tadd\t\t Add new workout");
                    Console.WriteLine("\thelp\t\t Show list of commands");
                    Console.WriteLine("\texit\t\t Exits the console app");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (choice == "view")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(ORM.ReadFile(path));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (choice == "add")
                {
                    Console.WriteLine("How much do you weigh in kg?");
                    w.Weight = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Pushup?");
                    w.Pushups = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Sit-ups?");
                    w.Situps = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Hover in seconds");
                    w.Hover = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Step-ups?");
                    w.Stepups = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Squats?");
                    w.Squats = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Lunge?");
                    w.Lunges = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("");

                    try
                    {
                        old = ORM.ReadFile(path);
                    }
                    catch (FileNotFoundException)
                    {
                        ORM.WriteFile(path, "");
                        old = ORM.ReadFile(path);
                    }

                    List<Workout> WorkoutList = Workout.ConvertToObject(old);
                    try
                    {
                        decimal updatedWeight = w.Weight - WorkoutList[WorkoutList.Count - 1].Weight;
                        int updatedPushups = w.Pushups - WorkoutList[WorkoutList.Count - 1].Pushups;
                        int updatedSitups = w.Situps - WorkoutList[WorkoutList.Count - 1].Situps;
                        decimal updatedHover = w.Hover - WorkoutList[WorkoutList.Count - 1].Hover;
                        int updatedStepups = w.Stepups - WorkoutList[WorkoutList.Count - 1].Stepups;
                        int updatedSquats = w.Squats - WorkoutList[WorkoutList.Count - 1].Squats;
                        int updatedLunges = w.Lunges - WorkoutList[WorkoutList.Count - 1].Lunges;
                        Console.WriteLine("Weight loss: " + updatedWeight + "kgs");
                        Console.WriteLine("Pushups: +" + updatedPushups);
                        Console.WriteLine("Situps: +" + updatedSitups);
                        Console.WriteLine("Hover: +" + updatedHover);
                        Console.WriteLine("Stepups: +" + updatedStepups);
                        Console.WriteLine("Squats: +" + updatedSquats);
                        Console.WriteLine("Lunges: +" + updatedLunges);
                    }
                    catch(ArgumentOutOfRangeException)
                    {

                    }
                    string text = old + Workout.ConvertToString(w);
                    ORM.WriteFile(path, text);
                }
                else if (choice == "reset")
                {
                    Console.WriteLine("Are you sure? Type yes");
                    string accept = Console.ReadLine();
                    if (accept == "yes")
                    {
                        ORM.WriteFile(path, "");
                        Console.WriteLine("Data has been reset");
                    }
                    else
                    {
                        Console.WriteLine("Not deleting file");
                    }
                }
                else if (choice == "clear")
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to weight logger. Type !help for a list of commands.");
                }
                else if (choice == "compare")
                {
                    string file = ORM.ReadFile(path);
                    List<Workout> WorkoutList = Workout.ConvertToObject(file);

                }
                else
                {
                    Console.WriteLine("Unkown command.");
                }
            }
            while (choice != "exit");
        }
    }
}