using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace rollAppTest1.Models
{
    public class EmployeeDb
    {
        string connectionString = "Data Source=DESKTOP-10BIGUJ\\MSSQLSERVER1;Initial Catalog=PayrollDbApplication;Integrated Security=True";

        public List<Employee> ListAll()
        {
            List<Employee> lst = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Employee
                    {
                        userName = rdr["userName"].ToString(),
                        passWord = rdr["passWord"].ToString(),
                        fullname = rdr["fullname"].ToString(),
                        address = rdr["address"].ToString(),
                        DOB = rdr["DOB"].ToString(),
                        email = rdr["email"].ToString(),
                        phoneNumber = rdr["phoneNumber"].ToString(),
                        probationDay = rdr["probationDay"].ToString(),
                        officialDay = rdr["officialDay"].ToString(),
                        salary = float.Parse(rdr["salary"].ToString()),
                        salaryRateByTime = float.Parse(rdr["salaryRateByTime"].ToString()),
                        salaryRateByEffective = float.Parse(rdr["salaryRateByEffective"].ToString())
                    });
                }
                return lst;
            }
        }

        public int AddUser(Employee emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@userName", emp.userName);
                com.Parameters.AddWithValue("@passWord", emp.passWord);
                com.Parameters.AddWithValue("@fullname", emp.fullname);
                com.Parameters.AddWithValue("@address", emp.address);
                com.Parameters.AddWithValue("@DOB", emp.DOB);
                com.Parameters.AddWithValue("@email", emp.email);
                com.Parameters.AddWithValue("@phoneNumber", emp.phoneNumber);
                com.Parameters.AddWithValue("@probationDay", emp.probationDay);
                com.Parameters.AddWithValue("@officialDay", emp.officialDay);
                com.Parameters.AddWithValue("@salary", emp.salary);
                com.Parameters.AddWithValue("@salaryRateByTime", emp.salaryRateByTime);
                com.Parameters.AddWithValue("@salaryRateByEffective", emp.salaryRateByEffective);

                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public EmployDetail userDetail(string userName)
        {
            System.Diagnostics.Debug.WriteLine(userName);
            System.Diagnostics.Debug.WriteLine("hao nam dt");
            if (userName != null)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM dbo.userList AS us FULL OUTER JOIN dbo.salary AS sa ON us.userName = sa.userName WHERE us.userName = @userName";
                    SqlCommand com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("@userName", userName);
                    SqlDataReader rdr = com.ExecuteReader();
                    EmployDetail emp = new EmployDetail();
                    while (rdr.Read())
                    {
                        emp.userName = rdr["userName"].ToString();
                        emp.passWord = rdr["passWord"].ToString();
                        emp.fullname = rdr["fullname"].ToString();
                        emp.address = rdr["address"].ToString();
                        emp.DOB = rdr["DOB"].ToString();
                        emp.email = rdr["email"].ToString();
                        emp.phoneNumber = rdr["phoneNumber"].ToString();
                        emp.probationDay = rdr["probationDay"].ToString();
                        emp.officialDay = rdr["officialDay"].ToString();
                        emp.salary = float.Parse(rdr["salary"].ToString());
                        emp.salaryRateByTime = float.Parse(rdr["salaryRateByTime"].ToString());
                        emp.salaryRateByEffective = float.Parse(rdr["salaryRateByEffective"].ToString());
                        emp.dayPerMonth = rdr["dayOfMonth"].ToString();
                        emp.dayOfWorking = rdr["dayOfWork"].ToString();
                        emp.levelComplete = rdr["evaluate"].ToString();
                    }
                    return emp;
                }
            }
            else
            {
                EmployDetail emp = new EmployDetail();
                return emp;
            }

        }
        public int addSalary(Salary sa)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertSalary", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@userName", sa.employeeName);
                com.Parameters.AddWithValue("@dayPerMonth", sa.dayPerMonth);
                com.Parameters.AddWithValue("@dayOfWorking", sa.dayOfWorking);
                com.Parameters.AddWithValue("@levelComplete", sa.levelComplete);

                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public int deteleUser(string userName)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("DeleteEmployee", con);
                SqlCommand com2 = new SqlCommand("DeleteSalary", con);
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.AddWithValue("@userName", userName);
                com2.CommandType = CommandType.StoredProcedure;
                com2.Parameters.AddWithValue("@userName", userName);

                i = com1.ExecuteNonQuery();
                com2.ExecuteNonQuery();
            }
            return i;
        }
    }
}
