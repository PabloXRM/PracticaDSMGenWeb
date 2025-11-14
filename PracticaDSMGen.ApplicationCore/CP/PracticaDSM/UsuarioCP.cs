
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.Utils;



namespace PracticaDSMGen.ApplicationCore.CP.PracticaDSM
{
public partial class UsuarioCP : GenericBasicCP
{
public UsuarioCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public UsuarioCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
