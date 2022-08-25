using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI gameOverHighScoreText;
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] GameObject counter;
    [SerializeField] GameObject gameStartScreen;
    [SerializeField] GameObject gameOverScreen;
    bool startTimer = false;
    float timer = 3f;
    private void Awake()
    {
        GameManager.onScoreChanged.AddListener(ScoreChanged);        
        GameManager.onGameOver.AddListener(GameOver);
        ShowHighscore();
    }
    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            ShowTimer(timer);
        }
        if (timer <= 0 && startTimer)
        {
            startTimer = false;
            counter.SetActive(false);
            GameStart();
        }
    }
    public void ScoreChanged()
    {
        scoreText.text = "Score: " + GameManager.score;        
    }
    private void ShowHighscore()
    {
        highScoreText.text = "Highscore: " + GameManager.LoadHighScore();
    }
    public void GameStartButtonPressed()
    {
        gameStartScreen.SetActive(false);
        counter.SetActive(true);
        startTimer = true;        
    }    
    public void GameStart()
    {
        GameManager.SendGameStart();
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverHighScoreText.text = "Highscore: " + GameManager.highScore;
    }
    public void Restart()
    {
        GameManager.score = 0;
        SceneManager.LoadScene(0);
    }
    void ShowTimer(float timer)
    {
        counterText.text = timer.ToString("#");
    }
}
