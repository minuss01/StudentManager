using System;
using System.IO;

namespace WEB.Helpers
{
    public static class ErrorLog
    {
        public static void Log(Exception ex)
        {
            try
            {
                var baseDirectory = Directory.GetCurrentDirectory();
                var filepath = Path.Combine(baseDirectory, "Data/Logs/");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var fileName = Path.Combine(filepath, $"{DateTime.Today:MM-yyyy}.txt");

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Dispose();
                }

                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(Environment.NewLine);
                    sw.WriteLine($"-------------------*Exception {DateTime.Now:dd-MM-yyyy HH:mm:ss}*-------------------------");
                    sw.WriteLine("---------------------------------------------------------------------------");
                    sw.WriteLine($"Message: {ex.Message}");
                    sw.WriteLine($"Trace: {ex.StackTrace}");
                    sw.WriteLine("--------------------------------*End*--------------------------------------");
                    sw.WriteLine(Environment.NewLine);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
