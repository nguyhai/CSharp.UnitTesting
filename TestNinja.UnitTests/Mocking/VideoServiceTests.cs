using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IVideoRepository> _repository;
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var fileReader = new Mock<IFileReader>();

            // fr, FileReader, goes to fr.Read and we specify the argument, video.txt so with this we are telling this mock filereader that 
            // when we call the read method with this argument, it should return some string.
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var service = new VideoService(fileReader.Object);

            var result = service.ReadVideoTitle(); // Remember, our mock object here returns empty string, file is empty

            Assert.That(result, Does.Contain("Error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            // Arrnage
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            Assert.That(result, Is.EqualTo(""));

        }


        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            // Arrnage
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>()
            {
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3}

            }

                );

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            Assert.That(result, Is.EqualTo("1,2,3"));

        }


    }
}
