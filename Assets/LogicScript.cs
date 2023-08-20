using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int score;
    bool isPaused = false;

    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject pauseGamePanel;

    MyInputAction myInputAction;

    [ContextMenu("Add Score")]
    public void AddScore(int addScore = 1)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }

    public void quiteGame()
    {
        Application.Quit();
    }

    public void gamerOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void restart()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void restartPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (gameOverPanel.activeSelf)
        {
            restart();
        }
        else
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            // Resume game
            Time.timeScale = 1;
            pauseGamePanel.SetActive(false);
        }
        else
        {
            // Pause game
            Time.timeScale = 0;
            pauseGamePanel.SetActive(true);
        }

        isPaused = !isPaused;
    }

    private void Awake()
    {
        myInputAction = new MyInputAction();
    }

    private void OnEnable()
    {
        myInputAction.Enable();

        myInputAction.UI.Restart.performed += restartPerformed;
    }

    private void OnDispose()
    {
        myInputAction.Dispose();
    }
}
