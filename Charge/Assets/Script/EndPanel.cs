using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] Text score;
    void Start()
    {
        text.transform.position = new Vector2 (540,500);
        score.fontSize = 200;
    }

    public void Restart() { SceneManager.LoadScene("SampleScene", LoadSceneMode.Single); }
}
