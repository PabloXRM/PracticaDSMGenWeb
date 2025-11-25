using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;

namespace DSM.Assemblers
{
    public class FacturaAssembler
    {
        public FacturaViewModel ConvertENToModelUI(FacturaEN en)
        {
            FacturaViewModel fac = new FacturaViewModel();
            fac.Id = en.Id;
            fac.Numero = en.Numero;
            fac.ImporteTotal = en.ImporteTotal;
            fac.Fecha = en.Fecha;

            return fac;
        }


        public IList<FacturaViewModel> ConvertListENToViewModel(IList<FacturaEN> ens)
        {
            IList<FacturaViewModel> facs = new List<FacturaViewModel>();
            foreach (FacturaEN en in ens)
            {
                facs.Add(ConvertENToModelUI(en));
            }
            return facs;
        }
    }
}
