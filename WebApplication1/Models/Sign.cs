using Microsoft.Build.Framework;
using System.ComponentModel;

namespace WebApplication1.Models
{

    public class Sign
    {

        public int ID { get; set; }

        //签名

        [DisplayName("签名")]
        public string field1 { get; set; }

        //中签
        [DisplayName("中签")]
        public string field2 { get; set; }

        //诗曰
        [DisplayName("诗曰")]
        public string field3 { get; set; }

        //解曰
        [DisplayName("解曰")]
        public string field4 { get; set; }

        //签语
        [DisplayName("签语")]
        public string field5 { get; set; }


        //仙机
        [DisplayName("仙机")]
        public string field6 { get; set; }

        //古人典故
        [DisplayName("古人典故")]
        public string field7 { get; set; }

        //古人典故明细
        [DisplayName("古人典故明细")]
        public string field8 { get; set; }

    }

}
