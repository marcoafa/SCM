using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCM.Models.Interfaces;
using SCM.Models.Entities;

namespace SCM.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IContainerRepository _containerRepository;
        public ConfigurationController(IUserRepository userRepository, IContainerRepository containerRepository)
        {
            _userRepository = userRepository;
            _containerRepository = containerRepository;
        }
        
        [HttpPost]
        public IActionResult AddNewUser(Catalogs DocumentI)
        {
            var message = "";
            var bandera = "true";
            try
            {
                //CHECK USER
                var checkuser = _userRepository.GetUserName(DocumentI.UserID);
                if (checkuser == null)
                {
                    var user = new User();
                    user.Name = DocumentI.Username;
                    user.UserName = DocumentI.UserID;

                    //SAVE 
                    _userRepository.Create(user);
                    message = "El usuario se registro con exito!";
                }
                else
                {
                    message = "El usuario ya existe en la Base de Datos Favor de Verificarlo";
                    bandera = "false";
                }
              

               
                


                return Json(new { bandera , message });
            }
            catch (Exception e)
            {
                message = "Hubo un error favor de intentarlo mas tarde o comunicare con su proveedor";
                bandera = "false";
                return Json(new { bandera, message });
            }


        }
        [HttpPost]
        public IActionResult AddNewContainer(Catalogs DocumentI)
        {
            var message = "";
            var bandera = "true";
            try
            {
                //CHECK USER
                var checkcontainer = _containerRepository.GetContainer(DocumentI.Container);
                if (checkcontainer == null)
                {
                    var container = new Container();
                    container.ContainerDescription = DocumentI.Container;
                   
                    //SAVE 
                    _containerRepository.Create(container);
                    message = "El Contenedor se registro con exito!";
                }
                else
                {
                    message = "El Contenedor ya existe en la Base de Datos Favor de Verificarlo";
                    bandera = "false";
                }






                return Json(new { bandera, message });
            }
            catch (Exception e)
            {
                message = "Hubo un error favor de intentarlo mas tarde o comunicare con su proveedor";
                bandera = "false";
                return Json(new { bandera, message });
            }


        }

        public class Catalogs
        {
            public string Username { get; set; }
            public string UserID { get; set; }
            public string Password { get; set; }
            public string Container { get; set; }
        }

    }
}