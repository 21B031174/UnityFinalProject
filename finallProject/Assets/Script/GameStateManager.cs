using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    Playing,
    Pause,
    GameOver
}


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    public GameObject MainMenuUI;
    public GameObject inGameMenuUI;
    public GameObject PauseMenuUI;
    public GameObject GameOverMenuUI;

    public int delay = 1;
    public GameState CurrentState { get; private set; }
    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start(){
        
        ChangeState(GameState.MainMenu);
    }

    public void ChangeState(GameState newState){
        // if(CurrentState == newState)return;
        StartCoroutine(TransitionToState(newState));
    }

    public void ChangeToMainMenu(){
        ChangeState(GameState. MainMenu);
    }
        
    public void ChangeToPlaying(){
        ChangeState(GameState.Playing);
    }
    
    public void ChangeToPause(){
        ChangeState(GameState. Pause);
    }
    
    public void ChangeToGameMenu(){
        ChangeState(GameState.GameOver);
    }
    
    private IEnumerator TransitionToState(GameState newState){
        if(newState != GameState.MainMenu)
            yield return new WaitForSecondsRealtime(delay);
        CurrentState = newState;
        HandleStateChange();
    }
    private void HandleStateChange()
    {
        HideAllMenu();
        switch (CurrentState){
            case GameState.MainMenu:
            Time.timeScale = 0;
            MainMenuUI.SetActive(true);
            AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
            case GameState.Playing:
            Time.timeScale = 1;
            inGameMenuUI.SetActive(true);
            AudioManager.instance.PlayMusic(AudioManager.instance.inGameMusic);
                break;
            case GameState.Pause:
            Time.timeScale = 0;
            PauseMenuUI.SetActive(true);
            AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
            case GameState.GameOver:
            Time.timeScale = 0;
            GameOverMenuUI.SetActive(true);
            AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
        }
    }

    private void HideAllMenu(){
        MainMenuUI.SetActive(false);
        inGameMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        GameOverMenuUI.SetActive(false);
    }
}
