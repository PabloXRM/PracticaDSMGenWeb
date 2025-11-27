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
            if (en == null) return null;
            return new NotificacionViewModel
            {
                Id = en.Id,
                Tipo = en.Tipo,
                Fecha = en.Fecha,
                Titulo = en.Titulo,
                Descripcion = en.Descripcion,
                Fotos = en.Fotos
            };
        }

        public NotificacionEN ConvertModelUIToEN(NotificacionViewModel vm)
        {
            if (vm == null) return null;
            var en = new NotificacionEN();
            en.Id = vm.Id;
            en.Tipo = vm.Tipo;
            en.Fecha = vm.Fecha;
            en.Titulo = vm.Titulo;
            en.Descripcion = vm.Descripcion;
            en.Fotos = vm.Fotos;
            return en;
        }

        public IEnumerable<NotificacionViewModel> ConvertListENToViewModel(IList<NotificacionEN> list)
        {
            return list?.Select(e => ConvertENToModelUI(e));
        }
    }
}
