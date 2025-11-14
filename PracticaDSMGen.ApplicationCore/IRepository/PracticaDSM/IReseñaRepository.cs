
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface IReseñaRepository
{
void setSessionCP (GenericSessionCP session);

ReseñaEN ReadOIDDefault (int id
                         );

void ModifyDefault (ReseñaEN reseña);

System.Collections.Generic.IList<ReseñaEN> ReadAllDefault (int first, int size);



int New_ (ReseñaEN reseña);

void Modify (ReseñaEN reseña);


void Destroy (int id
              );


ReseñaEN ReadOID (int id
                  );


System.Collections.Generic.IList<ReseñaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> DameReseñaPorProducto (int ? p_idProducto);
}
}
