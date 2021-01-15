using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appAchat_MVC.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public Double Balance { get; set; }

    }
}