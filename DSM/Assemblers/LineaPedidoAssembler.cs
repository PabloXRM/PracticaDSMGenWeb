using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;

namespace DSM.Assemblers
{
    public class LineaPedidoAssembler
    {
        public LineaPedidoViewModel ConvertENToModelUI(LineaPedidoEN en)
        {
            LineaPedidoViewModel lp = new LineaPedidoViewModel();

            lp.Num = en.Num;
            lp.Cantidad = en.Cantidad;
            lp.Precio = (double)en.Precio;

            if (en.Pedido != null)
                lp.IdPedido = en.Pedido.Id;

            return lp;
        }

        public IList<LineaPedidoViewModel> ConvertListENToViewModel(IList<LineaPedidoEN> ens)
        {
            IList<LineaPedidoViewModel> list = new List<LineaPedidoViewModel>();
            foreach (LineaPedidoEN en in ens)
            {
                list.Add(ConvertENToModelUI(en));
            }
            return list;
        }
    }
}
