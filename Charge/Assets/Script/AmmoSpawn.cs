using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum InstanceAmmos
{
    Simple,
    Light,
    Heavy
}
public class AmmoSpawn : MonoBehaviour
{
    [SerializeField] private InputActionReference _reload;
    [SerializeField] InstanceAmmos ammos;
    [SerializeField] GameObject simpleAmmo;
    [SerializeField] GameObject lightAmmo;
    [SerializeField] GameObject heavyAmmo;
    [SerializeField] Text typeText;
    [SerializeField] bool isReload = false;
    [SerializeField] bool isReady = false;

    private void Awake()
    {
        if (_reload == null) return;

        _reload.action.performed += OnReload;

        _reload.action.canceled += OffReload;

        _reload.action.Enable();
    }
    private void Update()
    {
        typeText.text = $"NextType:{ammos}";
        if (isReload)
        {
            if (ammos == InstanceAmmos.Simple){ Instantiate(simpleAmmo, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity); }
            else if (ammos == InstanceAmmos.Light) { Instantiate(lightAmmo, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity); }
            else if (ammos == InstanceAmmos.Heavy) { Instantiate(heavyAmmo, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity); }
            isReload = false;
            var random = new System.Random();
            var num = random.Next(00, 03);
            if (num == 0) { ammos = InstanceAmmos.Simple; }
            else if (num == 1) { ammos = InstanceAmmos.Light; }
            if (num == 2) { ammos = InstanceAmmos.Heavy; }
        }
    }

    private void OnReload(InputAction.CallbackContext context)
    {
    }
    private void OffReload(InputAction.CallbackContext context)
    {
        if (isReady)
        {
            isReload = true;
            isReady = false;
        }
    }
    public void Ready() { isReady = true; }
}
