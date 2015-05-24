using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Core
{
    static public class Logger
    {
        public static ObservableCollection<string> Log;
        static public void LogError(string message)
        {
            if (Log != null) Log.Add(DateTime.Now.TimeOfDay + " [ERROR] " + message);
            using (var sw = new StreamWriter("Errors.log", true))
            {
                sw.WriteLine(DateTime.Now + " -- " + message);
            }
        }

        static public void LogEvent(string message)
        {
            if (Log != null) Log.Add(DateTime.Now.TimeOfDay + " [EVENT] " + message);
            using (var sw = new StreamWriter("Events.log", true))
            {
                sw.WriteLine(DateTime.Now + " --- " + message);
            }
        }

        static public void LogInfo(string message)
        {
            if (Log != null) Log.Add(DateTime.Now.TimeOfDay + " [INFO] " + message);
            using (var sw = new StreamWriter("Events.log", true))
            {
                sw.WriteLine(DateTime.Now + " --- " + message);
            }
        }
    }
}
