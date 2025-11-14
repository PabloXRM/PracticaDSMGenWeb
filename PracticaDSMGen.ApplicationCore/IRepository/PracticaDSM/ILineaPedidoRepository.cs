
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface ILineaPedidoRepository
{
void setSessionCP (GenericSessionCP session);

LineaPedidoEN ReadOIDDefault (int num
                              );

void ModifyDefault (LineaPedidoEN lineaPedido);

System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size);



int New_ (LineaPedidoEN lineaPedido);

void Modify (LineaPedidoEN lineaPedido);


void Destroy (int num
              );


LineaPedidoEN ReadOID (int num
                       );


System.Collections.Generic.IList<LineaPedidoEN> ReadAll (int first, int size);
}
}
