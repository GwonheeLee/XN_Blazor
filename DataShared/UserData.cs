using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShared
{
    public class User
    {
        [Required(ErrorMessage ="아이디를 입력해주세요")]
        public string User_ID { get; set; }
        public string User_Name { get; set; }
        [Required(ErrorMessage ="비밀번호를 입력해주세요")]
        public string User_PW { get; set; }
        public string Customer_Code { get; set; }
        public bool IsEmp { get; set; }
    }
}
