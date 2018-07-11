using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Model
{
    public class Alumno
    {

        // propiedades
        public string IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }


        // constructores
        public Alumno()
        {

        }


        public Alumno(string IdAlumno, string Nombre, string Apellidos, string Dni)
        {
            this.IdAlumno = IdAlumno;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Dni = Dni;
        }

        // métodos

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   IdAlumno == alumno.IdAlumno &&
                   Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   Dni == alumno.Dni;
        }

        public override int GetHashCode()
        {
            var hashCode = -332541938;
            hashCode = hashCode * -1521134295 + IdAlumno.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            return hashCode;
        }
    }
}
