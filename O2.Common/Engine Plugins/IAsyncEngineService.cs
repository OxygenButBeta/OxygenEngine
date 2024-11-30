namespace O2Common.EnginePlugins;

public interface IAsyncEngineService<T>  :IEngineService{
    public T RaiseService(CancellationToken token);
}
public interface IEngineService {
}