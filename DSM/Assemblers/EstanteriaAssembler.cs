using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;

namespace DSM.Assemblers
{
    public class EstanteriaAssembler
    {
        public EstanteriaViewModel ConvertENToModelUI(EstanteriaEN en)
        {
            EstanteriaViewModel est = new EstanteriaViewModel();
            est.Id = en.Id;
            est.Descripcion = en.Descripcion;
            est.Valoracion = en.Valoracion;
            est.Visitas = en.Visitas;
            est.Visible = en.Visible;

            return est;
        }


        public IList<EstanteriaViewModel> ConvertListENToViewModel(IList<EstanteriaEN> ens)
        {
            IList<EstanteriaViewModel> ests = new List<EstanteriaViewModel>();
            foreach (EstanteriaEN en in ens)
            {
                ests.Add(ConvertENToModelUI(en));
            }
            return ests;
        }
    }
}
