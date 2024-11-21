namespace OxygenEngine.Common.Engine_Plugins;

public static class EngineService {
    public static T RaiseService<T>(CancellationToken token) where T : AsyncEngineService<T> {
        return Activator.CreateInstance<T>().RaiseService(token);
    }
}