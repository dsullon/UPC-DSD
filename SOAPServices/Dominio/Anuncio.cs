﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SOAPServices.Dominio
{
    [DataContract]
    public class Anuncio
    {
        public Anuncio()
        {
            this.FechaPublicacion = DateTime.Now;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo titulo es obligatorio")]
        public string Titulo { get; set; }

        [DataMember]
        [Required(ErrorMessage = "El campo descripcion es obligatorio")]
        public string Descripcion { get; set; }

        [DataMember]
        public Empresa Empresa { get; set; }

        [DataMember]
        public DateTime FechaPublicacion { get; set; }

        [DataMember]
        public bool Estado { get; set; }
    }
}