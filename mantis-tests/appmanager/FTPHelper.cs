using System.IO;
using System.Net;
using System.Net.FtpClient;

namespace mantis_tests
{
    public class FTPHelper : HelperBase
    {
        private FtpClient _client;

        public FTPHelper(ApplicationManager manager) : base(manager)
        {
            _client = new FtpClient {Credentials = new NetworkCredential("mantis", "mantis"), Host = "localhost"};
            _client.Connect();
        }

        public void BackUpFile(string path)
        {
            var backUpPath = path + ".bak";
            if (_client.FileExists(backUpPath))
            {
                return;
            }

            _client.Rename(path, backUpPath);
        }

        public void UploadFile(string path, Stream localfile)
        {
            if (_client.FileExists(path))
            {
                _client.DeleteFile(path);
            }

            using (Stream ftpStream = _client.OpenWrite(path))
            {
                var buffer = new byte[8 * 1024];
                var count = localfile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localfile.Read(buffer, 0, buffer.Length);
                }
            }
        }

        public void RestoreBackUpFile(string path)
        {
            var backUpPath = path + ".bak";
            if (!_client.FileExists(backUpPath))
            {
                return;
            }

            if (!_client.FileExists(path))
            {
                _client.DeleteFile(path);
            }

            _client.Rename(backUpPath, path);
        }
    }
}