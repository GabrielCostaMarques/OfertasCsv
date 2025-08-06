using Renci.SshNet;

namespace OfertasCsv.Infrasctructure.Connection
{
    public class ConnectionSFTP
    {
        private readonly string host = Environment.GetEnvironmentVariable("SFTP_HOST") ?? "not host";
        private readonly string username = Environment.GetEnvironmentVariable("SFTP_USER") ??"not user"; 
        private readonly string pathKey = Environment.GetEnvironmentVariable("SFTP_PRIVATE_KEY")??"not pk";

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
                else
                {

                    throw new InvalidOperationException("Failed to connect to the server.");
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
