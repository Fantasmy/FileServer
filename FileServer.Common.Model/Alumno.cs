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
        //public Guid IdAlumno { get; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }


        // constructores
        public Alumno()
        {

        }


        //public Alumno(Guid IdAlumno, string Nombre, string Apellidos, string Dni)
        public Alumno(string Nombre, string Apellidos, string DNI)
        {
            ////this.IdAlumno = Guid.NewGuid();
            //this.Nombre = Nombre;
            //this.Apellidos = Apellidos;
            //this.DNI = DNI;
            //Id = id;
            Nombre = Nombre;
            Apellidos = Apellidos;
            DNI = DNI;
        }

        // métodos

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            if (obj == null)
                return false;

                    //IdAlumno == alumno.IdAlumno &&
            return Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   DNI == alumno.DNI;
        }

        public override string ToString()
        {
            return string.Format(@"{0},{1},{2}",
                                   Nombre, Apellidos, DNI);
        }

        public override int GetHashCode()
        {
            var hashCode = -332541938;
            //hashCode = hashCode * -1521134295 + IdAlumno.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DNI);
            return hashCode;
        }
    }
}
