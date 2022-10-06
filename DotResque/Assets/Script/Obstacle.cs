using UnityEngine;

public class Obstacle : MonoBehaviour {

    private  float currentRotationSpeed;
    public float minRotationSpeed, maxRotationSpeed;

    private float rotateTime;
    public float minRotationTime, maxRotationTime;
    private float currentRotationTime;

    public static bool obstacleRotate = true;


    public void Awake () {
        obstacleRotate = true;
        SetValues ();
    }

    public void Update () {

        if(obstacleRotate) {
            currentRotationTime += Time.deltaTime;
            if(currentRotationTime > rotateTime) {
                SetValues ();
            }
        }
        
    }

    public void SetValues() {

        currentRotationTime = 0f;
        currentRotationSpeed = minRotationSpeed + ( maxRotationSpeed - minRotationSpeed ) * 0.1f * Random.Range (0, 11);
        rotateTime = minRotationTime + ( maxRotationTime - minRotationTime ) * 0.1f * Random.Range (0, 11); // random rotation time
        currentRotationSpeed *= Random.Range (0, 2) == 0 ? 1f : -1f;
    }

    public void FixedUpdate () {
        if(obstacleRotate) {
            transform.Rotate (0, 0, currentRotationSpeed * Time.fixedDeltaTime);

        }
    }
}
