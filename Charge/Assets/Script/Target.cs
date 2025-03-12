using UnityEngine;

public class Target : MonoBehaviour
{
    new BoxCollider collider;
    [SerializeField] new MeshRenderer renderer;
    ScoreText scoreText;

    void Start()
    {
        collider = GetComponent<BoxCollider>();
        scoreText = GameObject.FindAnyObjectByType<ScoreText>();
        renderer.material.color = Color.blue;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            renderer.material.color = Color.red;
            scoreText.Plus();
        }
    }
}
