using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public event Action StartGame;

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private Button startGameButton;

    [SerializeField] private GameObject loseUI;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void StartGameButtonPressed()
    {
        startGameButton.gameObject.SetActive(false);
        StartGame.Invoke();
    }

    public void LoseUIActivation()
    {
        loseUI.SetActive(true);
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButtonPressed()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void ChangeTimerText(float value)
    {
        string minutes = ((int)(value) / 60).ToString("00");
        string seconds = ((int)(value) % 60).ToString(":00");
        string milliseconds = ((int)(value * 1000f) % 1000 / 10).ToString(":00");

        timerText.text = minutes + seconds + milliseconds;
    }
}
