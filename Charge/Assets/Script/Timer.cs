using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] AmmoSpawn ammoSpawn;
    [SerializeField] AudioSource soundManager;
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject fillParts;
    [SerializeField] Slider slider;
    [SerializeField] float time;
    [SerializeField] float startTime = 20f;
    [SerializeField] bool isStart = false;
    [SerializeField] bool isFinish = false;


    private void Awake()
    {
        time = startTime;
        slider.maxValue = startTime;
    }

    private void FixedUpdate()
    {
        slider.value = time;
        if (isStart) { time -= Time.deltaTime; }

        if (time <= 0)
        {
            isStart = false;
            time = 0;
            endPanel.SetActive(true);
            fillParts.SetActive(false);
            ammoSpawn.Finish();
            StopSound();
        }

    }

    public void Add(){ time += 5f; }

    public void ST(){ isStart = true; }

    void StopSound(){ soundManager.mute = true; }

}
