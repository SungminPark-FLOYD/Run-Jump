using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    //private GameObject pattern01;
    private PatternController patternController;

    private readonly float scoreScale = 20; //점수 증가 계수
    
    //플레이어 점수
    public float currentScore { private set; get; } = 0;

    public bool IsGamePlay { private set; get; } = false;

    public void GameStart()
    {
        uiController.GameStart();

        //pattern01.SetActive(true);
        patternController.GameStart();

        IsGamePlay = true;
    }

    public void GameOver()
    {
        uiController.GameOver();

        //pattern01.SetActive(false);
        patternController.GameOver();

        IsGamePlay = false;
    }


    public void GameExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void GamePause()
    {
        uiController.PauseMenu();

        IsGamePlay=false;

    }
    private void Update()
    {
        if (IsGamePlay == false) return;

        currentScore += Time.deltaTime * scoreScale;
    }


}
