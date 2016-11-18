using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public class 奇思妙用
    {

        public void ToJson()
        {
            //var aa = new { A = 1, b = 2, C = 3 };


            //var aaStr = JsonConvert.SerializeObject(aa);


            var aaStr = "{\"A\":\"ACONTEXT\",\"B\":\"bContext\"}";

            var aaObject = JsonConvert.DeserializeObject<dynamic>(aaStr);

            var ac = aaObject.A;
        }

    }
}
