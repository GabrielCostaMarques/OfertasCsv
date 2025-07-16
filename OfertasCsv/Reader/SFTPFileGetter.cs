using Renci.SshNet;

namespace OfertasCsv.Reader
{
    public class SFTPFileReader
    {
        public Stream ReadFile(string path, SftpClient connection)
        {
            if (connection == null || !connection.IsConnected)
            {
                throw new InvalidOperationException("Connection is not established or is invalid.");
            }
            Console.WriteLine("Abrindo arquivos");
            return connection.OpenRead(path);
        }
    }
}
