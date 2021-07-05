using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using WEB.DTOs.Student;

namespace WEB.Helpers
{
    public static class FileHelper
    {
        public static List<StudentFromFileDto> ReadCsvFile(IFormFile file)
        {
            try
            {
                using (TextReader tr = new StreamReader(file.OpenReadStream()))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture);
                    config.Delimiter = ";";

                    using (CsvReader cr = new CsvReader(tr, config))
                    {
                        return cr.GetRecords<StudentFromFileDto>()
                            .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
        
        public static string CreateCsvListFromFile(List<StudentDto> list)
        {
            try
            {
                var tempPath = Path.Combine(Directory.GetCurrentDirectory(), "Data/Temp");

                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                var filePath = Path.Combine(tempPath, "tempCsv.csv");

                // Usunięcie jesli wcześniej jakiś był
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (TextWriter tr = new StreamWriter(filePath))
                {
                    var config = new CsvConfiguration(CultureInfo.CurrentCulture);
                    config.Delimiter = ";";
                    config.Encoding = Encoding.UTF8;

                    using (var cw = new CsvWriter(tr, config))
                    {
                        cw.WriteRecords(list);
                    }
                }

                return filePath;
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
    }
}
