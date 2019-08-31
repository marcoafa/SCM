using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCM.Models.Entities;
using SCM.Models.Interfaces;
using SCM.ViewModel;

namespace SCM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IDocumentRepository _documentRepository;
        public HomeController(IUserRepository userRepository, IDocumentRepository documentRepository)
        {
            _userRepository = userRepository;
            _documentRepository = documentRepository;
        }
        public IActionResult Index()
        {
            //Variable for user session in the system
            HttpContext.Session.SetString("UserS", "User");
            return View();
        }
        public IActionResult Home()
        {
            var sessionU = HttpContext.Session.GetString("UserS");

            //GET THE TYPE OF USER
            if (sessionU == "User")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Login()
        {

            return View();


        }
        public IActionResult Configurations()
        {
            var sessionU = HttpContext.Session.GetString("UserS");
            var sessionA = HttpContext.Session.GetString("Access");
            //GET THE TYPE OF USER && sessionA == "Administrator"

            if (sessionU != "User")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        public IActionResult EditConfigurations()
        {
            var sessionU = HttpContext.Session.GetString("UserS");
            var sessionA = HttpContext.Session.GetString("Access");
            //GET THE TYPE OF USER && sessionA == "Administrator"

            if (sessionU != "User")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        public IActionResult Document()
        {
            var sessionU = HttpContext.Session.GetString("UserS");
            var sessionA = HttpContext.Session.GetString("Access");
            //GET THE TYPE OF USERC:\Users\MarcoAF\source\repos\SCM\SCM\Controllers\ && (sessionA == "Allocator" || sessionA == "Administrator")
            if (sessionU != "User")
            {
                var DataForDocument = new DataDocumentVM();
                DataForDocument = _documentRepository.GetDatatoFillDocument();
                return View(DataForDocument);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult Status()
        {
            var ListDocuments = new List<DocumentsVM>();
            var sessionU = HttpContext.Session.GetString("UserS");
            var sessionA = HttpContext.Session.GetString("Access");

            ListDocuments = _documentRepository.GetFullDocuments();

            
            if (sessionU != "User")
            {
                return View(ListDocuments);
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }

        }
        public IActionResult History(int? type = 0, DateTime? InitialDate = null, DateTime? FinalDate = null, int DocumentID = 0,int CustomerName = 0, int ProductName = 0)
        {
            var sessionU = HttpContext.Session.GetString("UserS");
            var sessionA = HttpContext.Session.GetString("Access");
            var History = new HistoryVM();
            //GET THE TYPE OF USERC:\Users\MarcoAF\source\repos\SCM\SCM\Controllers\ && sessionA == "Administrator"
            if (sessionU == "User")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                switch (type) {
                    case 0:
                        History.ListHistory = _documentRepository.GetHistoryInformation();
                        History.Data = _documentRepository.GetDatatoFillDocument();

                        break;
                    case 1:
                        //FILTER BY DATES
                        History = HistorybyDates(InitialDate, FinalDate);
                        break;
                    case 2:
                        //FILTER BY DOCUMENT
                        History = HistorybyDocument((int)DocumentID);
                        break;
                    case 3:
                        //FILTER BY CUSTOMER
                        History = HistoryCustomer(CustomerName, ProductName);
                        break;
                    case 4:
                        //FILTER BY PRODUCT
                        History = HistoryCustomer(CustomerName, ProductName);
                        break;
                    default:
                        break;
                }
                return View(History);


            }


        }
        public HistoryVM HistorybyDates(DateTime? InitialDate, DateTime? FinalDate)
        {
            var sessionU = HttpContext.Session.GetString("UserS");
            var sessionA = HttpContext.Session.GetString("Access");

            //GET THE TYPE OF USERC:\Users\MarcoAF\source\repos\SCM\SCM\Controllers\ && sessionA == "Administrator"
            if (sessionU == "User")
            {
                return null;
            }
            else
            {
                var History = new HistoryVM();
                History.ListHistory = _documentRepository.GetHistoryInformation((DateTime)InitialDate, (DateTime)FinalDate);
                History.Data = _documentRepository.GetDatatoFillDocument();
                return History;
            }


        }
        public HistoryVM HistorybyDocument(int DocumentID)
        {
            var sessionU = HttpContext.Session.GetString("UserS");
            var sessionA = HttpContext.Session.GetString("Access");

            //GET THE TYPE OF USERC:\Users\MarcoAF\source\repos\SCM\SCM\Controllers\ && sessionA == "Administrator"
            if (sessionU == "User")
            {
                return null;
            }
            else
            {
                var History = new HistoryVM();
                History.ListHistory = _documentRepository.GetHistoryInformation(DocumentID);
                History.Data = _documentRepository.GetDatatoFillDocument();
                return History;
            }


        }
        public HistoryVM HistoryCustomer(int CustomerName, int ProductName)
        {
            var sessionU = HttpContext.Session.GetString("UserS");
            var sessionA = HttpContext.Session.GetString("Access");

            //GET THE TYPE OF USERC:\Users\MarcoAF\source\repos\SCM\SCM\Controllers\ && sessionA == "Administrator"
            if (sessionU == "User")
            {
                return null;
            }
            else
            {
                var History = new HistoryVM();
                History.ListHistory = _documentRepository.GetHistoryInformation(CustomerName, ProductName);
                History.Data = _documentRepository.GetDatatoFillDocument();
                return History;
            }


        }
        [HttpPost]
        public IActionResult ValidateUser(UserLogin info)
        {

            var users = _userRepository.GetAll();

            if (users.Count() > 0)
            {
                try
                {
                    var Username = users.ToList()
                    .Where(x => x.UserName == info.UserInput && x.Password == info.PasswordInput)
                    .FirstOrDefault().UserName;

                    HttpContext.Session.SetString("UserS", Username);
                    HttpContext.Session.SetString("Access", _userRepository.GetUserType(Username));

                    return Json("true");
                }
                catch (Exception e)
                {
                    return Json("NoUser");
                }

            }
            else
            {
                return Json("false");
            }
        }
        [HttpPost]
        public IActionResult Logout()
        {

            HttpContext.Session.SetString("ClientSelected", "General");
            HttpContext.Session.SetString("UserS", "User");


            return Json("");


        }
        public class UserLogin
        {
            public string UserInput { get; set; }
            public string PasswordInput { get; set; }
        }

    }
}
