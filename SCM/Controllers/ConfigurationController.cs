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
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        
        //private readonly Icu _containerRepository;
        public ConfigurationController(IUserRepository userRepository, IContainerRepository containerRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _containerRepository = containerRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
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
                    user.UserTypeId = 3;
                    user.Password = DocumentI.Password;

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
        [HttpPost]
        public IActionResult AddNewCustomer(Catalogs DocumentI)
        {
            var message = "";
            var bandera = "true";
            try
            {
                //CHECK USER
                var checkCustomer = _customerRepository.GetCustomer(DocumentI.CustomerName);
                if (checkCustomer == null)
                {
                    var customer = new Customer();
                    customer.CustomerName = DocumentI.CustomerName;
                    customer.CustomerAdress = DocumentI.CustomerAdress;
                  

                    //SAVE 
                    _customerRepository.Create(customer);
                    message = "El Cliente se registro con exito!";
                }
                else
                {
                    message = "El Cliente ya existe en la Base de Datos Favor de Verificarlo";
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
        [HttpPost]
        public IActionResult AddNewProduct(Catalogs DocumentI)
        {
            var message = "";
            var bandera = "true";
            try
            {
                //CHECK PRODUCT
                var checkProduct = _productRepository.GetProduct(DocumentI.ProductName);
                if (checkProduct == null)
                {
                    var product = new Product();
                    product.ProductName = DocumentI.ProductName;
                    

                    //SAVE 
                    _productRepository.Create(product);
                    message = "El Producto se registro con exito!";
                }
                else
                {
                    message = "El Producto ya existe en la Base de Datos Favor de Verificarlo";
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
            public string ProductName { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAdress { get; set; }
            public string CustomerPhone { get; set; }
            public string Business { get; set; }
        }

    }
}