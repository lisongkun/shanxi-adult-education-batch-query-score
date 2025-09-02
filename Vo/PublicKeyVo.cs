using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanxiAdultEducationBatchQueryScore.Vo
{
    /// <summary>
    /// PublicKey的响应体
    /// </summary>
    public class PublicKeyVo
    {
        public bool isTrue { get; set; }
        public string publicKey { get; set; }
        public string message { get; set; }
    }
}
