
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface IPerfilRepository
{
void setSessionCP (GenericSessionCP session);

PerfilEN ReadOIDDefault (int id
                         );

void ModifyDefault (PerfilEN perfil);

System.Collections.Generic.IList<PerfilEN> ReadAllDefault (int first, int size);



int New_ (PerfilEN perfil);

void Modify (PerfilEN perfil);


void Destroy (int id
              );


PerfilEN ReadOID (int id
                  );


System.Collections.Generic.IList<PerfilEN> ReadAll (int first, int size);
}
}
