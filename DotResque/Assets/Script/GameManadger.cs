using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManadger : MonoBehaviour
{
    public static GameManadger Instance;

    public void Awake () {
        if(Instance == null) {
            Instance = this;
            Init ();
            DontDestroyOnLoad (gameObject);
            return;
        }
        else {
            Destroy (gameObject);
        }
    }

    private string highscoreKey = "HighScore";
    
    public int HighScore {
        get {
            return PlayerPrefs.GetInt (highscoreKey, 0);
        }
        set {
            PlayerPrefs.SetInt (highscoreKey, value);
        }
    }

    public int CurrentScore { get; set; }
    public bool IsInitialized { get; set; }

    private void Init() {
        CurrentScore = 0;
        IsInitialized = false;
    }

    private const string MainMenu = "MainMenu";
    private const string Game = "Game";

    public void GoToMainMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene (MainMenu);
    }
    public void GoToGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene (Game);
    }
}
