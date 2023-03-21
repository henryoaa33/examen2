using System;
using System.Collections.Generic;
using System.Text;

namespace examen002.Models
{
    [Serializable]
    public class Persona
    {

        public string nombre { get; set; }
        public int numerolicencia { get; set; }
        public List<Aereonave> AereonavePersona { get; set; } = new List<Aereonave>();
        public override string ToString()
        {
            return $"{nombre} - {numerolicencia} ";
        }
    }
}
