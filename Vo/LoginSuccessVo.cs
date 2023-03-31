using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanxiAdultEducationBatchQueryScore.Vo
{
    public class LoginSuccessVo
    {
        public string result { get; set; }

        public string url { get; set; }

        public LoginSuccessVo()
        {
            result = string.Empty;
            url = string.Empty;
        }
    }
}
