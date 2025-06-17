using UnityEngine;
using UnityEngine.InputSystem;

public class Ammo : MonoBehaviour
{
    TargetSpawn targetSpawn;
    Ammo myself;
    ScoreText scoreText;
    Target target;
    SoundManager soundManager;
    [SerializeField] private InputActionReference _hold;
    [SerializeField] bool _isStart = false;
    [SerializeField] bool _isHold = false;
    [SerializeField] bool _isRemove = false;
    [SerializeField] bool _isReload = false;
    private float _power;
    public float _sendPower;
    Rigidbody rb;
    Transform _targetTransform;
    Vector3 _distance = new Vector3(0,0,0);
    private void Awake()
    {
        //InputSystem���̗p
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
        soundManager = GameObject.FindAnyObjectByType<SoundManager>();

        _targetTransform = target.transform;
    }
    private void Update()
    {
        //�^�[�Q�b�g�Ƃ̋������v�Z
        _distance.x = Mathf.Abs(this.transform.position.x - _targetTransform.position.x);
        _distance.y = Mathf.Abs(this.transform.position.y - _targetTransform.position.y);
        _distance.z = Mathf.Abs(this.transform.position.z - _targetTransform.position.z);

        //�쐬�����e�̏c��]���N����Ȃ��悤�ɒ�~
        if (_isReload){ this.rb.constraints = RigidbodyConstraints.FreezeRotationX; }

        //�^�[�Q�b�g�ɓ����������������Ŕ���
        if (_distance.x <= 0.6 && _distance.y < 1.05) 
        {
            soundManager.Clear();
            myself.enabled = false;
            targetSpawn.TargetHit();
            scoreText.Plus();
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
        //�^�[�Q�b�g�������炸���ɗ����邩�A�����ɍs���Ă��܂����Ƃ��ɏ���
        else if (this.transform.position.y <= 0 || this.transform.position.x <= -50)
        {
            soundManager.Miss();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_isHold)
        {
            _power += 0.5f;
            _sendPower = _power;
        }
        else if (_isRemove)
        {
            _isRemove = false;
            rb.AddForce(-_power, _power / 3, 0, ForceMode.Impulse);
            _power = 0;
        }

        //�p���[�̏�������߂邱�Ƃ�AddForce�ł̋������ςɂȂ�Ȃ��悤�ɂ���
        if (_power >= 50) 
        { 
            _power = 50;
            _isHold = false;
        }
    }


    private void OnHold(InputAction.CallbackContext context)
    {
        _isHold = true;
        if (_isStart){ soundManager.Charge(); }
    }

    private void OffHold(InputAction.CallbackContext context)
    {
        _isHold = false;
        _isRemove = true;
        if (_isStart){ soundManager.Shot(); }
    }
    public void StartGame() {_isStart = true ;}
    public void FinishGame() { _isStart = false; }
}
