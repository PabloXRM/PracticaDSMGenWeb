using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;

namespace DSM.Assemblers
{
    public class LineaPedidoAssembler
    {
        public LineaPedidoViewModel ConvertENToModelUI(LineaPedidoEN en)
        {
            LineaPedidoViewModel vm = new LineaPedidoViewModel();
            vm.Num = en.Num;
            vm.Cantidad = en.Cantidad;
            vm.Precio = en.Precio;
            vm.PedidoId = en.Pedido != null ? en.Pedido.Id : 0;
            vm.ProductoId = en.Producto != null ? en.Producto.Id : 0;
            return vm;
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