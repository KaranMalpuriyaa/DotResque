using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    public GamePlayManager gm;
    [SerializeField] GameObject deathEffect;

    public AudioClip moveclip, loseClip;

    public void Update () {
        if(Input.GetMouseButtonDown(0)) {
            SoundManager.Instance.PlaySound (moveclip);
            rotationSpeed *= -1f;
        }
    }

    public void FixedUpdate () {
        transform.Rotate (0, 0, rotationSpeed * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if(other.gameObject.CompareTag("Obstacle")) {
            // gameOver
            Obstacle.obstacleRotate = false;
            gm.GameEnded ();
            GameObject newdeathEffect = Instantiate (deathEffect, transform.GetChild(0).position, Quaternion.identity);
            Debug.Log ("GameOver");
            SoundManager.Instance.PlaySound (loseClip);
            Destroy (gameObject);
            Destroy (newdeathEffect, 3f);
        }
    }
}
