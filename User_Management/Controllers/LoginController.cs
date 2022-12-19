using Microsoft.AspNetCore.Mvc;
using User_Management.Data;

namespace User_Management.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            UserLogin userModel = new UserLogin();

            if (HttpContext.Session.GetString("EmailAddress") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpPost]
        public IActionResult Index(UserLogin userModel)
        {


            bool isUserValid = false;

            UserManageContext userContext = new UserManageContext();
            var status = userContext.UserLogins.Where(m => m.EmailAddress == userModel.EmailAddress).FirstOrDefault();


            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                isUserValid = DecryptPassword(status?.Password) == userModel.Password;

                if (isUserValid)
                {


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginStatus = 0;
                }

            }


            return View(userModel);

        }


        public IActionResult SuccessPage()
        {
            return View();
        }



        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("EmailAddress");

            return RedirectToAction("Index", "Login");
        }



        public string DecryptPassword(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}