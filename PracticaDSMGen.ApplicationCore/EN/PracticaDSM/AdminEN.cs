
using System;
// Definición clase AdminEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class AdminEN                                                                        : PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN


{
/**
 *	Atributo idAdmin
 */
private string idAdmin;






public virtual string IdAdmin {
        get { return idAdmin; } set { idAdmin = value;  }
}





public AdminEN() : base ()
{
}



public AdminEN(string email, string idAdmin
               , System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> pedido, string nombre, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PerfilEN perfil, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanteria, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> reseña, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.NotificacionEN> notificacion, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN> metodoPago, string direccion, Nullable<DateTime> fechaNacimiento, int codPostal, String pass
               )
{
        this.init (Email, idAdmin, pedido, nombre, perfil, estanteria, reseña, notificacion, metodoPago, direccion, fechaNacimiento, codPostal, pass);
}


public AdminEN(AdminEN admin)
{
        this.init (admin.Email, admin.IdAdmin, admin.Pedido, admin.Nombre, admin.Perfil, admin.Estanteria, admin.Reseña, admin.Notificacion, admin.MetodoPago, admin.Direccion, admin.FechaNacimiento, admin.CodPostal, admin.Pass);
}

private void init (string email
                   , string idAdmin, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> pedido, string nombre, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PerfilEN perfil, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanteria, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> reseña, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.NotificacionEN> notificacion, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN> metodoPago, string direccion, Nullable<DateTime> fechaNacimiento, int codPostal, String pass)
{
        this.Email = email;


        this.IdAdmin = idAdmin;

        this.Pedido = pedido;

        this.Nombre = nombre;

        this.Perfil = perfil;

        this.Estanteria = estanteria;

        this.Reseña = reseña;

        this.Notificacion = notificacion;

        this.MetodoPago = metodoPago;

        this.Direccion = direccion;

        this.FechaNacimiento = fechaNacimiento;

        this.CodPostal = codPostal;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
