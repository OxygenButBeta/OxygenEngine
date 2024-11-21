namespace OxygenEngine.Common.Engine_Plugins;

public interface AsyncEngineService<T> {
    public T RaiseService(CancellationToken token);
}