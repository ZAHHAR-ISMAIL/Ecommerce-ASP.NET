using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appAchat_MVC.Models
{
    public class Video
    {
        public int ID { get; set; }
  
        public string Name { get; set; }
        public Double Prix { get; set; }
        public String Duration { get; set; }
        public string Image { get; set; }
    }
}