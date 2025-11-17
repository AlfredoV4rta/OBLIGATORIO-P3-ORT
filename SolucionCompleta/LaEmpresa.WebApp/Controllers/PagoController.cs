using LaEmpresa.WebApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http.Headers;

namespace LaEmpresa.WebApp.Controllers
{
    public class PagoController : Controller
    {

        private static string uriPago = "http://localhost:5140/api/Pago";

        // GET: PagoController
        public ActionResult Index()
        {
            //if(HttpContext.Session.GetInt32("usuario") != null)
            {
                IEnumerable<PagoDTO> pagos = new List<PagoDTO>();
                try
                {
                    //Encabezado
                    HttpClient cliente = new HttpClient();
                    Uri uri = new Uri(uriPago);
                    cliente.DefaultRequestHeaders.Authorization = new
                        AuthenticationHeaderValue("Bearer", "Aca va el token");
                    HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);

                    //Generar solicitud
                    Task<HttpResponseMessage> tarea = cliente.SendAsync(solicitud);
                    tarea.Wait();

                    //Procesar respuesta
                    HttpResponseMessage respuesta = tarea.Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        HttpContent contenido = respuesta.Content;
                        Task<string> body = contenido.ReadAsStringAsync();
                        body.Wait();
                        string datos = body.Result;
                        pagos = JsonSerializer.Deserialize<IEnumerable<PagoDTO>>(datos);
                    }

                    return View(pagos);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error inesperado";
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        // GET: PagoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                try
                {
                    
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error inesperado" + ex;
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, PagoDTO pagoDto)
        {
            try
            {

                //pagoDto.IdUsuario = (int)HttpContext.Session.GetInt32("idUsuario");

                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }

        // GET: PagoController/Create
        public ActionResult CreateUnico()
        {

            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                try
                {
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error inesperado" + ex;
                    return View();
                }
            }
            return RedirectToAction("Login", "Home");
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUnico(IFormCollection collection, PagoDTO pagoDto)
        {
            try
            {

                pagoDto.IdUsuario = (int)HttpContext.Session.GetInt32("idUsuario");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex;
                return View();
            }
        }



        // GET: PagoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult ListarPagosMensuales()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {
                if (HttpContext.Session.GetInt32("usuario") == 2)
                {
                    try
                    {
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Error inesperado" + ex;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult ListarPagosMensuales(int mes, int anio)
        {
            try
            {

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex.Message;
                return View();
            }
        }

        public IActionResult ListarUsuariosPagoMonto()
        {
            if (HttpContext.Session.GetInt32("usuario") != null)
            {   
                if (HttpContext.Session.GetInt32("usuario") == 2)
                {
                    try
                    {
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Error inesperado" + ex;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]

        public IActionResult ListarUsuariosPagoMonto(int monto)
        {
            try
            {

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error inesperado" + ex.Message;
                return View();
            }
        }
    }
}
