using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Timer timer;
    [SerializeField] Slider slider;
    [SerializeField] int score = 0;
    [SerializeField] int timeAddScore = 0;
    Ammo ammo;
    bool isReload = false;
    float power;
    void Start()
    {
    }

    void Update()
    {
        text.text = $"Score:{score}";
        slider.value = power;
        ammo = GameObject.FindAnyObjectByType<Ammo>();
        if (!ammo){ power = 0; }
        else { power = ammo._sendPower; }

        if (timeAddScore >= 5)
        {
            timer.Add();
            timeAddScore = 0;
        }
        if (isReload)
        {
            isReload = false;
        }
    }

    public void Plus() 
    {
        score++;
        timeAddScore++;
    }
    public void Reload() 
    {
        power = 0;
        isReload = true;
    }
}
