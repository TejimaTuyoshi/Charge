using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Timer timer;
    [SerializeField] Text powerText;
    [SerializeField] int score = 0;
    [SerializeField] int timeAddScore = 0;
    Ammo ammo;
    float power;
    void Start()
    {
    }

    void Update()
    {
        text.text = $"Score:{score}";
        powerText.text = $"Power:{power}";
        if (timeAddScore >= 5)
        {
            timer.Add();
            timeAddScore = 0;
        }
    }

    public void Plus() 
    {
        score++;
        timeAddScore++;
    }
    public void Reload() 
    {
        ammo = GameObject.FindAnyObjectByType<Ammo>();
        power = 0;
    }
    public void Shot() { power = ammo.sendPowerText; }
}
