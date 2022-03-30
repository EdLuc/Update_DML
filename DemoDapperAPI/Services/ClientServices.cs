using Dapper;
using DapperExtensions;
using DemoDapperAPI.DML;
using DemoDapperAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDapperAPI.Services
{
    public class ClientServices
    {
        private SqlConnection _Conn = new();
        //Instalar Dapper y SQL
        private static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(@"Data Source=localhost; Initial Catalog=ClienteIX; Integrated Security=True; Pooling=False");
        }
        public Cliente GetClientById(int id)
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select
            var cliente = _Conn.Query<Cliente>("SELECT * FROM Cliente").Where(f => f.id == id).ToList();
            return cliente.Count != 0 ? cliente.First(): null;
        }
        public IEnumerable<Cliente> GetClients()
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select
            var clientes = _Conn.Query<Cliente>("SELECT * FROM Cliente").ToList();
            return clientes;
        }
        public async Task<IEnumerable<Cliente>> GetClientsAsync()
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select
            var clientes = await _Conn.QueryAsync<Cliente>("SELECT * FROM Cliente");
            return clientes;
        }

        public void AddClient(Cliente cliente)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                var clientes = _Conn.Execute(strInsert, cliente);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void UpdateClient(Cliente cliente, bool UserDapper = true)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                if (true)
                {
                    _Conn.Update(cliente);
                    _Conn.Close();
                }
                else
                {
                    // var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                    // var clientes = _Conn.Execute(strInsert, cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task UpdateClientAsync(Cliente cliente, bool UserDapper = true)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                if (UserDapper)
                {
                    await _Conn.UpdateAsync(cliente);
                    _Conn.Close();
                }
                else
                {
                    var strInsert = DMLGenerator.UpdateInsertStatement(cliente);
                    var clientes = _Conn.Execute(strInsert, cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
