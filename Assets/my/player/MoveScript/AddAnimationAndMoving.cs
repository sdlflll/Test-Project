using UnityEngine;
public class AddAnimationAndMoving : MonoBehaviour
{
    //������
    //���������� 
    //���� ��������
    //   [SerializeField] private float _moveAnimationSwitcher = 0;

    [SerializeField] private Animator _animator;

    [SerializeField] private RuntimeAnimatorController _animation;
    [SerializeField] private Avatar _avatar;

    private Vector2 _animDirection;

    private bool _itRun;     

    private Camera _camera;
    //�������
    [SerializeField] private float _speedRot = 350;

    //��������

    [SerializeField] private float _speedWalk = 3;
    private float _nowSpeed = 3;                                                                                                                
    private Vector3 _moveDirection;                                                                                                                     
                                                                                       
    private CharacterController _cc;

  //  [SerializeField] private float _jumpHeight = 1;                                                                   

  //  private const float G = 9.81f;

    public float _targetRotation;

   // private bool _isJump;
    


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Animator>();
        gameObject.AddComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _cc = GetComponent<CharacterController>();
        _camera = Camera.main;
        Vector3 CharecterCenter = new Vector3(0, 0.88f, 0);
        float CharacterRadius = 0.23f;
        float HeightOfCharacter = 1.31f;

        _cc.center = CharecterCenter;
        _cc.radius = CharacterRadius;
        _cc.height = HeightOfCharacter;
        _animator.runtimeAnimatorController = _animation;
        _animator.avatar = _avatar;



    }

    // Update is called once per frame
    void Update()
    {
        HandlerInput();
        HandlerAnimator();
        OnTurn();
        Moving();

    }

    private void HandlerInput () // handler = ����������
    {
        _animDirection.x = Input.GetAxis("Horizontal");

        _animDirection.y = Input.GetAxis("Vertical");

        //��������� ������� ���� moveDirection ��� ������, RAW ��� ����, ����� ���� ����� 0 ��� 1

        _moveDirection.x = Input.GetAxisRaw("Horizontal");

        _moveDirection.y = Input.GetAxisRaw("Vertical");

        if (_animDirection.magnitude != 0) 
        {
            _itRun = Input.GetKey(KeyCode.LeftShift);
        }
        else
        {
            _itRun = false;
        }

    }

    private void HandlerAnimator() {

        _animator.SetFloat("y", Mathf.Clamp01(_animDirection.magnitude));

        _animator.SetBool("run", _itRun);
    }

    private void OnTurn ()
    {
        if (_moveDirection.magnitude == 0)
        {
            return;
        }

        _targetRotation = Mathf.Atan2(  -_moveDirection.x, -_moveDirection.y) * -Mathf.Rad2Deg;

        Vector3 rotaion = new Vector3(transform.eulerAngles.x, -_targetRotation, transform.eulerAngles.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(rotaion), Time.deltaTime * _speedRot);
    }

    private void Moving()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _nowSpeed = 0.75f;

        }
        else { 
            _nowSpeed = 0.75f;
        }
        if (_moveDirection.magnitude == 0){
            _nowSpeed = 0;
        }
        Vector3 targetDirection = Quaternion.Euler(0, -_targetRotation, 0) * Vector3.forward * _nowSpeed;

        _cc.Move(targetDirection * Time.deltaTime);

    }
}
