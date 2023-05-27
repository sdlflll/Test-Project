using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;

public class JumpOrRunComplite : MonoBehaviour
{
    [SerializeField] private GameObject _sizer;
    [SerializeField] private GameObject _player;
    private Vector3 _playerPosition;
    private Vector3 _playerRotation;
    private Vector3 _nextPlayerRotation = new Vector3(0, 90, 0);
    private Vector3 _nextPlayerPosition = new Vector3(3.30261803f, 2.43799996f, -5.07299995f);
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
    [SerializeField] private bool _getRun;
    [SerializeField] private bool _getJump;
    [SerializeField] private SecondLocatiobScan _jumpOrRun;
    private bool _getComponents;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _getRun = _jumpOrRun.getRun;
        _getJump = _jumpOrRun.getJump;
        if(_getJump == true || _getRun == true)
        {
            if(_getComponents == false)
            {
                print("условие");
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
                _getComponents = true;
            }
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

                _isLerp = false;
            }
            else if (_fillerEnd >= 0.1f)
            {
                foreach (var complite in GameObject.FindGameObjectsWithTag("Complite"))
                {
                    complite.SetActive(false);

                }
            }
        }
        else
        {
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
        }
        JumpCutScenePlay();
        RunCutScenePlay();
    }
    public void SwitchOn()
    {
        _player.GetComponent<CharacterController>().enabled = true;
        _player.GetComponent<AddAnimationAndMoving>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        _inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _inTrigger = false;
        _sizer.transform.localScale = new Vector3(0, 0, 0);
        _fillerEnd = 0;
        _filler = 0;
        _fillerSupport = 1;
    }
    public void RunCutScenePlay()
    {
        if (_isPosMoved == true && _isRotMoved == true && _getRun == true)
        {
            _runTimeline.Play();
            _timeLinePlayed = true;
            _isPosMoved = false;
            _isRotMoved = false;
        }
    }
    public void JumpCutScenePlay()
    {
        if (_isPosMoved == true && _isRotMoved == true && _getJump == true)
        {
            _jumpTimeline.Play();
            _timeLinePlayed = true;
            _isPosMoved = false;
            _isRotMoved = false;
        }
    }
    public void MovePlayerAfterCutScene()
    {
        _player.transform.position = new Vector3(1.31500006f, 2.43799996f, -5.07299995f);
    }
}
