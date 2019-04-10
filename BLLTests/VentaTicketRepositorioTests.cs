using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Linq.Expressions;
using DAL;

namespace BLL.Tests
{
    [TestClass()]
    public class VentaTicketRepositorioTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            VentaTicket ventaTicket = new VentaTicket();
            ventaTicket.VentaTicketId = 01;
            ventaTicket.ClienteId = 01;
            ventaTicket.TicketId = 01;
            ventaTicket.Fecha = DateTime.Now;
            ventaTicket.SubTotal = 100;
            ventaTicket.Itbis = 18;
            ventaTicket.Total = 118;

            ventaTicket.Detalle.Add(new ConsultorioVenta(0, 1, 1, 2, 5, 10, 50));
            //ventaTicket.Detalle.Add(new VentaTicketDetalle(0, 2, 3, 4, 10, 40, 400));
            VentaTicketRepositorio ventaTicketRepositorio = new VentaTicketRepositorio();
            paso = ventaTicketRepositorio.Guardar(ventaTicket);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            VentaTicketRepositorio ventaTicketRepositorio = new VentaTicketRepositorio();
            int idVentaTicket = ventaTicketRepositorio.GetList(x => true)[0].VentaTicketId;
            VentaTicket ventaTicket = ventaTicketRepositorio.Buscar(idVentaTicket);

            ventaTicket.Detalle.Add(new ConsultorioVenta(0, ventaTicket.VentaTicketId, 2, 4, 2, 100, 200));
            bool paso = ventaTicketRepositorio.Modificar(ventaTicket);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            VentaTicketRepositorio ventaTicketRepositorio = new VentaTicketRepositorio();
            int idVentaTicket = ventaTicketRepositorio.GetList(x => true)[0].VentaTicketId;
            bool paso = ventaTicketRepositorio.Eliminar(idVentaTicket);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            VentaTicketRepositorio ventaTicketRepositorio = new VentaTicketRepositorio();
            int idVentaTicket = ventaTicketRepositorio.GetList(x => true)[0].VentaTicketId;

            VentaTicket ventaTicket = ventaTicketRepositorio.Buscar(idVentaTicket);
            bool paso = ventaTicket.Detalle.Count > 0;
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<VentaTicket, bool>> expression)
        {
            Contexto contexto = new Contexto();
            VentaTicketRepositorio repositorio = new VentaTicketRepositorio();
            List<VentaTicket> ListVenta = new List<VentaTicket>();
            ListVenta = repositorio.GetList(expression);
            Assert.IsNotNull(ListVenta);
        }

        [TestMethod()]
        public void ModificarBienTest()
        {
            VentaTicketRepositorio ventaTicketRepositorio = new VentaTicketRepositorio();
            int idVentaTicket = ventaTicketRepositorio.GetList(x => true)[0].VentaTicketId;
            VentaTicket ventaTicket = ventaTicketRepositorio.Buscar(idVentaTicket);

            ventaTicket.Detalle.Add(new ConsultorioVenta(0, ventaTicket.VentaTicketId, 2, 4, 2, 100, 200));
            bool paso = ventaTicketRepositorio.Guardar(ventaTicket);
            Assert.AreEqual(true, paso);
        }
    }
}