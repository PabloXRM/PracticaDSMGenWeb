
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (string email
                          );

        void ChangePassword(string p_Usuario_OID, string p_newPassHashed);


        void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string email
              );


UsuarioEN ReadOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);



System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN> DamePorEstanteria (int ? p_idEstanteria);


System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN> DamePorReseña (int ? p_idReseña);
}
}
