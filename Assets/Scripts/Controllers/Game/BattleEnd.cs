using System;

public class BattleEnd : IDisposable {
    private readonly IBattleController battleController;
    private readonly IContext context;
    private readonly RestartGame restartGame;

    public BattleEnd(IBattleController battleController, IContext context, RestartGame restartGame) {
        this.battleController = battleController;
        this.context = context;
        this.restartGame = restartGame;

        battleController.OnLose += LoseAction;
        battleController.OnWin += WinAction;
    }

    private void WinAction() {
        var winPopup = context.UIController.GetPopup<WinPopup>();
        winPopup.OnRestart += Restart;
        winPopup.Render();

        void Restart() {
            restartGame.Restart();
            winPopup.OnRestart -= Restart;
        }
    }

    private void LoseAction() {
        var losePopup = context.UIController.GetPopup<LosePopup>();
        losePopup.OnRestart += Restart;
        losePopup.Render();

        void Restart() {
            restartGame.Restart();
            losePopup.OnRestart -= Restart;
        }
    }

    public void Dispose() {
        battleController.OnLose -= LoseAction;
        battleController.OnWin -= WinAction;
    }
}
