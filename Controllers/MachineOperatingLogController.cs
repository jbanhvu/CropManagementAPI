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
    public class MachineOperatingLogController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MachineOperatingLogController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetLogs/{MachineOperatingLogID}")]
        public JsonResult Get( int MachineOperatingLogID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CropManagementCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand("sp_MachineOperatingLog_select", myConn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(myCommand))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@MachineOperatingLogID", MachineOperatingLogID);
                        adapter.Fill(ds);
                    }
                }

                myConn.Close();
                return new JsonResult(ds);
            }
        }
    }
}
