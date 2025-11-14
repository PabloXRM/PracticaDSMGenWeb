

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionRepository _INotificacionRepository;

public NotificacionCEN(INotificacionRepository _INotificacionRepository)
{
        this._INotificacionRepository = _INotificacionRepository;
}

public INotificacionRepository get_INotificacionRepository ()
{
        return this._INotificacionRepository;
}

public int New_ (string p_usuario, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoNotificacionEnum p_tipo, Nullable<DateTime> p_fecha, string p_titulo, string p_descripcion, string p_fotos)
{
        NotificacionEN notificacionEN = null;
        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();

        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                notificacionEN.Usuario = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN ();
                notificacionEN.Usuario.Email = p_usuario;
        }

        notificacionEN.Tipo = p_tipo;

        notificacionEN.Fecha = p_fecha;

        notificacionEN.Titulo = p_titulo;

        notificacionEN.Descripcion = p_descripcion;

        notificacionEN.Fotos = p_fotos;



        oid = _INotificacionRepository.New_ (notificacionEN);
        return oid;
}

public void Modify (int p_Notificacion_OID, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoNotificacionEnum p_tipo, Nullable<DateTime> p_fecha, string p_titulo, string p_descripcion, string p_fotos)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Tipo = p_tipo;
        notificacionEN.Fecha = p_fecha;
        notificacionEN.Titulo = p_titulo;
        notificacionEN.Descripcion = p_descripcion;
        notificacionEN.Fotos = p_fotos;
        //Call to NotificacionRepository

        _INotificacionRepository.Modify (notificacionEN);
}

public void Destroy (int id
                     )
{
        _INotificacionRepository.Destroy (id);
}

public NotificacionEN ReadOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionRepository.ReadOID (id);
        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionRepository.ReadAll (first, size);
        return list;
}
}
}
