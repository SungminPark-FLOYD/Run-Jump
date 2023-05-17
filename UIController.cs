
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
        // ó�� ���� ���۵Ǿ� Main UI�� Ȱ��ȭ ������ �� �ְ� ��� �ҷ�����
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

        // ���� ���� ���
        textResultScore.text = currentScore.ToString();
        // ���� ��� ���, ���� ��޿� �ش��ϴ� ��ڻ��� ��� ���
        CalculateGradeAndTalk(currentScore);
        // �ְ� ���� ���
        CalculateHighScore(currentScore);

        gamePanel.SetActive(false);
        resultPanel.SetActive(true);

        //���ӿ��� �ؽ�Ʈ ũ�� ��� �ִϸ��̼�
        effectGameOver.Play(500, 200);
        //���� ������ 0 ���� ī�����ϴ� �ִϸ��̼�
        //ī���� �ִϸ��̼� ���� �� ��� FadeIn �ִϸ��̼� ���
        effectResultScore.Play(0, currentScore, effectResultGrade.FadeIn);
    }
    public void GoToMainMenu()
    {
        // �÷��̾� ��ġ, ����, ü�� �� �ʱ�ȭ�� �� ���� ������ �׳� ������� �ٽ� �ε�..
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

        // �ְ� �������� ���� ������ ȹ������ ��
        if (score > highScore)
        {
            // �ְ� ��� ����
            PlayerPrefs.SetString("HIGHGRADE", textResultGrade.text);
            // �ְ� ���� ����
            PlayerPrefs.SetInt("HIGHSCORE", score);

            textResultHighScore.text = score.ToString();
        }
        else
        {
            textResultHighScore.text = highScore.ToString();
        }
    }
    
}
