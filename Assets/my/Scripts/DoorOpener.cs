using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;
using Cinemachine;

public class DoorOpener : MonoBehaviour
{
    private bool _inDoorOpenerTrigger;
    [SerializeField] private GameObject _player;
    private Vector3 _nextPlayerRotation = new Vector3(0, 180, 0);
    private Vector3 _nextPlayerPosition = new Vector3(9.24800014f, 2.48900008f, -8.09599972f);
    private bool _isPosMoved;
    private bool _isRotMoved;
    [SerializeField] private PlayableDirector _runTimeline;
    private bool _timeLinePlayed;
    private bool _isLerp = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_inDoorOpenerTrigger == true && _isLerp == true && _timeLinePlayed == false)
        {  
            _player.GetComponent<CharacterController>().enabled = false;
            _player.GetComponent<AddAnimationAndMoving>().enabled = false;
            _player.transform.DOMove(_nextPlayerPosition, 1);
            _player.transform.DORotate(_nextPlayerRotation, 1);
            _isPosMoved = true;
            _isRotMoved = true;
            _isLerp = false;
        }
        ThirdLevelCutScene();
    }
    public void ThirdLevelCutScene()
    {
        if (_isPosMoved == true && _isRotMoved == true)
        {
            _runTimeline.Play();
            _timeLinePlayed = true;
            _isPosMoved = false;
            _isRotMoved = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _inDoorOpenerTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _inDoorOpenerTrigger = false;
    }
    public void NewCameraPosThirdRoom(CinemachineFreeLook Freelook)
    {
        Freelook.transform.localPosition = new Vector3(1.52600002f, 1.55799997f, -11.8129997f);
    }
    public void SwitchOn()
    {
        _player.GetComponent<CharacterController>().enabled = true;
        _player.GetComponent<AddAnimationAndMoving>().enabled = true;
    }
}
