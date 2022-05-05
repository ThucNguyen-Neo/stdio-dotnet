using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace STDIO_dotNet.Models
{
    public class StudentHandler
    {
        private static string url = @"D:\Software Engineering\Training\STDIO\dotNet - student\dotNet\STDIO_dotNet\STDIO_dotNet\wwwroot\file\student.txt";
        public List<Student> StudentList { get; set; }

        public StudentHandler()
        {
            StudentList = new List<Student>();
        }

        public List<Student> GetStudentList()
        {
            return StudentList;
        }
        public void GetStudentFromFile()
        {
            try
            {
                StreamReader sr = new StreamReader(url, Encoding.UTF8);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Student student = new Student();
                    string[] studentFields = line.Split("|");
                    if (studentFields.Length > 0)
                    {
                        student.StudentID = studentFields[0];
                        student.StudentName = studentFields[1];
                        bool gender = studentFields[2].Equals("1") ? true : false;
                        student.StudentGender = gender;
                        string BirthDate = studentFields[3];
                        bool isBirthDate =
                            DateTime.TryParseExact(
                                BirthDate,
                                "dd-MM-yyyy",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime birhtdateResult);
                        if (isBirthDate) student.StudentBirthDate = birhtdateResult;
                        else throw new StudentException($"Ngày sinh của sinh viên {student.StudentID} không hợp lệ.");
                        student.MajorID = studentFields[4];
                        student.UniversityID = studentFields[5];
                        StudentList.Add(student);
                    }
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Student IOException error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Student Exception error: " + e.Message);
            }
        }

        public void WriteStudentListToFile(List<Student> students)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(url, false, Encoding.UTF8))
                {
                    foreach (var s in students)
                    {
                        sw.WriteLine($"{s.StudentID}|{s.StudentName}|{(s.StudentGender ? "1" : "0")}" +
                            $"|{s.StudentBirthDate.ToString("dd-MM-yyyy")}|{s.MajorID}|{s.UniversityID}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Writing file - IOException error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Writing file - Exception error: " + e.Message);
            }

        }


        public void ShowStudentInfo()
        {
            foreach (var s in StudentList)
            {
                Console.WriteLine(s.StudentToString());
            }
        }

        /*public static void AddStudent()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.Write("Nhập mã số sinh viên: ");
            string studentID = Console.ReadLine();
            Console.Write("Nhập tên sinh viên: ");
            string studentName = Console.ReadLine();
            Console.WriteLine(studentName);
            string gender = getGender();
            DateTime birthDate = getBirthdate();
            string major = getMajor();
            string university = getUniversity();
            Student S = new Student();
            S.StudentID = studentID;
            S.StudentName = studentName;
            S.StudentGender = gender.Equals("1");
            S.StudentBirthDate = birthDate;
            S.MajorID = major;
            S.UniversityID = university;
            StudentList.Add(S);
            WriteStudentListToFile();
            Console.WriteLine("Đã thêm sinh viên.");
        }*/
        /*public static void ChangeStudentInfo()
        {
            Console.InputEncoding = Encoding.Unicode;
            string studentID = getChangedStudentID();
            Student S = StudentList.Find(x => x.StudentID.Equals(studentID));
            StudentList.Remove(S);
            Console.Write("Nhập tên sinh viên: ");
            string studentName = Console.ReadLine();
            Console.WriteLine(studentName);
            string gender = getGender();
            DateTime birthDate = getBirthdate();
            string major = getMajor();
            string university = getUniversity();
            S = new Student();
            S.StudentID = studentID;
            S.StudentName = studentName;
            S.StudentGender = gender.Equals("1");
            S.StudentBirthDate = birthDate;
            S.MajorID = major;
            S.UniversityID = university;
            StudentList.Add(S);
            WriteStudentListToFile();
            Console.WriteLine("Đã sửa sinh viên.");
        }*/
        /*public static void DeleteStudent()
        {
            string studentID = getChangedStudentID();
            Student S = StudentList.Find(x => x.StudentID.Equals(studentID));
            StudentList.Remove(S);
            WriteStudentListToFile();
            Console.WriteLine("Đã xoá sinh viên.");
        }*/
        /*public static void ShowSpecificStudentInfo()
        {
            Console.WriteLine("Các sinh viên có chữ Minh trong tên:");
            List<Student> SpecificStudentList = StudentList.FindAll(x => x.StudentName.Contains("Minh"));
            SpecificStudentList.ForEach(x => Console.WriteLine(x.StudentToString()));
            Console.WriteLine();
            Console.WriteLine("Các sinh viên là nữ:");
            SpecificStudentList = StudentList.FindAll(x => x.StudentGender == false);
            SpecificStudentList.ForEach(x => Console.WriteLine(x.StudentToString()));
            Console.WriteLine();
            Console.WriteLine("Các sinh viên có năm sinh bé hơn 2001:");
            SpecificStudentList = StudentList.FindAll(x => x.StudentBirthDate.Year < 2001);
            SpecificStudentList.ForEach(x => Console.WriteLine(x.StudentToString()));
        }*/
        private string getGender()
        {
            string gender;
            bool isNumber;
            do
            {
                Console.Write("Nhập giới tính (Nữ nhập 0, nam nhập 1): ");
                gender = Console.ReadLine();
                isNumber = int.TryParse(gender, out _);
            } while (!isNumber && !gender.Equals("0") && !gender.Equals("1"));
            return gender;
        }
        private DateTime getBirthdate()
        {
            DateTime birthdate;
            bool isBirthdate;
            do
            {
                Console.Write("Nhập ngày sinh (dd--MM--yyyy): ");
                isBirthdate = DateTime.TryParseExact(
                                Console.ReadLine(),
                                "dd-MM-yyyy",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out birthdate);
            } while (!isBirthdate);
            return birthdate;
        }
        /*private string getMajor()
        {
            Major.ShowMajor();
            string major;
            do
            {
                Console.Write("Nhập chuyên ngành có trong list (viết tắt): ");
                major = Console.ReadLine();
            } while (!Major.MajorAvailable(major));
            return major;
        }*/
        private string getUniversity()
        {
            UniversityHandler UH = new UniversityHandler();
            UH.ShowUniversity();
            string university;
            do
            {
                Console.Write("Nhập trường đại học có trong list (viết tắt): ");
                university = Console.ReadLine();
            } while (!UH.UniversityAvailable(university));
            return university;
        }
        private string getChangedStudentID()
        {
            string studentID = "";
            do
            {
                Console.Write("Nhập mã số sinh viên cần thao tác: ");
                studentID = Console.ReadLine();
            } while (!ContainStudentID(StudentList, studentID));
            return studentID;
        }
        private bool ContainStudentID(List<Student> students, string studentID)
        {
            foreach (var s in students)
            {
                if (s.StudentID == studentID) return true;
            }
            return false;
        }
    }
}
