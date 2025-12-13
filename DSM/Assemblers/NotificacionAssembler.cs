using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using DSM.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Assemblers
{
    public class NotificacionAssembler
    {
        public NotificacionViewModel ConvertENToModelUI(NotificacionEN en)
        {
            NotificacionViewModel noti = new NotificacionViewModel();

            noti.Id = en.Id;
            noti.Tipo = en.Tipo;
            noti.Fecha = en.Fecha;
            noti.Titulo = en.Titulo;
            noti.Descripcion = en.Descripcion;
            noti.Fotos = en.Fotos;

            if (en.Usuario != null)
                noti.EmailUsuario = en.Usuario.Email;

            return noti;
        }

        public IList<NotificacionViewModel> ConvertListENToViewModel(IList<NotificacionEN> ens)
        {
            IList<NotificacionViewModel> list = new List<NotificacionViewModel>();
            if (ens != null)
            {
                foreach (NotificacionEN en in ens)
                {
                    list.Add(ConvertENToModelUI(en));
                }
            }
            return list;
        }

    }
}
