using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        // Testing using Constructor Injection. We are going to create a property using the interface
        private IFileReader _fileReader;
        private IVideoRepository _videoRepository;

        // Deleted our default constructor and set fileReader to null, this is like our default construcotr. 
        public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null)
        {
            // This means, if fileReader is not null, you will use the parameter to set the private field.  
            // Otherwise if null, new up a new FileReader object (like in our default constructor. 
            _fileReader = fileReader ?? new FileReader();
            _videoRepository = videoRepository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");    //File.ReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>(); // Creating an empty list

            var videos = _videoRepository.GetUnprocessedVideos();
            foreach (var v in videos) // Iterate over them, get their ID, and add it to a list
                videoIds.Add(v.Id);

            return String.Join(",", videoIds); // Return as a string

        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}