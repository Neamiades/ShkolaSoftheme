using System.IO;
using System.Text;
using static System.Console;

namespace ConsoleFileHandleApp
{
    static class FileHandler
    {
        private static FileInfo _fileInf;

        private static FileHandle? OpenForRead(string pathToFile)
        {
            FileHandle? fileHandle = null;
            _fileInf = new FileInfo(pathToFile);

            if (_fileInf.Exists)
            {
                fileHandle = new FileHandle
                {
                    FilePath = pathToFile,
                    FileAccess = FileAccessEnum.Read,
                    FileName = _fileInf.Name,
                    FileSize = _fileInf.Length
                };
            }
            return fileHandle;
        }

        private static FileHandle? OpenForWrite(string pathToFile)
        {
            _fileInf = new FileInfo(pathToFile);

            if (!_fileInf.Exists)
            {
                using (_fileInf.Create()) { }
                _fileInf = new FileInfo(pathToFile);
            }

            FileHandle? fileHandle = new FileHandle
            {
                FilePath = pathToFile,
                FileAccess = FileAccessEnum.Write,
                FileName = _fileInf.Name,
                FileSize = _fileInf.Length
            };
            
            return fileHandle;
        }

        private static FileHandle? OpenFile(string pathToFile, FileAccessEnum fileAccess)
        {
            _fileInf = new FileInfo(pathToFile);
            FileHandle? fileHandle = null;

            if (!_fileInf.Exists && fileAccess.HasFlag(FileAccess.Write))
            {
                _fileInf.Create();
            }
            if (_fileInf.Exists)
            {
                fileHandle = new FileHandle
                {
                    FilePath = pathToFile,
                    FileAccess = fileAccess,
                    FileName = _fileInf.Name,
                    FileSize = _fileInf.Length
                };
            }

            return fileHandle;
        }

        private static void ReadFile(string filePath)
        {
            WriteLine("Your file content:\n");

            using (var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] b = new byte[512];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    WriteLine(temp.GetString(b));
                }
            }
        }

        private static void WriteToFile(string filePath)
        {
            Write("Your text to write into the file:");
            var text = ReadLine();

            using (var fs = File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                if (text != null)
                {
                    byte[] array = Encoding.Default.GetBytes(text);
                    fs.Write(array, 0, array.Length);
                }
                WriteLine("Text writed into the files");
            }
        }

        private static void WriteReadFile(string filePath)
        {
            Write("Your text to write into the file:");
            var text = ReadLine();
            WriteLine("File before:\n");

            using (var fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    WriteLine(temp.GetString(b));
                }

                if (text != null)
                {
                    byte[] array = Encoding.Default.GetBytes(text);
                    fs.Write(array, 0, array.Length);
                    fs.Flush();
                }

                WriteLine("File after:\n");
                fs.Seek(0, SeekOrigin.Begin);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    WriteLine(temp.GetString(b));
                }

            }
        }

        public static FileHandle? GetFileHandle(string pathToFile, string fileAccess)
        {
            switch (fileAccess)
            {
                case "read":
                    return OpenForRead(pathToFile);
                case "write":
                    return OpenForWrite(pathToFile);
                case "readwrite":
                    return OpenFile(pathToFile, FileAccessEnum.ReadWrite);
                default:
                    return null;
            }
        }

        public static void MakeActionsWithFile(FileHandle? fileHandle)
        {
            if (fileHandle == null)
            {
                WriteLine("You made a mistake in the given file path or file mode, or I just can't do that, sorry");
                return;
            }

            switch (fileHandle.Value.FileAccess)
            {
                case FileAccessEnum.Read:
                    ReadFile(fileHandle.Value.FilePath);
                    break;

                case FileAccessEnum.Write:
                    WriteToFile(fileHandle.Value.FilePath);
                    break;

                case FileAccessEnum.ReadWrite:
                    WriteReadFile(fileHandle.Value.FilePath);
                    break;
            }
        }
    }
}
