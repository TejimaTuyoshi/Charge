using UnityEngine;

public class Target : MonoBehaviour
{
    new BoxCollider collider;
    new MeshRenderer renderer;
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        renderer = GetComponent<MeshRenderer>();
        renderer.material.color = Color.blue;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            renderer.material.color = Color.red;
            collider.enabled = false;
        }
    }
}
