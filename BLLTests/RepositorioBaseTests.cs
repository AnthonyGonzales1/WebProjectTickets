using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Linq.Expressions;


namespace BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            Cliente cliente = new Cliente();
            bool paso = false;

            cliente.ClienteId = 02;
            cliente.Nombres = "Mario";
            cliente.Telefono = "8098971234";
            cliente.Deuda = 0;

            paso = repositorio.Guardar(cliente);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteId = 03;
            cliente.Nombres = "Anthonys";
            cliente.Telefono = "8091433420";
            cliente.Deuda = 140;

            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            paso = repositorio.Modificar(cliente);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 03;
            bool paso;

            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 02;
            Cliente cliente = new Cliente();

            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            cliente = repositorio.Buscar(id);
            Assert.IsNotNull(cliente);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Cliente, bool>> expression)
        {
            Contexto contexto = new Contexto();
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            List<Cliente> ListCliente = new List<Cliente>();
            ListCliente = repositorio.GetList(expression);
            Assert.IsNotNull(ListCliente);
        }

        [TestMethod()]
        public void GuardarTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModificarTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}