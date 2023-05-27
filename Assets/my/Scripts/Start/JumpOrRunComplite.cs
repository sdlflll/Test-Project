using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;

public class JumpOrRunComplite : MonoBehaviour
{
    [SerializeField] private GameObject _sizer;
    [SerializeField] private GameObject _player;
    private Vector3 _playerPosition;
    private Vector3 _playerRotation;
    private Vector3 _nextPlayerRotation = new Vector3(0, 0, 0);
    private Vector3 _nextPlayerPosition = new Vector3(4.5f, 0.91f, 3.1f);
    private bool _inTrigger = false;
    private float _fillerSupport = 1;
    private float _filler = 0;
    private float _fillerEnd;
    private bool _isPosMoved;
    private bool _isRotMoved;
    [SerializeField] private PlayableDirector _jumpTimeline;
    [SerializeField] private PlayableDirector _runTimeline;
    private bool _timeLinePlayed;
    private bool _isLerp;
    private bool _getRun;
    private bool _getJump;
    private SecondLocatiobScan _jumpOrRun;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _getRun = _jumpOrRun._getRun;
        _getJump = _jumpOrRun._getJump;
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
        else if (_fillerEnd >= 0.1f)
        {
            foreach (var scan in GameObject.FindGameObjectsWithTag("Complite"))
            {
               scan.SetActive(false);

            }
        }
        JumpCutScenePlay();


    }
    public void SwitchOn()
    {
        _player.GetComponent<CharacterController>().enabled = true;
        _player.GetComponent<AddAnimationAndMoving>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        _inTrigger = true;
        foreach (var scan in GameObject.FindGameObjectsWithTag("Complite"))
        {
            if (scan.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                spriteRenderer.enabled = true;

            }
            else if (scan.TryGetComponent(out MeshRenderer MeshRenderer))
            {
                MeshRenderer.enabled = true;

            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        _inTrigger = false;
        foreach (var scan in GameObject.FindGameObjectsWithTag("Complite"))
        {
            if (scan.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                spriteRenderer.enabled = false;

            }
            else if (scan.TryGetComponent(out MeshRenderer MeshRenderer))
            {
                MeshRenderer.enabled = false;

            }

        }
        _sizer.transform.localScale = new Vector3(0, 0, 0);
        _fillerEnd = 0;
        _filler = 0;
        _fillerSupport = 1;
    }
    public void JumpCutScenePlay()
    {
        if (_isPosMoved == true && _isRotMoved == true && _getRun == true)
        {
            _jumpTimeline.Play();
            _timeLinePlayed = true;
            _isPosMoved = false;
            _isRotMoved = false;
        }
    }
    public void RunCutScenePlay()
    {
        if (_isPosMoved == true && _isRotMoved == true && _getJump == true)
        {
            _runTimeline.Play();
            _timeLinePlayed = true;
            _isPosMoved = false;
            _isRotMoved = false;
        }
    }
}
