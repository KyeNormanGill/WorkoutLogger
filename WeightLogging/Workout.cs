using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightLogging
{
    class Workout
    {
        public decimal Weight { get; set; }
        public int Pushups { get; set; }
        public int Situps { get; set; }
        public decimal Hover { get; set; }
        public int Stepups { get; set; }
        public int Squats { get; set; }
        public int Lunges { get; set; }
        //To:DO Add convert to string and convert to object methods

        public static string ConvertToString(Workout workout)
        {
            string converted =
                Environment.NewLine
                + "Date and Time: "
                + DateTime.Now
                + Environment.NewLine
                + Environment.NewLine
               + "Weight:\t\t"
               + "|" + workout.Weight + "|"
               + Environment.NewLine
               + "Pushups:\t"
               + "|" + workout.Pushups + "|"
               + Environment.NewLine
               + "Situps:\t\t"
               + "|" + workout.Situps + "|"
               + Environment.NewLine
               + "Hover:\t\t"
               + "|" + workout.Hover + "|"
               + Environment.NewLine
               + "Step-ups:\t"
               + "|" + workout.Stepups + "|"
               + Environment.NewLine
               + "Squats:\t\t"
               + "|" + workout.Squats + "|"
               + Environment.NewLine
               + "Lunges:\t\t"
               + "|" + workout.Lunges + "|"
               + Environment.NewLine
               + "_______________________________"
               + Environment.NewLine;
            return converted;
        }

        public static List<Workout> ConvertToObject(string obj)
        {
            //To:do convert string into list of strings divided by | everything that's not a number delete.
            List<Workout> ll = new List<Workout>();
            Workout temp = new Workout();

            string[] a = obj.Split('|');
            for (var i = 1; i < a.Length;)
            {
                temp.Weight = Convert.ToDecimal(a[i]);
                i += 2;
                temp.Pushups = Convert.ToInt32(a[i]);
                i += 2;
                temp.Situps = Convert.ToInt32(a[i]);
                i += 2;
                temp.Hover = Convert.ToDecimal(a[i]);
                i += 2;
                temp.Stepups = Convert.ToInt32(a[i]);
                i += 2;
                temp.Squats = Convert.ToInt32(a[i]);
                i += 2;
                temp.Lunges = Convert.ToInt32(a[i]);
                i += 2;
                ll.Add(temp);
            }
            return ll;
        }



        //To:Do Add arrays with questions and for loop it for questions
    }
}
