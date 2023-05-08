using Microsoft.Data.SqlClient;
using System.Data;
namespace SpotExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student obj = new Student
            {
                StudentId = 7,
                StudentName = "vipul sir",
                Address = "mumbai",
                StudentGrade = "B"
            };
            //Insert(obj);
            //Update(obj);
            //Delete(4);
           //GetSingleStudent(3);
           //GetAllStudents();
        }

        static void Insert(Student student)
        {
            SqlConnection cn = new SqlConnection();

            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False


            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                // cmdInsert.CommandType = CommandType.Text;
                //cmdInsert.CommandText = "insert into Students values(@StudentId, @StudentName, @Address, @Grade)";
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertStudent";


                cmdInsert.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmdInsert.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmdInsert.Parameters.AddWithValue("@Address", student.Address);
                cmdInsert.Parameters.AddWithValue("@Grade", student.StudentGrade);

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }

        static void Update(Student student)
        {
            SqlConnection cn = new SqlConnection();

            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False


            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                //cmdInsert.CommandType = CommandType.Text;
                //cmdInsert.CommandText = "update Students set StudentName =@StudentName, Address = @Address, Grade = @Grade where StudentId=@StudentId";

                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "UpdateStudent";

                cmdInsert.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmdInsert.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmdInsert.Parameters.AddWithValue("@Address", student.Address);
                cmdInsert.Parameters.AddWithValue("@Grade", student.StudentGrade);

                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }

        static void Delete(int StudentId)
        {
            SqlConnection cn = new SqlConnection();

            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False


            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                //cmdInsert.CommandType = CommandType.Text;
                //cmdInsert.CommandText = "delete from Students where StudentId=@StudentId";

                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "DeleteStudent";

                cmdInsert.Parameters.AddWithValue("@StudentId", StudentId);


                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }

        static void GetSingleStudent(int StudentId)
        {
            SqlConnection cn = new SqlConnection();

            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False


            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                //cmdInsert.CommandType = CommandType.Text;
               // cmdInsert.CommandText = $"select * from Students where StudentId={StudentId}";

                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "GetSingleStudent";
                cmdInsert.Parameters.AddWithValue("@StudentId", StudentId);

                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    Student student = new Student
                    {
                        StudentId = (int)dr.GetInt32("StudentId"),
                        StudentName = (string)dr.GetString("StudentName"),
                        Address = (string)dr.GetString("Address"),
                        StudentGrade = (string)dr.GetString("Grade")
                    };
                    Console.WriteLine(student.StudentId );
                    Console.WriteLine(student.StudentName);
                    Console.WriteLine(student.Address);
                    Console.WriteLine((string)dr.GetString("Grade"));

                }
                dr.Close();


                cmdInsert.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }

        }

        /*static Student GetSingleStudent1(int StudentId)
        {
            SqlConnection cn = new SqlConnection();

            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False


            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;";
            try
            {

                cn.Open();
                Student student = new Student();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"select * from Students where StudentId={StudentId}";

                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    student = new Student
                    {
                        StudentId = (int)dr.GetInt32("StudentId"),
                        StudentName = (string)dr.GetString("StudentName"),
                        Address = (string)dr.GetString("Address"),
                        StudentGrade = (string)dr.GetString("Grade")
                    };
                    Console.WriteLine(student.StudentId);
                    Console.WriteLine(student.StudentName);
                    Console.WriteLine(student.Address);
                    Console.WriteLine(student.StudentGrade);

                }
                dr.Close();
                cmdInsert.ExecuteNonQuery();
                return student;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }

        }*/

        static void GetAllStudents()
        {
            SqlConnection cn = new SqlConnection();

            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False


            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                //cmdInsert.CommandType = CommandType.Text;
                //cmdInsert.CommandText = "select * from Students";

                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "GetAllStudents";

                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetInt32("StudentId"));
                    Console.WriteLine(dr.GetString("StudentName"));
                    Console.WriteLine(dr.GetString("Address"));
                    Console.WriteLine(dr.GetString("Grade"));
                    Console.WriteLine();

                }
                dr.Close();


                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }

        }
    }
    public class Student
    {
        private int studentId;
        private string studentName;
        private string address;
        private string studentGrade;

        public Student(int studentId=1, string studentName="Student", string address="Mumbai", string studentGrade = "A")
        {
            StudentId = studentId;
            StudentName = studentName;
            Address = address;
            StudentGrade = studentGrade;
        }

        public string StudentName
        {
            set
            {
                if(value != null)
                {
                    studentName = value;
                }
                else
                {
                    throw new Exception("Name Can not be Null");
                }
            }
            get
            {
                return studentName;
            }
        }

        public int StudentId
        {
            set
            {
                if(value> 0)
                {
                    studentId = value;
                }
                else
                {
                    throw new Exception("StudentId must be greater than zero");
                }
            }
            get { return studentId; }
        }

        public string Address
        {
            set { address = value; }
            get { return address; }
        }
        public string StudentGrade
        {
            set
            {
                if(value == "A")
                {
                    studentGrade = "A-75";
                }
                else if (value == "B")
                {
                    studentGrade = "B-60";
                }
                else if(value == "C")
                {
                    studentGrade = "C-35";
                }
                else
                {
                    studentGrade = "Fail-0";
                }
            }

            get { return studentGrade; }
        }
    }
}