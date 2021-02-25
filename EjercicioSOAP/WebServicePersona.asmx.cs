using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EjercicioSOAP
{
    /// <summary>
    /// Descripción breve de WebServicePersona
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePersona : System.Web.Services.WebService
    {

        //private BDPersonaEntities db = new BDPersonaEntities();

        [WebMethod]
        public string Hola()
        {
            return "Hola";
        }
        
        [WebMethod]
        public string CrearPersona(Persona persona)
        {
            using (BDPersonaEntities db = new BDPersonaEntities())
            {
                Persona p = new Persona();



                db.Persona.Add(persona);

                db.Entry(persona).State = System.Data.EntityState.Added;

                db.SaveChanges();

                return "Persona añadida";
            }
        }

        [WebMethod]
        public string EliminarPersona(string NIF)
        {
            using (BDPersonaEntities db = new BDPersonaEntities())
            {
                Persona persona = db.Persona.Where(p => p.NIF == NIF).First();

                
                db.Persona.Remove(persona);

                db.Entry(persona).State = System.Data.EntityState.Deleted;
                
                db.SaveChanges();
            }

            return "Persona eliminada";
        }
        
        [WebMethod]
        public string ModificarPersona(Persona persona)
        {
            using (BDPersonaEntities db = new BDPersonaEntities())
            {

                Persona personaSelect = db.Persona.Where(p => p.IdPersona == persona.IdPersona).First();

                
                personaSelect.Nombre = persona.Nombre;
                personaSelect.Apellidos = persona.Apellidos;
                personaSelect.NIF = persona.NIF;
                personaSelect.Direccion = persona.Direccion;
                personaSelect.Ciudad = persona.Ciudad;
                personaSelect.EstadoCivil = persona.EstadoCivil;
                personaSelect.Sexo = persona.Sexo;
                personaSelect.CodigoPostal = persona.CodigoPostal;
                personaSelect.Provincia = persona.Provincia;

                db.Entry(personaSelect).State = System.Data.EntityState.Modified;

                db.SaveChanges();

            }

            return "Persona modificada";
        }
        
        

        [WebMethod]
        public Persona[] ObtenerLista()
        {
            Persona[] personas = null;

            using (BDPersonaEntities db = new BDPersonaEntities())
            {
                personas = db.Persona.ToArray();
            }

            return personas ;
        }


        [WebMethod]
        public Persona DetallePersona(string NIF)
        {
            Persona persona = null;

            using (BDPersonaEntities db = new BDPersonaEntities())
            {
                persona = db.Persona.Where(p => p.NIF == p.NIF).First();
            }
            return persona;
        }
    }
}
