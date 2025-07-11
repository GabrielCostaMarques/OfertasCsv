using OfertasCsv.Infrasctructure.Connection;
using Renci.SshNet;

namespace OfertasCsv.Reader
{
    public class SFTPFileReader
    {
        public Stream ReadFile(string path, SftpClient connection)
        {
            
            return connection.OpenRead(path);
        }
    }
}
