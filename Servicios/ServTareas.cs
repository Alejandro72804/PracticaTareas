using PracticaTareas.Modelos;

namespace PracticaTareas.Servicios
{
    public class ServTareas
    {
        /*
          private string texto = "", descr = "";
          private List<Nota> Notas = new List<Nota>();
        
        private ServAlmacen ServAlmacen;
        
     public ServTareas(ServAlmacen SvAn)
        {
            ServAlmacen = SvAn;
        }
        
        public Nota NuevaNota()
        {
            return new Nota();
        }
        

        /*   if (nt.Archiva)
           {

               EliminaNota(nt.Id);
           }
           else
           {
               AgregaNota(nt);
           }
        */

        /*
            *

           public void EliminaNota(Guid id)
           {
               foreach (Nota nt in Notas)
               {
                   if (id.Equals(nt.Id))
                   {
                       Notas.Remove(nt);
                       break;
                   }
               }
           }

           public async void AgregaNota(Nota nt)
           {
               if (!string.IsNullOrWhiteSpace(nt.Nombre) || !string.IsNullOrWhiteSpace(nt.Descripcion))
               {
                   if (nt.img.Equals(""))
                   {
                       nt.img = MemoAleatorio();
                   }

                   Notas.Add(nt);
                   await ServAlmacen.GuardaAlmNota(nt);
               }
           }

         
        public async Task<List<Nota>> LstNotasGuardadas()
        {
            List<Nota> lst = new List<Nota>();

            foreach (Nota nt in ServTareas.LstNotas().Where(nt => nt.Archiva))
            {
                lst.Add(await ObtenerAlmNota(nt.Id.ToString()));
            }
            return lst;
        }

        public async Task ActualizaAlmNota(Nota nt)
        {
            List<Nota> lstnota = new List<Nota>();
            lstnota = await LstNotasGuardadas();
            foreach (Nota nota in lstnota)
            {
                if (nt.Id == nota.Id)
                {

                }
            }
        } 
        */
    }
}
