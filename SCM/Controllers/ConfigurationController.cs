using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCM.Models.Interfaces;

namespace SCM.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IUserRepository _userRepository;
        public ConfigurationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpPost]
        public IActionResult AddNewUser(Catalogs DocumentI)
        {
            var message = "El usuario se agrego con exito";
            var bandera = "true";
            try
            {

                
                    //SAVE WITHOUT PRODUCTS
                //_documentRepository.ad
                


                return Json(new { bandera , message });
            }
            catch (Exception e)
            {

                return Json(new { bandera, message });
            }


        }

        public class Catalogs
        {
            public string AddNewUser { get; set; }
        }

    }
}