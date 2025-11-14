
using System;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public partial interface IAdminRepository
{
void setSessionCP (GenericSessionCP session);

AdminEN ReadOIDDefault (string email
                        );

void ModifyDefault (AdminEN admin);

System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size);



string New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (string email
              );


AdminEN ReadOID (string email
                 );


System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size);
}
}
