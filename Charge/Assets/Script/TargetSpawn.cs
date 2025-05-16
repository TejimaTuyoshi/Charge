using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool isHit = false;
    [SerializeField] float num = 0f;
    void Update()
    {
        if (isHit)
        {
            Random();
            Instantiate(target, new Vector3(-num, 1, 0), Quaternion.Euler(0, 270, 0));
            isHit = false;
        }
    }

    void Random()
    {
        var random = new System.Random();
        num = random.Next(25, 41);
    }

    public void TargetHit() { isHit = true; }
}
