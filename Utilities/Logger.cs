namespace ResourceBroker.Utilities
{
    public class Logger
    {
        private const string LogFilePath = "mainlogs.txt";

        public static async Task Log(string message)
        {
            try
            {
                var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";

                await File.AppendAllTextAsync(LogFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
