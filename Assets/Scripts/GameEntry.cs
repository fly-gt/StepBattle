using UnityEngine;

public class GameEntry : MonoBehaviour {
    [SerializeField] private GameController gameController;
    [SerializeField] private UIController uIController;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private InputController inputController;

    private void Start() {
        var factory = new FactoryService();
        var gameRoom = new FakeGameRoomService();
        var raycast = new RaycastManager();

        var context = new Context(factory, gameRoom, uIController, cameraController, raycast, inputController);

        uIController.Initialize(context);

        gameController.Initialize(context);
        gameController.Render();
    }
}
