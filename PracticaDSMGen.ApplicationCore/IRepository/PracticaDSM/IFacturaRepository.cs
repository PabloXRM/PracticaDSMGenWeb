
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface IFacturaRepository
{
void setSessionCP (GenericSessionCP session);

FacturaEN ReadOIDDefault (int id
                          );

void ModifyDefault (FacturaEN factura);

System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size);



int New_ (FacturaEN factura);

void Modify (FacturaEN factura);


void Destroy (int id
              );


FacturaEN ReadOID (int id
                   );


System.Collections.Generic.IList<FacturaEN> ReadAll (int first, int size);
}
}
