using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ALG_PSQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BsqController : ControllerBase
    {
        // POST api/bsq
        [HttpPost]
        public string Post([FromBody] JObject postData)
        {
            JsonData data = JsonConvert.DeserializeObject<JsonData>(postData.ToString());

            //Console.WriteLine("\n\n" + data.expr + "\n\n");
            var eval = new EvalExprAlgo.Eval();

            eval.initApiCall(data.expr);
            eval.parseExprToRpn();
            eval.calcRpn();
            
            return JsonConvert.SerializeObject(eval);
        }
    }

    public class JsonData
    {
        public string expr { get; set; }
    }
}
