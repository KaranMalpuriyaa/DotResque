using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text newbestScoreText;
    [SerializeField] private TMP_Text bestScoreText;

    [SerializeField] private float animationTime;
    [SerializeField] private AnimationCurve speedCurve;

    private void Awake () {
        bestScoreText.text = GameManadger.Instance.HighScore.ToString ();

        if(!GameManadger.Instance.IsInitialized) {
            scoreText.gameObject.SetActive (false);
            newbestScoreText.gameObject.SetActive (false);
        }
        else {
            StartCoroutine (ShowScore ());
        }
    }

    private IEnumerator ShowScore() {
        int tempScore = 0;
        scoreText.text = tempScore.ToString ();

        int currentScore = GameManadger.Instance.CurrentScore;
        int highScore = GameManadger.Instance.HighScore;

        if(highScore < currentScore) {
            newbestScoreText.gameObject.SetActive (true);
            GameManadger.Instance.HighScore = currentScore;
        }
        else {
            newbestScoreText.gameObject.SetActive (false);
        }

        bestScoreText.text = GameManadger.Instance.HighScore.ToString ();
        float speed = 1 / animationTime;
        float timeElapsed = 0f;

        while(timeElapsed < 1f) {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int) ( speedCurve.Evaluate (timeElapsed) * currentScore );
            scoreText.text = tempScore.ToString ();
            yield return null;
        }
        tempScore = currentScore;
        scoreText.text = tempScore.ToString ();

    }

    public void ClickToPlay() {
        GameManadger.Instance.GoToGame ();
    }

}
