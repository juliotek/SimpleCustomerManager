using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryCustomer;
using InterfacesCustomer;
using InterfacesData;

namespace ADORepository
{
    public class CustomerADO : Template<ICustomer>, IDataRepository<ICustomer>
    {
        private readonly FactoryCustumerService<ICustomer> _custumerFactory;

        public CustomerADO(string ConnectionString, FactoryCustumerService<ICustomer> custumerFactory) : base(ConnectionString)
        {
            _custumerFactory = custumerFactory;
        }

        protected override void ExecuteCommand(ICustomer entity)
        {
            objCommand.CommandText = "INSERT INTO tbCustomers("+
                                              "Name,"+
                                              "BillAmount,BillDate,"+
                                              "PhoneNumber,Address)"+
                                              $"VALUES('{entity.Name}',"+
                                              entity.BillAmount + ",'" +
                                              entity.BillDate + "','" +
                                              entity.PhoneNumber + "','" +
                                              entity.Address + "')";
            objCommand.ExecuteNonQuery();
        }

        protected override List<ICustomer> ExecuteCommand()
        {
            objCommand.CommandText = "SELECT * FROM tbCustomers";

            SqlDataReader dr = objCommand.ExecuteReader();
            List<ICustomer> custs = new List<ICustomer>();

            while (dr.Read())
            {
                ICustomer icust = _custumerFactory.Create("Customer");
                icust.Name = dr["Name"]?.ToString();
                icust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                icust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                icust.PhoneNumber = dr["PhoneNumber"]?.ToString();
                icust.Address = dr["Address"]?.ToString();
                custs.Add(icust);
            }
            return custs;
        }
    }
}
