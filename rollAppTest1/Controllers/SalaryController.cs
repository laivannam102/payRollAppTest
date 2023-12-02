using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rollAppTest1.Models;

namespace rollAppTest1.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        int insertId;

        EmployeeDb empDB = new EmployeeDb();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddSalary([FromBody] Salary sa)
        {
            insertId = empDB.addSalary(sa);

            return Json("Đã thêm thành công" + insertId);
        }
    }
}
