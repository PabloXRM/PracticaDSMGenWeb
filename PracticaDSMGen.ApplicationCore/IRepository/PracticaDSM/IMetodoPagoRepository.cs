
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface IMetodoPagoRepository
{
void setSessionCP (GenericSessionCP session);

MetodoPagoEN ReadOIDDefault (int id
                             );

void ModifyDefault (MetodoPagoEN metodoPago);

System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size);



int New_ (MetodoPagoEN metodoPago);

void Modify (MetodoPagoEN metodoPago);


void Destroy (int id
              );


MetodoPagoEN ReadOID (int id
                      );


System.Collections.Generic.IList<MetodoPagoEN> ReadAll (int first, int size);
}
}
