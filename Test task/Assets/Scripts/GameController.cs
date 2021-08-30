using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private enum GameState
    {
        Prepare,
        Play,
        End
    }

    private GameState gameState = GameState.Prepare;

    private float timer;
    public float Timer
    {
        get { return timer; }
        set 
        {
            timer = value;
            UIController.instance.ChangeTimerText(Timer);
        }
    }

    private void Start()
    {
        SetupGame();
    }

    private void SetupGame()
    {
        Time.timeScale = 0f;

        UIController.instance.StartGame += StartGame;
        playerController.EndGame += EndGame;

        Timer = 0f;
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        gameState = GameState.Play;
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        gameState = GameState.End;
        UIController.instance.LoseUIActivation();
    }

    private void Update()
    {
        if(gameState == GameState.Play)
        {
            Timer += Time.deltaTime;
        }
    }
}
