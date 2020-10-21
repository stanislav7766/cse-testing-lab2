using System;
using System.IO;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        static readonly string workingDirectory = Environment.CurrentDirectory;
        private readonly string testsDirFullPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\tests-dir";

        [Fact]
        public void TestGetFileName()
        {
            string fileNameExpected = "TestFileName.txt";
            string fileFullPath = testsDirFullPath + "\\" + fileNameExpected;
            string fileNameReal =  IIG.FileWorker.BaseFileWorker.GetFileName(fileFullPath);
          
            Assert.Equal(fileNameExpected, fileNameReal);
        }
        [Fact]
        public void TestGetFullPath()
        {
            string fullPathExpected = testsDirFullPath+ "\\TestFileName.txt";
            string localPath = new Uri(fullPathExpected).LocalPath;
            string fullPathReal = IIG.FileWorker.BaseFileWorker.GetFullPath(localPath);
            Assert.Equal(fullPathExpected, fullPathReal);
        }
        [Fact]
        public void TestGetPath()
        {
            string fullFilePathExpected = testsDirFullPath+ "\\TestFileName.txt";
            string filePathExpected = testsDirFullPath;
            string fullPathReal = IIG.FileWorker.BaseFileWorker.GetPath(fullFilePathExpected);
            Assert.Equal(filePathExpected, fullPathReal);
        }
        [Fact]
        public void TestMkDir()
        {
            string fullPathExpected = workingDirectory + "\\TestMkDir";
            string fullPathReal = IIG.FileWorker.BaseFileWorker.MkDir("TestMkDir");
            Assert.Equal(fullPathExpected, fullPathReal);
        }
        [Fact]
        public void TestReadAll()
        {
            string fullPathExpected = testsDirFullPath+ "\\TestFileName.txt";
            string contentExpected = "line1\r\nline2";
            string contentReal = IIG.FileWorker.BaseFileWorker.ReadAll(fullPathExpected);
            Assert.Equal(contentExpected, contentReal);
        }
        [Fact]
        public void TestReadLines()
        {
            string fileFullPath = testsDirFullPath+ "\\TestFileName.txt";
            string[] linesExpected = { "line1", "line2" };
            string[] lines = IIG.FileWorker.BaseFileWorker.ReadLines(fileFullPath);
            Assert.Equal(linesExpected, lines);
        }

        [Fact]
        public void TestTryCopyRewriteAllow()
        {
            string fileFromFullPath = testsDirFullPath + "\\TestFileName.txt";
            string fileToFullPath = testsDirFullPath + "\\TestFileNameCopied.txt";
            bool copied = IIG.FileWorker.BaseFileWorker.TryCopy(fileFromFullPath, fileToFullPath, true);
            Assert.True(copied, "Not copied");
        }
        [Fact]
        public void TestTryCopyRewriteNotAllow()
        {
            string fileFromFullPath = testsDirFullPath + "\\TestFileName.txt";
            string fileToFullPath = testsDirFullPath + "\\TestFileNameCopied.txt";
            try
            {
                bool copied = IIG.FileWorker.BaseFileWorker.TryCopy(fileFromFullPath, fileToFullPath, false);
            }
            catch (IOException e)
            {
                bool alreadyExist = e.Message.Contains("already exists");
                Assert.True(alreadyExist);
            }
        }
        [Fact]
        public void TestTryWrite()
        {
            string fileWrittenFullPath = testsDirFullPath + "\\TestFileTryWritten.txt";
            string data = "some data provided";
            bool written = IIG.FileWorker.BaseFileWorker.TryWrite(data, fileWrittenFullPath);
            Assert.True(written, "Not written");
        }
        [Fact]
        public void TestWrite()
        {
            string fileWrittenFullPath = testsDirFullPath + "\\TestFileWritten.txt";
            string data = "some data provided";
            bool written = IIG.FileWorker.BaseFileWorker.Write(data, fileWrittenFullPath);
            Assert.True(written, "Not written");
        }
    }
}
