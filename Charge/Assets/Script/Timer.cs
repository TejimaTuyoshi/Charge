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

    public void AddTime(){ time += 5f; }//一定の得点に達した際に作動する

    public void ST(){ isStart = true; }

    void StopSound(){ soundManager.mute = true; }

}
