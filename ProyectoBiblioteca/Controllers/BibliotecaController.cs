using Newtonsoft.Json;
using ProyectoBiblioteca.Logica;
using ProyectoBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBiblioteca.Controllers
{
    public class BibliotecaController : Controller
    {
        // GET: Biblioteca
        public ActionResult Libros()
        {
            return View();
        }

        public ActionResult Autores()
        {
            return View();
        }


        [HttpGet]
        public JsonResult ListarAutor()
        {
            List<Autor> oLista = new List<Autor>();
            oLista = AutorLogica.Instancia.Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarAutor(Autor objeto)
        {
            bool respuesta = false;
            respuesta = (objeto.IdAutor == 0) ? AutorLogica.Instancia.Registrar(objeto) : AutorLogica.Instancia.Modificar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarAutor(int id)
        {
            bool respuesta = false;
            respuesta = AutorLogica.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult ListarLibro()
        {
            List<Libro> oLista = new List<Libro>();

            oLista = LibroLogica.Instancia.Listar();
           
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarLibro(string objeto, HttpPostedFileBase imagenArchivo)
        {

            Response oresponse = new Response() { resultado = true, mensaje = "" };

            try
            {
                Libro oLibro = new Libro();
                oLibro = JsonConvert.DeserializeObject<Libro>(objeto);


                if (oLibro.IdLibro == 0)
                {
                    int id = LibroLogica.Instancia.Registrar(oLibro);
                    oLibro.IdLibro = id;
                    oresponse.resultado = oLibro.IdLibro == 0 ? false : true;
                }
                else
                {
                    oresponse.resultado = LibroLogica.Instancia.Modificar(oLibro);
                }
            }
            catch (Exception e)
            {
                oresponse.resultado = false;
                oresponse.mensaje = e.Message;
            }

            return Json(oresponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarLibro(int id)
        {
            bool respuesta = false;
            respuesta = LibroLogica.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarTipoPersona()
        {
            List<TipoPersona> oLista = new List<TipoPersona>();
            oLista = TipoPersonaLogica.Instancia.Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarPersona()
        {
            List<Persona> oLista = new List<Persona>();

            oLista = PersonaLogica.Instancia.Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarPersona(Persona objeto)
        {
            bool respuesta = false;
            objeto.Clave = objeto.Clave == null ? "" : objeto.Clave;
            respuesta = (objeto.IdPersona == 0) ? PersonaLogica.Instancia.Registrar(objeto) : PersonaLogica.Instancia.Modificar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarPersona(int id)
        {
            bool respuesta = false;
            respuesta = PersonaLogica.Instancia.Eliminar(id);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


    }
    public class Response
    {

        public bool resultado { get; set; }
        public string mensaje { get; set; }
    }
}