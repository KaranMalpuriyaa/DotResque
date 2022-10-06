using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private float score;
    private float scoreSpeed;
    private int currentLevel;

    [SerializeField] private List<int> levelSpeed, levelMax;

    private bool hasGameFinished;

    public void Awake () {

        GameManadger.Instance.IsInitialized = true;
        score = 0;
        currentLevel = 0;
        scoreText.text = ( (int) score ).ToString ();
        scoreSpeed = levelSpeed[currentLevel];
    }

    public void Update () {
        if(hasGameFinished)
            return;

        score += scoreSpeed * Time.deltaTime;
        scoreText.text = ( (int) score ).ToString ();

        if(score > levelMax[Mathf.Clamp(currentLevel, 0, levelMax.Count -1)]) {
            currentLevel = Mathf.Clamp(currentLevel + 1, 0, levelMax.Count - 1);
            scoreSpeed = levelSpeed[currentLevel];
        }
    }

    public void GameEnded() {
        hasGameFinished = true;
        GameManadger.Instance.CurrentScore = (int) score;
        StartCoroutine (GameOver ());

    }
    private IEnumerator GameOver() {
        yield return new WaitForSeconds (2f);
        GameManadger.Instance.GoToMainMenu ();
    }



}
