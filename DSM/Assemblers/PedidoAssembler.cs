using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Assemblers
{
    public class PedidoAssembler
    {
        public PedidoViewModel ConvertENToModelUI(PedidoEN en)
        {
            if (en == null) return null;

            var vm = new PedidoViewModel();
            vm.Id = en.Id;
            vm.Numero = en.Numero;
            vm.TotalPrecio = en.TotalPrecio;
            vm.Fecha = en.Fecha.GetValueOrDefault();

            // Map EstadoPedido from domain enum to view model enum
            try
            {
                switch (en.EstadoPedido)
                {
                    case PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum.enProceso:
                        vm.EstadoPedido = DSM.Models.EstadoPedido.Pendiente;
                        break;
                    case PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum.enviado:
                        vm.EstadoPedido = DSM.Models.EstadoPedido.Enviado;
                        break;
                    case PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum.entregado:
                        vm.EstadoPedido = DSM.Models.EstadoPedido.Entregado;
                        break;
                    case PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum.cancelado:
                        vm.EstadoPedido = DSM.Models.EstadoPedido.Cancelado;
                        break;
                    case PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum.devuelto:
                        // No hay "Devuelto" en la VM: mapear a Cancelado para mostrar algo
                        vm.EstadoPedido = DSM.Models.EstadoPedido.Cancelado;
                        break;
                    default:
                        vm.EstadoPedido = DSM.Models.EstadoPedido.Pendiente;
                        break;
                }
            }
            catch
            {
                vm.EstadoPedido = DSM.Models.EstadoPedido.Pendiente;
            }

            if (en.LineaPedido != null && en.LineaPedido.Any())
            {
                vm.Lineas = new LineaPedidoAssembler().ConvertListENToViewModel(en.LineaPedido).ToList();
            }
            else
            {
                vm.Lineas = new List<LineaPedidoViewModel>();
            }

            return vm;
        }

        public IList<PedidoViewModel> ConvertListENToViewModel(IList<PedidoEN> ens)
        {
            IList<PedidoViewModel> list = new List<PedidoViewModel>();
            if (ens == null) return list;
            foreach (var en in ens)
            {
                list.Add(ConvertENToModelUI(en));
            }
            return list;
        }
    }
}