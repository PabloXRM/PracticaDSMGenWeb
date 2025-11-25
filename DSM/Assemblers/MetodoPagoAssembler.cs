using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;

namespace DSM.Assemblers
{
    public class MetodoPagoAssembler
    {
        public MetodoPagoViewModel ConvertENToModelUI(MetodoPagoEN en)
        {
            MetodoPagoViewModel met = new MetodoPagoViewModel();
            met.Id = en.Id;
            met.TipoPago = en.Tipo;
            met.Valido = en.Valido;
           
            return met;
        }


        public IList<MetodoPagoViewModel> ConvertListENToViewModel(IList<MetodoPagoEN> ens)
        {
            IList<MetodoPagoViewModel> mets = new List<MetodoPagoViewModel>();
            foreach (MetodoPagoEN en in ens)
            {
                mets.Add(ConvertENToModelUI(en));
            }
            return mets;
        }
    }
}
