using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] int score = 0;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = $"Score:{score}";
    }

    public void Plus() { score++; }
}
