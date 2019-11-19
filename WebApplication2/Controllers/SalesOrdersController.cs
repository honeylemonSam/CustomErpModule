using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlTypes;
using WebApplication2.Model;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        // GET: api/SalesOrders
        [HttpGet]
        public string Get()
        {
            // connect to sap
            string connStr = "Data Source=DESKTOP-TV3KPRF;Initial Catalog=SBODemoUS;User ID=sa;Password=123;";
            Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connStr);
            conn.Open();


            //get data using query
            Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT [CardCode],[CardName],[DocNum], [DocDate],[DocTotal]FROM [dbo].[ORDR] WHERE [DocStatus] = 'O'ORDER BY [CardCode]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            List<SalesOrder> salesOrders = new List<SalesOrder>();
            //List<CardInfo> cardInfos = new List<CardInfo>();
            //read from db
            Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SalesOrder so = new SalesOrder()
                {
                    CardCode = reader["CardCode"].ToString(),
                    CardName = reader["CardName"].ToString(),
                    DocNum = reader["DocNum"].ToString(),
                    DocDate = reader["DocDate"].ToString(),
                    DocTotal = reader["DocTotal"].ToString()
                };

                salesOrders.Add(so);
                

            }

            conn.Close();

            return JsonConvert.SerializeObject(salesOrders);
        }




        // GET: api/SalesOrders/5
        // [HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"What can i help you {id}?";
        }

        // POST: api/SalesOrder/id
        [HttpPost ("{id}")]
        public string Post(string id)
        {
            // connect to sap
            string connStr = "Data Source=DESKTOP-TV3KPRF;Initial Catalog=SBODemoUS;User ID=sa;Password=123;";
            Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connStr);
            conn.Open();


            //get data using query
            Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT [CardCode],[CardName],[DocNum], [DocDate],[DocTotal]FROM [dbo].[ORDR] WHERE [DocStatus] = 'O'ORDER BY [CardCode]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            List<SalesOrder> salesOrders = new List<SalesOrder>();
            List<CardInfo> cardInfos = new List<CardInfo>();
            //read from db
            Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SalesOrder so = new SalesOrder()
                {
                    CardCode = reader["CardCode"].ToString(),
                    CardName = reader["CardName"].ToString(),
                    DocNum = reader["DocNum"].ToString(),
                    DocDate = reader["DocDate"].ToString(),
                    DocTotal = reader["DocTotal"].ToString()
                };


                if (id.ToUpper() == so.CardCode.ToUpper())
                {
                    salesOrders.Add(so);

                }


            }

            conn.Close();

            return JsonConvert.SerializeObject(salesOrders);
        }

        // PUT: api/SalesOrders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
