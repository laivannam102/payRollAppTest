using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rollAppTest1.Models;

namespace rollAppTest1.Controllers
{
    public class UserController : Controller
    {
        int insertId;
        int deleteId;
        EmployeeDb empDB = new EmployeeDb();
        // GET: User
        public ActionResult Index()
        {
            List<Employee> listEmp = new List<Employee>();
            listEmp = this.ListUser();
            return View(listEmp);
        }
        [HttpPost]
        public JsonResult CreateUser([FromBody] Employee emp)
        {
            insertId = empDB.AddUser(emp);
            return Json(insertId);

        }
        public JsonResult DeleteUser([FromBody] string data)
        {
            deleteId = empDB.deteleUser(data);
            return Json("Dã xóa thành công");

        }

        public List<Employee> ListUser()
        {
            return empDB.ListAll();
        }
    }
}
