using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddAnimationAndMoving : MonoBehaviour
{


    //переменные 
    //поля анимации
    //   [SerializeField] private float _moveAnimationSwitcher = 0;

    private Animator _animator;

    private Vector2 _animDirection;

    private bool _itRun;     

    private Camera _camera;
    //поворот
    [SerializeField] private float _speedRot = 300;

    //движение

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
        _animator = GetComponent<Animator>();
        _cc = GetComponent<CharacterController>();
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandlerInput();
        HandlerAnimator();
        OnTurn();
        Moving();

    }

    private void HandlerInput () // handler = обработчик
    {
        _animDirection.x = Input.GetAxis("Horizontal");

        _animDirection.y = Input.GetAxis("Vertical");

        //наполняем данными поле moveDirection для ходьбы, RAW для того, чтобы было ровно 0 или 1

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
            _nowSpeed = 0.45f;

        }
        else { 
            _nowSpeed = 0.45f;
        }
        if (_moveDirection.magnitude == 0){
            _nowSpeed = 0;
        }
        Vector3 targetDirection = Quaternion.Euler(0, -_targetRotation, 0) * Vector3.forward * _nowSpeed;

        _cc.Move(targetDirection * Time.deltaTime);

    }
}
