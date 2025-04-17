using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] float time = 20f;
    [SerializeField] bool isStart = false;
    void Update()
    {
        Debug.Log($"{time}");
        text.text = $"Time:{time}";
        if (isStart) { time -= Time.deltaTime; }

        if (time <= 0) 
        {
            isStart = false;
            time = 0;
        }
    }

    public void Add(){ time += 5f; }

    public void ST(){ isStart = true; }

}
