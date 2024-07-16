using CropManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace CropManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyWorkCategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DailyWorkCategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CropManagementCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand("sp_DailyWorkCategory_Select", myConn))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myReader = myCommand.ExecuteReader();
                    dt.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(dt);
        }
    }
}
