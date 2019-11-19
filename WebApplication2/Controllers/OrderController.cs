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
    public class OrderController : ControllerBase
    {
        // GET: api/Order
        [HttpGet]
        public string Get()
        {
            
            // connect to sap
            string connStr = "Data Source=DESKTOP-TV3KPRF;Initial Catalog=SBODemoUS;User ID=sa;Password=123;";
            Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connStr);
            conn.Open();


            //get data using query
            Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT [CardCode], [cardName],[Address],[CreateDate] FROM[dbo].[OCRD]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;


            List<SalesOrder> salesOrders = new List<SalesOrder>();
            List<CardInfo> cardInfos = new List<CardInfo>();
            //read from db
            Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CardInfo card = new CardInfo()
                {
                    Address = reader["Address"].ToString(),
                    CardCode = reader["CardCode"].ToString(),
                    CardName = reader["CardName"].ToString(),
                    CreateDate = reader["CreateDate"].ToString()
                };

                cardInfos.Add(card);
                //temp += reader["CardCode"].ToString();
                //temp += "\t";
                //temp += reader["cardName"].ToString();
                //temp += "\t\t\t\t";
                //temp += reader["Address"].ToString();
                //temp += "\t\t\t\t\t";
                //temp += reader["CreateDate"].ToString();
                //temp += "  \n";

            }

            conn.Close();

            return JsonConvert.SerializeObject(cardInfos);
        }

        // GET: api/Order/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return $"What can i help you {id}?";
        }

        // POST: api/Order/id
        [HttpPost("{id}")]
        public string Post(string id)
        {

            //i add a new line
            //i add another line

            // connect to sap
            string connStr = "Data Source=DESKTOP-TV3KPRF;Initial Catalog=SBODemoUS;User ID=sa;Password=123;";
            Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connStr);
            conn.Open();


            //get data using query
            Microsoft.Data.SqlClient.SqlCommand cmd =new Microsoft.Data.SqlClient.SqlCommand("SELECT [CardCode], [cardName],[Address],[CreateDate] FROM[dbo].[OCRD]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;


            List<SalesOrder> salesOrders = new List<SalesOrder>();
            List<CardInfo> cardInfos = new List<CardInfo>();
            //read from db
            Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CardInfo card = new CardInfo()
                {
                    Address = reader["Address"].ToString(),
                    CardCode = reader["CardCode"].ToString(),
                    CardName = reader["cardName"].ToString(),
                    CreateDate = reader["CreateDate"].ToString()
                };

                if(id == card.CardCode)
                {
                    cardInfos.Add(card);
                }
                //temp += reader["CardCode"].ToString();
                //temp += "\t";
                //temp += reader["cardName"].ToString();
                //temp += "\t\t\t\t";
                //temp += reader["Address"].ToString();
                //temp += "\t\t\t\t\t";
                //temp += reader["CreateDate"].ToString();
                //temp += "  \n";

            }
            
            conn.Close();
            
            return JsonConvert.SerializeObject(cardInfos);
            //return ($"CardCode \t CardName \t\t\t\t Address \t\t\t\t\t Posting Date \n %s",cardName);
            //return $"Login Failed";
        }


        // PUT: api/Order/5
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
               
            

            //return $"Login Failed";


        }


   

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class OrderRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public OrderType Category { get; set; }
    }

    
    public enum OrderType
    {
        Sales,
        Order,
        Material,
        
    }

