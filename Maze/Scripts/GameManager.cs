using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform player;
    public Transform endPoint;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public float levelMaxTime = 100f; // 5 minutes

    private float timeSpent;
    private bool gameWon = false;
    private bool gameLost = false;
    private int levelScore = 0;
    public int scoreIncrementPerSecond = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        StartGame();
    }
    void Update()
    {
        if (!gameWon && !gameLost)
        {
            if (Time.timeScale != 0)
            {
                timeSpent += Time.deltaTime;
                UpdateTimeText();

                // Increment score based on time spent
                levelScore = Mathf.CeilToInt(timeSpent * scoreIncrementPerSecond);

                // Update score text
                UpdateScoreText();

                if (timeSpent > levelMaxTime)
                {
                    EndGame(false);
                }
                else if (Vector3.Distance(player.position, endPoint.position) < 10f) // Adjust the distance threshold as needed
                {
                    EndGame(true);
                }
            }
        }
    }

    void UpdateTimeText()
    {
        timeText.text = "Time: " +Mathf.CeilToInt(levelMaxTime - timeSpent).ToString();
        
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.CeilToInt(levelScore).ToString();
    }
    public void ApplyPenalty(int seconds)
    {
        levelScore -= seconds;
    }

    public void EndGame(bool won)
    {
        gameWon = won;
        gameLost = !won;
        Time.timeScale = 0;
        float finalScore = Mathf.Max(0, levelMaxTime - timeSpent) * levelScore;

        if (won)
        {
            UIManager.Instance.GameWin();
        }
        else
        {
            UIManager.Instance.gameover();
        }
    }

    public void StartGame()
    {
        timeSpent = 0;
        levelScore = 0;
        gameWon = false;
        gameLost = false;
        Time.timeScale = 1;
        UpdateTimeText(); // Ensure the UI is updated at the start
        UpdateScoreText();
    }

}
