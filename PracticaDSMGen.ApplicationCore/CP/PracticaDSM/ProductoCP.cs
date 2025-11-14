
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
public partial class ProductoCP : GenericBasicCP
{
public ProductoCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public ProductoCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
