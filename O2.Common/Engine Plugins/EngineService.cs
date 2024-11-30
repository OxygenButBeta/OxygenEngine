namespace O2Common.EnginePlugins;

public static class EngineService {
    public static T RaiseService<T>(CancellationToken token) where T : IAsyncEngineService<T> {
        return Activator.CreateInstance<T>().RaiseService(token);
    }
}