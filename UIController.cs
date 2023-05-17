
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [Header("Main UI")]
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private TextMeshProUGUI textMainGrade;

    [Header("Game UI")]
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private TextMeshProUGUI textScore;
    [SerializeField]
    private TextMeshProUGUI roundNumber;
    
    [Header("Result UI")]
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private TextMeshProUGUI textResultScore;
    [SerializeField]
    private TextMeshProUGUI textResultGrade;
    [SerializeField]
    private TextMeshProUGUI textResultHighScore;

    [Header("Pause UI")]
    [SerializeField]
    private GameObject pausePanel;

    public static bool GameIsPause = false;

    [Header("Result UI Animation")]
    [SerializeField]
    private ScaleEffect effectGameOver;
    [SerializeField]
    private CountingEffect effectResultScore;
    [SerializeField]
    private FadeEffect effectResultGrade;

    private void Awake()
    {
        // 처음 씬이 시작되어 Main UI가 활성화 상태일 때 최고 등급 불러오기
        textMainGrade.text = PlayerPrefs.GetString("HIGHGRADE");
    }

    public void GameStart()
    {
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void GameOver()
    {
        int currentScore = (int)gameController.currentScore;

        // 현재 점수 출력
        textResultScore.text = currentScore.ToString();
        // 현재 등급 출력, 현재 등급에 해당하는 고박사의 대사 출력
        CalculateGradeAndTalk(currentScore);
        // 최고 점수 출력
        CalculateHighScore(currentScore);

        gamePanel.SetActive(false);
        resultPanel.SetActive(true);

        //게임오버 텍스트 크기 축소 애니메이션
        effectGameOver.Play(500, 200);
        //현재 점수를 0 부터 카운팅하는 애니메이션
        //카운팅 애니메이션 종료 후 등급 FadeIn 애니메이션 재생
        effectResultScore.Play(0, currentScore, effectResultGrade.FadeIn);
    }
    public void GoToMainMenu()
    {
        // 플레이어 위치, 점수, 체력 등 초기화할 게 많기 때문에 그냥 현재씬을 다시 로드..
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;
        }
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    private void Update()
    {
        textScore.text = gameController.currentScore.ToString("F0");


        PauseMenu();
    }
    
    private void CalculateGradeAndTalk(int score)
    {
        if (score < 2000)
        {
            textResultGrade.text = "F";          
        }
        else if (score < 3000)
        {
            textResultGrade.text = "D";                
        }
        else if (score < 4000)
        {
            textResultGrade.text = "C";
            
        }
        else if (score < 5000)
        {
            textResultGrade.text = "B";
        }
        else
        {
            textResultGrade.text = "A";
        }
    }

    private void CalculateHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");

        // 최고 점수보다 높은 점수를 획득했을 때
        if (score > highScore)
        {
            // 최고 등급 갱신
            PlayerPrefs.SetString("HIGHGRADE", textResultGrade.text);
            // 최고 점수 갱신
            PlayerPrefs.SetInt("HIGHSCORE", score);

            textResultHighScore.text = score.ToString();
        }
        else
        {
            textResultHighScore.text = highScore.ToString();
        }
    }
    
}
