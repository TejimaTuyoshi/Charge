using UnityEngine;

public class StartPanel : MonoBehaviour
{
    void Start()
    {
        Pause();
    }

    public void Play(){ Time.timeScale = 1.0f; }

    public void Pause(){ Time.timeScale = 0.0f; }
}