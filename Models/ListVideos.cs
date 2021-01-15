using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appAchat_MVC.Models
{
    public class ListVideos
    {
        public List<Video> allVideos = new List<Video>();
        public ListVideos()
        {
           
            allVideos.Add(new Video
            {
                ID = 1,
                Name = "Naruto movie ",
                Prix = 49.99,
                Duration = "18:39",
                Image = "naruto.jpg"
            });
            allVideos.Add(new Video
            {
                ID = 2,
                Name = "Footbal: Messi Vs Real Madrid 2020 ",
                Prix = 20.00,
                Duration = "15:04",
                Image = "fcb.jpg"
            });
            allVideos.Add(new Video
            {
                ID = 3,
                Name = "Match Box ",
                Prix = 100.00,
                Duration = "02:39:45",
                Image = "box.jpg"
            });
            allVideos.Add(new Video
            {
                ID = 4,
                Name = "Avatar movie ",
                Prix = 99.99,
                Duration = "01:18:50",
                Image = "avatar.jpg"
            });
            allVideos.Add(new Video
            {
                ID = 5,
                Name = "Football: Achraf Vs Bayern ",
                Prix = 49.99,
                Duration = "19:30",
                Image = "bvb.jpg"
            });
        }
        public List<Video> getAllVideos()
        {
            return allVideos;
        }
    }
}