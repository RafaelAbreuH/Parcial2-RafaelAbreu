using Parcial2_RafaelAbreu.DAL;
using Parcial2_RafaelAbreu.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_RafaelAbreu.BLL
{
    public class RepositorioInscripcion : RepositorioBase<Inscripcion>
    {
        public override bool Guardar(Inscripcion entity)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                RepositorioBase<Estudiantes> dbE = new RepositorioBase<Estudiantes>();

                if (db.Inscripcion.Add(entity) != null)
                {
                    var estudiante = dbE.Buscar(entity.EstudianteId);
                    entity.CalcularMonto();
                    estudiante.Balance += entity.Monto;

                    paso = db.SaveChanges() > 0;
                    dbE.Modificar(estudiante);
                }

            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Modificar(Inscripcion entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> dbE = new RepositorioBase<Estudiantes>();


            try
            {
                var estudiante = dbE.Buscar(entity.EstudianteId);

                var anterior = new RepositorioBase<Inscripcion>().Buscar(entity.InscripcionId);

                estudiante.Balance -= anterior.Monto;

                foreach (var item in anterior.Asignaturas)
                {
                    if (!entity.Asignaturas.Any(A => A.Id == item.Id))
                    {
                        db.Entry(item).State = EntityState.Deleted;

                    }

                }

                foreach (var item in entity.Asignaturas)
                {
                    if (item.Id == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }

                    else
                        db.Entry(item).State = EntityState.Modified;
                }


                entity.CalcularMonto();
                estudiante.Balance += entity.Monto;
                dbE.Modificar(estudiante);

                db.Entry(entity).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }


            return paso;
        }

        public override bool Eliminar(int id)
        {

            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Estudiantes> dbE = new RepositorioBase<Estudiantes>();

            try
            {
                Inscripcion inscripcion = db.Inscripcion.Find(id);
                db.Estudiante.Find(inscripcion.EstudianteId).Balance -= inscripcion.Monto;
                db.Inscripcion.Remove(inscripcion);
                //var eliminar = db.Inscripcion.Find(id);
                //var estudiante = dbE.Buscar(eliminar.EstudianteId);
                //eliminar.CalcularMonto();

                //estudiante.Balance -= eliminar.Monto;
                //dbE.Modificar(estudiante);

             //   db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;


            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

    }
}
