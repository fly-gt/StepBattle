public interface IContext {
    public IFactoryService FactoryService { get; }
    public IGameRoomService GameRoomService { get; }
    public IUIController UIController { get; }
    public ICameraController CameraController { get; }
    public IRaycastManager RaycastManager { get; }
    public IInputController InputController { get; }
}

public class Context : IContext {
    public IFactoryService FactoryService { get; }
    public IGameRoomService GameRoomService { get; }
    public IUIController UIController { get; }
    public ICameraController CameraController { get; }
    public IRaycastManager RaycastManager { get; }
    public IInputController InputController { get; }

    public Context(IFactoryService factoryService, IGameRoomService gameRoomService, IUIController uIController, ICameraController cameraController,
        IRaycastManager raycastManager, IInputController inputController) {
        FactoryService = factoryService;
        GameRoomService = gameRoomService;
        UIController = uIController;
        CameraController = cameraController;
        RaycastManager = raycastManager;
        InputController = inputController;
    }
}
