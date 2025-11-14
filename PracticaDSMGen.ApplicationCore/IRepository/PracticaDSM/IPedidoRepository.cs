
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface IPedidoRepository
{
void setSessionCP (GenericSessionCP session);

PedidoEN ReadOIDDefault (int id
                         );

void ModifyDefault (PedidoEN pedido);

System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size);



int New_ (PedidoEN pedido);

void Modify (PedidoEN pedido);


void Destroy (int id
              );


PedidoEN ReadOID (int id
                  );


System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size);



System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> DamePedidosPorProducto (int ? p_idProducto);
}
}
