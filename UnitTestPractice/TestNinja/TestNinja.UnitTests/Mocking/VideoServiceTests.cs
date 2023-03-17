using Moq;
using System;
using System.Collections;
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
        private Mock<IFileReader> _mockFileReader;
        private Mock<IVideoRepository> _mockVideoRepository;
        private VideoService _service;

        [SetUp] public void SetUp() 
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockVideoRepository = new Mock<IVideoRepository>();
            _service = new VideoService(_mockFileReader.Object, _mockVideoRepository.Object);
        }

        [Test] 
        public void ReadVideoTitle_EmptyFile_ReturnsError()
        {
            _mockFileReader.Setup(fr => fr.ReadAllText("video.txt")).Returns("");

            Assert.That(() => _service.ReadVideoTitle(), Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenListIsEmpty_ShouldReturnEmptyString()
        {
            _mockVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>{});

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenListIsNotEmpty_ShouldReturnStringWithIds()
        {
            _mockVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video { Id = 1},
                new Video { Id = 2},
                new Video { Id = 3}
            });

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
