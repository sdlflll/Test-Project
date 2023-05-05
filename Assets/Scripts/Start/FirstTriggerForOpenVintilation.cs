using UnityEngine;
using UnityEngine.Playables;

public class FirstTriggerForOpenVintilation : MonoBehaviour
{
    [SerializeField] private GameObject _border;
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _sizer;
    [SerializeField] private GameObject _player;
    private Vector3 _playerPosition;
    private Vector3 _playerRotation;
    private Vector3 _nextPlayerRotation = new Vector3(0, 0, 0 );
    private Vector3 _nextPlayerPosition = new Vector3(4.5f, 0.91f, 3.1f);
    private bool _inTrigger = false;
    public float FillerSupport = 1; 
    public float filler = 0;
    public float fillerEnd;
    public bool _isPosMoved;
     public bool _isRotMoved;
    [SerializeField] private PlayableDirector _doorTimeline;
    public bool _timeLinePlayed;
    public bool _isLerp;

    void Start()
    {
        _border.SetActive(false);
        _sizer.SetActive(false);
        _text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && _inTrigger == true && fillerEnd < 0.1)
        {

            filler += FillerSupport * Time.deltaTime;

            fillerEnd = filler / 20;

            _sizer.transform.localScale = new Vector3(fillerEnd, fillerEnd, fillerEnd);

            _isLerp = true;
        }

        else if (fillerEnd >= 0.1f && _isLerp == true)
        {
            Quaternion rotationQuaternionPlayer = _player.transform.rotation;
            _playerRotation = rotationQuaternionPlayer.eulerAngles;
            _playerPosition = _player.transform.position;
            _player.GetComponent<CharacterController>().enabled = false;
            _player.GetComponent<AddAnimationAndMoving>().enabled = false;
            _player.transform.localEulerAngles = Vector3.Lerp(_playerRotation, _nextPlayerRotation, 500);
            _player.transform.localPosition = Vector3.Lerp(_playerPosition, _nextPlayerPosition, 500);
            _isPosMoved = true;
            _isRotMoved = true;

            _isLerp = false;
        }
        else if(fillerEnd >= 0.1f)
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
        fillerEnd = 0;
        filler = 0;
        FillerSupport = 1;
    }
}
