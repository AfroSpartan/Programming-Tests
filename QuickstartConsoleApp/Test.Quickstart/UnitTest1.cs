using NUnit.Framework;
using System.Linq;
using System.IO;

namespace Test.Quickstart
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Quickstart_Clone_SuccessfullyClones()
        {
            var repoURL = "https://github.com/github/platform-samples.git";
            var repoName = repoURL.Split("/").Last().Split(".")[0];



            Assert.IsTrue(Directory.Exists($"{Directory.GetCurrentDirectory()}/{repoName}"));
        }

        [Test]
        public void Quickstart_Clone_OutputsExpectedNumberOfCommits()
        {
            Assert.Pass();
        }
    }
}