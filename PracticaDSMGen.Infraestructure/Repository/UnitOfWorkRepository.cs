

using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using PracticaDSMGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaDSMGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IPerfilRepository PerfilRepository {
        get
        {
                this.perfilrepository = new PerfilRepository ();
                this.perfilrepository.setSessionCP (session);
                return this.perfilrepository;
        }
}

public override IMetodoPagoRepository MetodoPagoRepository {
        get
        {
                this.metodopagorepository = new MetodoPagoRepository ();
                this.metodopagorepository.setSessionCP (session);
                return this.metodopagorepository;
        }
}

public override IProductoRepository ProductoRepository {
        get
        {
                this.productorepository = new ProductoRepository ();
                this.productorepository.setSessionCP (session);
                return this.productorepository;
        }
}

public override IReseñaRepository ReseñaRepository {
        get
        {
                this.reseñarepository = new ReseñaRepository ();
                this.reseñarepository.setSessionCP (session);
                return this.reseñarepository;
        }
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override ILineaPedidoRepository LineaPedidoRepository {
        get
        {
                this.lineapedidorepository = new LineaPedidoRepository ();
                this.lineapedidorepository.setSessionCP (session);
                return this.lineapedidorepository;
        }
}

public override IFacturaRepository FacturaRepository {
        get
        {
                this.facturarepository = new FacturaRepository ();
                this.facturarepository.setSessionCP (session);
                return this.facturarepository;
        }
}

public override IEstanteriaRepository EstanteriaRepository {
        get
        {
                this.estanteriarepository = new EstanteriaRepository ();
                this.estanteriarepository.setSessionCP (session);
                return this.estanteriarepository;
        }
}

public override INotificacionRepository NotificacionRepository {
        get
        {
                this.notificacionrepository = new NotificacionRepository ();
                this.notificacionrepository.setSessionCP (session);
                return this.notificacionrepository;
        }
}

public override IAdminRepository AdminRepository {
        get
        {
                this.adminrepository = new AdminRepository ();
                this.adminrepository.setSessionCP (session);
                return this.adminrepository;
        }
}
}
}

