using Microsoft.AspNetCore.Mvc;
using User_Management.Data;

namespace User_Management.Controllers
{
    public class RegistrationController : Controller
    {

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserLogin model)
        {
            UserManageContext usercontext = new UserManageContext();
            try
            {
                var userData = new UserLogin()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Dob = model.Dob,
                    Gender = model.Gender,
                    EmailAddress = model.EmailAddress,
                    Password = EncryptPassword(model.Password),

                };
                usercontext.UserLogins.Add(userData);
                usercontext.SaveChanges();
                ViewBag.Status = 1;

            }
            catch (Exception ex)
            {

                ViewBag.Status = 0;
            }

            return View();
        }


        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

    }
}
