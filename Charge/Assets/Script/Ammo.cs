using UnityEngine;
using UnityEngine.InputSystem;

public class Ammo : MonoBehaviour
{
    TargetSpawn targetSpawn;
    Ammo myself;
    ScoreText scoreText;
    Target target;
    [SerializeField] private InputActionReference _hold;
    [SerializeField] bool _isHold = false;
    [SerializeField] bool _isRemove = false;
    [SerializeField] bool _isReload = false;
    private float _power;
    public float _sendPowerText;
    Rigidbody rb;
    Transform _targetTransform;
    Vector3 _distance = new Vector3(0,0,0);
    private void Awake()
    {
        if (_hold == null) return;

        _hold.action.performed += OnHold;

        _hold.action.canceled += OffHold;

        _hold.action.Enable();

        _power = 0;

        myself = GetComponent<Ammo>();

        rb = GetComponent<Rigidbody>();

        scoreText = GameObject.FindAnyObjectByType<ScoreText>();

        target = GameObject.FindAnyObjectByType<Target>();

        targetSpawn = GameObject.FindAnyObjectByType<TargetSpawn>();

        _targetTransform = target.transform;
    }
    private void Update()
    {
        Debug.Log($"{_distance}");
        _distance.x = Mathf.Abs(this.transform.position.x - _targetTransform.position.x);
        _distance.y = Mathf.Abs(this.transform.position.y - _targetTransform.position.y);
        _distance.z = Mathf.Abs(this.transform.position.z - _targetTransform.position.z);
        if (_isHold)
        {
            _power += 0.01f;
            _sendPowerText = _power;
        }

        else if(_isRemove)
        {
            _isRemove = false;
            rb.AddForce(-_power, _power/3, 0, ForceMode.Impulse);
            _power = 0;
        }

        if (_isReload)
        {
            this.rb.constraints = RigidbodyConstraints.FreezeRotationX;
        }

        if (_distance.x <= 0.6 && _distance.y < 1.05) 
        {
            this.rb.constraints = RigidbodyConstraints.FreezeAll;
            myself.enabled = false;
            targetSpawn.TargetHit();
            scoreText.Plus();
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
        else if (this.transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnHold(InputAction.CallbackContext context)
    {
        _isHold = true;
    }

    private void OffHold(InputAction.CallbackContext context)
    {
        _isHold = false;
        _isRemove = true;
    }
}
