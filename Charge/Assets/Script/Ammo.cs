using UnityEngine;
using UnityEngine.InputSystem;

public class Ammo : MonoBehaviour
{
    Ammo myself;
    [SerializeField] private InputActionReference _hold;
    [SerializeField] bool isHold = false;
    [SerializeField] bool isRemove = false;
    [SerializeField] bool isReload = false;
    private float power;
    Rigidbody rb;
    private void Awake()
    {
        if (_hold == null) return;

        _hold.action.performed += OnHold;

        _hold.action.canceled += OffHold;

        _hold.action.Enable();

        power = 0;

        myself = GetComponent<Ammo>();

        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isHold)
        {
            power += 0.01f;
            Debug.Log(power);
        }

        else if(isRemove)
        {
            Debug.Log("����!");
            isRemove = false;
            rb.AddForce(-power, power/3, 0, ForceMode.Impulse);
            power = 0;
        }

        if (isReload)
        {
            this.rb.constraints = RigidbodyConstraints.FreezeRotationX;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            this.rb.constraints = RigidbodyConstraints.FreezeAll;
            myself.enabled = false;
        }
    }

    private void OnHold(InputAction.CallbackContext context)
    {
        isHold = true;
    }

    private void OffHold(InputAction.CallbackContext context)
    {
        isHold = false;
        isRemove = true;
    }
}
