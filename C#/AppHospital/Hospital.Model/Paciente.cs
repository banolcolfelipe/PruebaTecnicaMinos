﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Paciente
    {
        public int Id { get; set; }
        public int Documento_Id { get; set; }
        public string Num_Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Rh { get; set; }
    }
}
