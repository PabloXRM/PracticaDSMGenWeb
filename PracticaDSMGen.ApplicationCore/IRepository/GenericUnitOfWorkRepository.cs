
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IPerfilRepository perfilrepository;
protected IMetodoPagoRepository metodopagorepository;
protected IProductoRepository productorepository;
protected IReseñaRepository reseñarepository;
protected IPedidoRepository pedidorepository;
protected ILineaPedidoRepository lineapedidorepository;
protected IFacturaRepository facturarepository;
protected IEstanteriaRepository estanteriarepository;
protected INotificacionRepository notificacionrepository;
protected IAdminRepository adminrepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IPerfilRepository PerfilRepository {
        get;
}
public abstract IMetodoPagoRepository MetodoPagoRepository {
        get;
}
public abstract IProductoRepository ProductoRepository {
        get;
}
public abstract IReseñaRepository ReseñaRepository {
        get;
}
public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract ILineaPedidoRepository LineaPedidoRepository {
        get;
}
public abstract IFacturaRepository FacturaRepository {
        get;
}
public abstract IEstanteriaRepository EstanteriaRepository {
        get;
}
public abstract INotificacionRepository NotificacionRepository {
        get;
}
public abstract IAdminRepository AdminRepository {
        get;
}
}
}
