using UnityEngine;
using UnityEngine.InputSystem;

public class AmmoSpawn : MonoBehaviour
{
    [SerializeField] private InputActionReference _reload;
    [SerializeField] GameObject ammo;
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
        if (isReload)
        {
            Instantiate(ammo, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            isReload = false;
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
