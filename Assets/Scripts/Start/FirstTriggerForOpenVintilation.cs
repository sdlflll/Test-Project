using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;

public class FirstTriggerForOpenVintilation : MonoBehaviour
{
    [SerializeField] private AudioSource _audioForCutScene;
    [SerializeField] private GameObject _border;
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _sizer;
    [SerializeField] private GameObject _player;
    private Vector3 _playerPosition;
    private Vector3 _playerRotation;
    private Vector3 _nextPlayerRotation = new Vector3(0, 0, 0 );
    private Vector3 _nextPlayerPosition = new Vector3(4.5f, 0.91f, 3.1f);
    private bool _inTrigger = false;
    private float _fillerSupport = 1;
    private float _filler = 0;
    private float _fillerEnd;
    private bool _isPosMoved;
    private bool _isRotMoved;
    [SerializeField] private PlayableDirector _doorTimeline;
    private bool _timeLinePlayed;
    private bool _isLerp;
    private float _t;
    public bool ConfirmToVentilation;

    void Start()
    {
        _border.SetActive(false);
        _sizer.SetActive(false);
        _text.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && _inTrigger == true && _fillerEnd < 0.1)
        {

            _filler += _fillerSupport * Time.deltaTime;

            _fillerEnd = _filler / 20;

            _sizer.transform.localScale = new Vector3(_fillerEnd, _fillerEnd, _fillerEnd);

            _isLerp = true;
        }

        else if (_fillerEnd >= 0.1f && _isLerp == true)
        {
            Quaternion rotationQuaternionPlayer = _player.transform.rotation;
            _playerRotation = rotationQuaternionPlayer.eulerAngles;
            _playerPosition = _player.transform.position;
            _player.GetComponent<CharacterController>().enabled = false;
            _player.GetComponent<AddAnimationAndMoving>().enabled = false;
            _player.transform.DOMove(_nextPlayerPosition, 1);
            _player.transform.DORotate(_nextPlayerRotation, 1);
            _isPosMoved = true;
            _isRotMoved = true;

            _isLerp = false;
        }
        else if(_fillerEnd >= 0.1f)
        {
            _text.SetActive(false);
            _border.SetActive(false);
            _sizer.SetActive(false);
        }
        DoorCutScenePlay();

    }
    public void DoorCutScenePlay ()
    {
        if (_isPosMoved == true && _isRotMoved == true)
        {
            _doorTimeline.Play();
            _timeLinePlayed = true;
            _isPosMoved = false;
            _isRotMoved = false;
        }
    }
    public void DoorCutSceneEnd ()
    {
            _doorTimeline.Stop();
        ConfirmToVentilation = true;
    }
    public void SwitchOn()
    {
        _player.GetComponent<CharacterController>().enabled = true;
        _player.GetComponent<AddAnimationAndMoving>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        _inTrigger = true;
        _border.SetActive(true);
        _sizer.SetActive(true);
        _text.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        _inTrigger = false;
        _border.SetActive(false);
        _sizer.SetActive(false);
        _text.SetActive(false) ;
        _sizer.transform.localScale = new Vector3(0, 0, 0);
        _fillerEnd = 0;
        _filler = 0;
        _fillerSupport = 1;
    }
}

//Vector3(1.61800003,0.0500000007,1.4776839)
