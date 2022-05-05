using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace STDIO_dotNet.Models
{
    public class MajorHandler
    {
        private static string url = @"D:\Software Engineering\Training\STDIO\dotNet - student\dotNet\STDIO_dotNet\STDIO_dotNet\wwwroot\file\major.txt";

        public List<Major> MajorList { get; set; }

        public MajorHandler()
        {
            MajorList = new List<Major>();
        }

        public List<Major> GetMajorList()
        {
            return MajorList;
        }

        public void GetMajorFromFile()
        {
            try
            {
                StreamReader sr = new StreamReader(url, Encoding.UTF8);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Major M = new Major();
                    string[] majorfields = line.Split("|");
                    if (majorfields.Length > 0)
                    {
                        M.ClassID = majorfields[0];
                        M.MajorName = majorfields[1];
                        M.MajorID = majorfields[2];
                        MajorList.Add(M);
                    }
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Major IOException error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Major Exception error: " + e.Message);
            }
        }
        public void ShowMajor()
        {
            foreach (var m in MajorList)
            {
                Console.WriteLine($"{m.MajorID}:\t{m.MajorName}.");
            }
        }
        public string MaCNToTenCN(string majorID)
        {
            Major M = MajorList.Find(x => x.MajorID == majorID);
            return M != null ? M.MajorName : throw new StudentException("Lỗi tìm kiếm MajorID");
        }
        public bool MajorAvailable(string majorID)
        {
            return MajorList.Exists(x => x.MajorID == majorID);
        }
    }
}
