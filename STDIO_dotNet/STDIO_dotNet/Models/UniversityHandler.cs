using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace STDIO_dotNet.Models
{
    public class UniversityHandler
    {

        private static string url = @"D:\Software Engineering\Training\STDIO\dotNet - student\dotNet\STDIO_dotNet\STDIO_dotNet\wwwroot\file\university.txt";

        public List<University> UniversityList { get; set; }

        public UniversityHandler()
        {
            UniversityList = new List<University>();
        }

        public List<University> GetUniversityList()
        {
            return UniversityList;
        }

        public void GetUniversityFromFile()
        {
            try
            {
                StreamReader sr = new StreamReader(url, Encoding.UTF8);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    University U = new University();
                    string[] universityFields = line.Split("|");
                    if (universityFields.Length > 0)
                    {
                        U.UniversityID = universityFields[0];
                        U.UniversityName = universityFields[1];
                        U.UniversityAbbr = universityFields[2];
                        UniversityList.Add(U);
                    }
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("University IOException error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("University Exception error: " + e.Message);
            }
        }

        public void ShowUniversity()
        {
            foreach (var u in UniversityList)
            {
                Console.WriteLine($"{u.UniversityAbbr}: \t{u.UniversityName}.");
            }
        }
        public string UniIDToUniName(string uniAbbr)
        {
            University U = UniversityList.Find(x => x.UniversityAbbr == uniAbbr);
            return U != null ? U.UniversityName : throw new StudentException("Lỗi tìm kiếm UniveristyAbbr.");
        }
        public bool UniversityAvailable(string uniAbbr)
        {
            return UniversityList.Exists(x => x.UniversityAbbr == uniAbbr);
        }
    }
}
