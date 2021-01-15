using appAchat_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace appAchat_MVC.Controllers
{
    public class videoController : Controller
    {
        ListVideos L = new ListVideos();
        private Client c;//= new Client();
        private int idVideo = 1;
        // GET: video/List.cshtml
        public ActionResult List()
        {
            return View(L.allVideos);
        }

        // GET: video/Details/{id}
        public ActionResult Details(int id)
        {         
            //ListVideos L = new ListVideos();
            Video v = L.allVideos.Single(s => s.ID == id);
            return View(v);
        }

       

        public ActionResult Buy(int id)
        {
            // GET: video/Buy/{id}
            this.idVideo = id;

            return View();
        }
            //Video v = L.allVideos.Single(s => s.ID == id);
         //   return View();
       // }

        [HttpPost]
        public ActionResult Payment(Client cc)
        {
           
            string acc = cc.Account;
            string passw = cc.Password;



            //IEnumerable<Client> students = null;
            Client tmpClient = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8055/api/client/");
                //HTTP GET
                var responseTask = client.GetAsync(acc);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Client>();
                    readTask.Wait();

                    tmpClient = readTask.Result;
                }
                else //web api sent error response 
                {
                   
                   return  RedirectToAction("Buy", new { id = idVideo });
                }
            }

            foreach (var v in L.allVideos)
            {
                if(v.ID == this.idVideo)
                {
                    if(tmpClient.Balance >= v.Prix)
                        c = new Client
                        {
                            ID = tmpClient.ID,
                            Name = "Ok",
                            Account = tmpClient.Account,
                            Password = tmpClient.Password
                        };
                    else
                        c = new Client
                        {
                            ID = tmpClient.ID,
                            Name = "insufficient balance",
                            Account = tmpClient.Account,
                            Password = tmpClient.Password
                        };

                    break;
                }
               

            }
        
            return View(c);
        }


    }
}