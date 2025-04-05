using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text powerText;
    [SerializeField] int score = 0;
    Ammo ammo;
    float power;
    void Start()
    {
    }

    void Update()
    {
        text.text = $"Score:{score}";
        powerText.text = $"Power:{power}";
    }

    public void Plus() { score++; }
    public void Reload() 
    {
        ammo = GameObject.FindAnyObjectByType<Ammo>();
        power = 0;
    }
    public void Shot() { power = ammo.sendPowerText; }
}
