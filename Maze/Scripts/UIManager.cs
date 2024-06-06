using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject restartBuuton;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinPanel;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gamewinText;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Maze");
    }

    public void pauseButon()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        restartBuuton.SetActive(true);
        resumeButton.SetActive(true);
    }

    public void resumeButon()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        restartBuuton.SetActive(false);
    }

    public void restartBton()
    {
        SceneManager.LoadScene("Maze");
    }

    public void gameover()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void GameWin()
    {
        gameWinPanel.SetActive(true);
        pauseButton.SetActive(false);
    }
}
