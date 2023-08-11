namespace EjemploServicioDotNET
{
    public class Worker : BackgroundService
    {     
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            MyHTTPServer myHTTPServer = new();
            while (!stoppingToken.IsCancellationRequested)
            {                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}