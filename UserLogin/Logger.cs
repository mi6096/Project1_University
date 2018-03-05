using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();
        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.currentUserUsername + ";"
                + LoginValidation.currentUserRoles + ";"
                + activity;
            currentSessionActivities.Add(activityLine);
            if (File.Exists("activity.txt"))
            {
                File.AppendAllText("activity.txt", activityLine);
            }
        }
        public static void GetCurrentSessionActivies(string filter)
        {
            StringBuilder allText = new StringBuilder();
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            foreach (string currentLine in filteredActivities)
            {
                allText.Append(currentLine);
            }
            Console.WriteLine(allText);
        }
    }
}
