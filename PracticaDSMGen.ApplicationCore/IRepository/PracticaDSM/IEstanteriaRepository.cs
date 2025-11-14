
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface IEstanteriaRepository
{
void setSessionCP (GenericSessionCP session);

EstanteriaEN ReadOIDDefault (int id
                             );

void ModifyDefault (EstanteriaEN estanteria);

System.Collections.Generic.IList<EstanteriaEN> ReadAllDefault (int first, int size);



int New_ (EstanteriaEN estanteria);

void Modify (EstanteriaEN estanteria);


void Destroy (int id
              );


EstanteriaEN ReadOID (int id
                      );


System.Collections.Generic.IList<EstanteriaEN> ReadAll (int first, int size);



System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> DameEstanteriaPorProducto (int ? p_idProducto);
}
}
