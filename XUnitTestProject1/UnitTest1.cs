using System;
using System.IO;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        static readonly string workingDirectory = Environment.CurrentDirectory;
        private readonly string testsDirFullPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\dir-for-tests";

        [Fact]
        public void TestGetFileName()
        {
            string fileNameExpected = "TestFile.txt";
            string fileFullPath = testsDirFullPath + "\\" + fileNameExpected;
            string fileNameReal =  IIG.FileWorker.BaseFileWorker.GetFileName(fileFullPath);
          
            Assert.Equal(fileNameExpected, fileNameReal);
        }
        [Fact]
        public void TestGetFullPath()
        {
            string fullPathExpected = testsDirFullPath+ "\\TestFile.txt";
            string localPath = new Uri(fullPathExpected).LocalPath;
            string fullPathReal = IIG.FileWorker.BaseFileWorker.GetFullPath(localPath);
            Assert.Equal(fullPathExpected, fullPathReal);
        }
        [Fact]
        public void TestGetPath()
        {
            string fullFilePathExpected = testsDirFullPath+ "\\TestFile.txt";
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
            string fullPathExpected = testsDirFullPath+ "\\TestFile.txt";
            string contentExpected = "1\r\n2";
            string contentReal = IIG.FileWorker.BaseFileWorker.ReadAll(fullPathExpected);
            Assert.Equal(contentExpected, contentReal);
        }
        [Fact]
        public void TestReadLines()
        {
            string fileFullPath = testsDirFullPath+ "\\TestFile.txt";
            string[] linesExpected = { "1", "2" };
            string[] lines = IIG.FileWorker.BaseFileWorker.ReadLines(fileFullPath);
            Assert.Equal(linesExpected, lines);
        }

        [Fact]
        public void TestTryCopyRewriteAllow()
        {
            string fileFromFullPath = testsDirFullPath + "\\TestFile.txt";
            string fileToFullPath = testsDirFullPath + "\\TestFileCopied.txt";
            bool copied = IIG.FileWorker.BaseFileWorker.TryCopy(fileFromFullPath, fileToFullPath, true);
            Assert.True(copied, "Not copied");
        }
        [Fact]
        public void TestTryCopyRewriteNotAllow()
        {
            string fileFromFullPath = testsDirFullPath + "\\TestFile.txt";
            string fileToFullPath = testsDirFullPath + "\\TestFileCopied.txt";
            bool copied = IIG.FileWorker.BaseFileWorker.TryCopy(fileFromFullPath, fileToFullPath, false);
            Assert.False(copied);
        }
        [Fact]
        public void TestTryWrite()
        {
            string fileWrittenFullPath = testsDirFullPath + "\\TestFileTryWritten.txt";
            string data = "some data here";
            bool written = IIG.FileWorker.BaseFileWorker.TryWrite(data, fileWrittenFullPath);
            Assert.True(written, "Not written");
        }
        [Fact]
        public void TestWrite()
        {
            string fileWrittenFullPath = testsDirFullPath + "\\TestFileWritten.txt";
            string data = "some data here";
            bool written = IIG.FileWorker.BaseFileWorker.Write(data, fileWrittenFullPath);
            Assert.True(written, "Not written");
        }
    }
}
