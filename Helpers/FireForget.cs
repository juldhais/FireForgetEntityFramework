namespace FireForgetEntityFramework.Helpers;

public sealed class FireForget
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public FireForget(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    
    public void Execute<TService>(Func<TService, Task> func)
    {
        Task.Run(async () =>
        {
            try
            {
                var context = _serviceScopeFactory.CreateScope().ServiceProvider.GetService<TService>();
                await func(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
    }
}