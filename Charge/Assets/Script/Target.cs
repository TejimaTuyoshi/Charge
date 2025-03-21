using UnityEngine;

public class Target : MonoBehaviour
{
    ScoreText scoreText;
    TargetSpawn targetSpawn;
    void Start()
    {
        scoreText = GameObject.FindAnyObjectByType<ScoreText>();
        targetSpawn = GameObject.FindAnyObjectByType<TargetSpawn>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            targetSpawn.TargetHit();
            scoreText.Plus();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
