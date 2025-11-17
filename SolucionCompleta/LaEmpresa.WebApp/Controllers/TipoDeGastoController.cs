using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaEmpresa.WebApp.Controllers
{
    public class TipoDeGastoController : Controller
    {

        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                { 
                    try
                    {
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

 
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                {
                    try
                    {
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                {
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");

            
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeGastoDTO tipoDeGastoDTO)
        {
            try
            {
                string email = HttpContext.Session.GetString("email");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                {
                    try
                    {
                        return View(id);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeGastoDTO aEditar, IFormCollection collection)
        {
            try
            {
                string email = HttpContext.Session.GetString("email");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 0)
                {
                    try
                    {
                        return View(id);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mensaje = ex.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                string email = HttpContext.Session.GetString("email");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }
    }
}
