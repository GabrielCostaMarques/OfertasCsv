using Renci.SshNet;

namespace OfertasCsv.Infrasctructure.Connection
{
    public class ConnectionSFTP
    {
        private readonly string host = "sftp.azamara.com";
        private readonly string username = "R11";
        private readonly string pathKey = @"C:\Users\gmarques\Desktop\r11sshkey";

        public SftpClient Connection()
        {
            PrivateKeyFile privateKeyFile = new(pathKey);
            var client = new SftpClient(host, username, privateKeyFile);

            try
            {
                client.Connect();

                if (client.IsConnected)
                {
                    Console.WriteLine("Connected Server!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return client;
        }
    }
}
