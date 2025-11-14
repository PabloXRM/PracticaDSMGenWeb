
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface INotificacionRepository
{
void setSessionCP (GenericSessionCP session);

NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int New_ (NotificacionEN notificacion);

void Modify (NotificacionEN notificacion);


void Destroy (int id
              );


NotificacionEN ReadOID (int id
                        );


System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size);
}
}
