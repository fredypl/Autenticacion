using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Autenticacion
{
   public class _13090301
    {       
        string id;
        string nombre;
        string apellido;
        string direccion;
        string telefono;
        string carera;
        string semestre;
        string matricula;
        string correo;
        string github;
        bool deleted;

        [JsonProperty(propertyName: "Id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(propertyName: "Nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [JsonProperty(propertyName: "Apellido")]
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        [JsonProperty(propertyName: "Direccion")]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        [JsonProperty(propertyName: "Telefono")]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        [JsonProperty(propertyName: "Carrera")]
        public string Carrera
        {
            get { return carera; }
            set { carera = value; }
        }
        [JsonProperty(propertyName: "Semestre")]
        public string Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }
        [JsonProperty(propertyName: "Matricula")]
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        [JsonProperty(propertyName: "Correo")]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        [JsonProperty(propertyName: "GitHub")]
        public string GitHub
        {
            get { return github; }
            set { github = value; }
        }

        [Version]
        public string Version { get; set; }

        [JsonProperty(propertyName: "deleted")]
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
