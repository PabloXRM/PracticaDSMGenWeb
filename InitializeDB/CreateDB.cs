
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository.PracticaDSM;
using PracticaDSMGen.Infraestructure.CP;
using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.CP.PracticaDSM;
using PracticaDSMGen.Infraestructure.Repository;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                PerfilRepository perfilrepository = new PerfilRepository ();
                PerfilCEN perfilcen = new PerfilCEN (perfilrepository);
                MetodoPagoRepository metodopagorepository = new MetodoPagoRepository ();
                MetodoPagoCEN metodopagocen = new MetodoPagoCEN (metodopagorepository);
                ProductoRepository productorepository = new ProductoRepository ();
                ProductoCEN productocen = new ProductoCEN (productorepository);
                ReseñaRepository reseñarepository = new ReseñaRepository ();
                ReseñaCEN reseñacen = new ReseñaCEN (reseñarepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                LineaPedidoRepository lineapedidorepository = new LineaPedidoRepository ();
                LineaPedidoCEN lineapedidocen = new LineaPedidoCEN (lineapedidorepository);
                FacturaRepository facturarepository = new FacturaRepository ();
                FacturaCEN facturacen = new FacturaCEN (facturarepository);
                EstanteriaRepository estanteriarepository = new EstanteriaRepository ();
                EstanteriaCEN estanteriacen = new EstanteriaCEN (estanteriarepository);
                NotificacionRepository notificacionrepository = new NotificacionRepository ();
                NotificacionCEN notificacioncen = new NotificacionCEN (notificacionrepository);
                AdminRepository adminrepository = new AdminRepository ();
                AdminCEN admincen = new AdminCEN (adminrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                string idUsuario = usuariocen.New_ ("prueba@gmail.com", "Prueba", null, "C/Prueba 2", new DateTime (2000, 10, 10), 03005, "prueba");
                Console.WriteLine ("Se ha creado al usuario correctamente");

                //Login
                if (usuariocen.Login ("prueba@gmail.com", "prueba") != null)
                        Console.WriteLine ("El login es correcto");

                string idUsuario2 = admincen.New_ ("admin@gmail.com", "Admin", null, "C/Admin 32", new DateTime (1990, 05, 09), 03007, "admin", "0001");
                Console.WriteLine ("Se ha creado al usuario admin correctamente");

                //New customizada
                int idPerfil = perfilcen.New_ (idUsuario);
                Console.WriteLine ("Se ha creado el perfil correctamente");

                int idMetodoPago = metodopagocen.New_ (idUsuario, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoPagoEnum.Visa, true);
                Console.WriteLine ("Se ha creado el metodo de pago correctamente");

                int idProducto = productocen.New_ ("Vinilo bla bla bla", 93, 50, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum.vinilo, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum.rock, "fotovinilo1.png", "Artista");
                int idProducto2 = productocen.New_ ("CD bla bla bla", 29, 200, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum.cd, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum.pop, "fotocd1.png", "Artista2");
                int idProducto3 = productocen.New_ ("Vinilo2 bla bla bla", 58, 10, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum.vinilo, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum.jazz, "fotovinilo2.png", "Artista3");
                Console.WriteLine ("Se han creado los productos correctamente");

                IList<int> productosIds = new List<int> { idProducto, idProducto2, idProducto3 };

                int idEstanteria = estanteriacen.New_ (idUsuario, productosIds, "Mi estanteria personal", "4,5/5", 923, true);
                Console.WriteLine ("Se ha creado la estanteria correctamente");

                //Modify customizada
                estanteriacen.Modify (idEstanteria, "Estanteria modificada", "4,3/5", 950);

                //Custom
                estanteriacen.AlternarVisibilidad (idEstanteria, true);
                Console.WriteLine ("Se ha publicado la estantería: " + idEstanteria);

                //New customizada
                int idPedido = pedidocen.New_ (idUsuario, idMetodoPago, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.CarritoEnum.conArticulos, "40938275", new DateTime (2025, 10, 20), 0);
                Console.WriteLine ("Se ha creado el pedido correctamente");

                //Custom CRUD transaction
                LineaPedidoCP lineapedidoCP = new LineaPedidoCP (new SessionCPNHibernate ());

                lineapedidoCP.New_ (idPedido, 2, idProducto, 20);
                lineapedidoCP.New_ (idPedido, 5, idProducto2, 10);
                lineapedidoCP.New_ (idPedido, 3, idProducto3, 60);
                Console.WriteLine ("Se han creado las lineas de pedido correctamente");


                //Custom
                pedidocen.DescuentoPrecio (idPedido, 15); //En porcentaje
                Console.WriteLine ("Se ha aplicado el descuento correctamente");

                //CustomTransaction
                PedidoCP pedidoCP = new PedidoCP (new SessionCPNHibernate ());
                pedidoCP.EnviarPedido (idPedido);

                //Custom (ya no hace falta por la CustomTransaction)
                /*
                 * productocen.DecrementarStock (idProducto, 2);
                 * productocen.DecrementarStock (idProducto2, 5);
                 * productocen.DecrementarStock (idProducto3, 3);
                 * Console.WriteLine ("Se ha decrementado el stock de los productos correctamente");
                 */

                //CustomTransaction
                pedidoCP.CancelarPedido (idPedido);

                //Custom (ya no hace falta por la CustomTransaction)
                /*
                 * productocen.IncrementarStock (idProducto, 20);
                 * Console.WriteLine ("Se ha incrementadoo el stock de los productos correctamente");
                 */

                int idFactura = facturacen.New_ (idPedido, "000237", 99, new DateTime (2025, 10, 10));
                Console.WriteLine ("Se ha creado la factura correctamente");

                int idReseña = reseñacen.New_ (idUsuario, idProducto3, "Muy buen producto", 4, new DateTime (2025, 12, 12));
                Console.WriteLine ("Se ha creado la reseña correctamente");
                int idReseña2 = reseñacen.New_ (idUsuario2, idProducto3, "Cumple con la descripcion", 3, new DateTime (2024, 10, 02));
                Console.WriteLine ("Se ha creado la reseña2 correctamente");

                int idNotificacion = notificacioncen.New_ (idUsuario2, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoNotificacionEnum.novedad, new DateTime (2025, 03, 10), "Novedad en vinilos", "Nuevos vinilos disponibles", "foto1.jpg");
                Console.WriteLine ("Se ha creado la notificación correctamente");

                //Filter
                IList<PedidoEN> pedidosPorArt = pedidocen.DamePedidosPorProducto (idProducto);
                Console.WriteLine ("Consultamos los pedidos con el producto: " + idProducto);

                foreach (PedidoEN pedido in pedidosPorArt) {
                        Console.WriteLine ("Contiene el pedido: " + pedido.Id);
                }

                //Filter
                IList<UsuarioEN> usuarioPorEstanteria = usuariocen.DamePorEstanteria (idEstanteria);
                Console.WriteLine ("Consultamos el usuario con la estanteria:" + idEstanteria);
                foreach (UsuarioEN usuario in usuarioPorEstanteria) {
                        Console.WriteLine ("Nombre usuario de la estanteria: " + usuario.Nombre);
                }

                //Filter
                IList<UsuarioEN> usuarioPorReseña = usuariocen.DamePorReseña (idReseña);
                Console.WriteLine ("Consultamos el usuario con la reseña:" + idReseña);
                foreach (UsuarioEN usuario in usuarioPorReseña) {
                        Console.WriteLine ("Email del usuario de la reseña: " + usuario.Email);
                }

                //Filter
                IList<EstanteriaEN> estanteriaPorProducto = estanteriacen.DameEstanteriaPorProducto (idProducto2);
                Console.WriteLine ("Consultamos  estanterias con el producto: " + idProducto2);
                foreach (EstanteriaEN estanteria in estanteriaPorProducto) {
                        Console.WriteLine ("ID de la estanteria con el producto: " + estanteria.Id);
                }

                //Filter
                IList<ReseñaEN> reseñaPorPorducto = reseñacen.DameReseñaPorProducto (idProducto3);
                Console.WriteLine ("Consultamos las reseñas con el producto: " + idProducto3);
                foreach (ReseñaEN reseña in reseñaPorPorducto) {
                        Console.WriteLine ("Descripcion de las reseñas con el producto: " + reseña.Descripcion);
                }

                //Comprobar PrecioTotal despues de descuento
                PedidoEN pedidoEN = pedidocen.ReadOID (idPedido);
                Console.WriteLine ("El total del pedido es: " + pedidoEN.TotalPrecio);

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
