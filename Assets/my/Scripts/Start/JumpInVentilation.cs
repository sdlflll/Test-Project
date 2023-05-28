using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class JumpInVentilation : MonoBehaviour
{
    [SerializeField] private GameObject _border;
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _sizer;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _activateVentilationCheckText;
    private Vector3 _playerPosition;
    private Vector3 _playerRotation;
    private Vector3 _nextPlayerRotation = new Vector3(0, 180, 0);
    private Vector3 _nextPlayerPosition = new Vector3(1.85466897f, 0.908758759f, -0.532867908f);
    private bool _inTrigger = false;
    public float FillerSupport = 1;
    public float filler = 0;
    public float fillerEnd;
    public bool _isPosMoved;
    public bool _isRotMoved;
    [SerializeField] private PlayableDirector _ventelationTimeline;
    public bool _timeLinePlayed;
    public bool _isLerp;
    private float _t;
    private FirstTriggerForOpenVintilation _firstTriggerForOpenVintilation;
    public TextMeshProUGUI ActivateVentilationCheckTextColor;
    private float _transperent = 0;


    void Start()
    {
        _firstTriggerForOpenVintilation = FindObjectOfType<FirstTriggerForOpenVintilation>();
        _border.SetActive(false);
        _sizer.SetActive(false);
        _text.SetActive(false);
        ActivateVentilationCheckTextColor = ActivateVentilationCheckTextColor.GetComponent<TextMeshProUGUI>();
        ActivateVentilationCheckTextColor.color = new Color(0.6603774f, 0.6603774f, 0.6603774f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(_firstTriggerForOpenVintilation.ConfirmToVentilation == true)
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
                _player.transform.DOMove(_nextPlayerPosition, 1);
                _player.transform.DORotate(_nextPlayerRotation, 1);
                _isPosMoved = true;
                _isRotMoved = true;

                _isLerp = false;
            }
            else if (fillerEnd >= 0.1f)
            {
                _text.SetActive(false);
                _border.SetActive(false);
                _sizer.SetActive(false);
            }
            DoorCutScenePlay();
            if (_timeLinePlayed == true)
            {
                _activateVentilationCheckText.SetActive(true);
                float timeForTransperent = Time.deltaTime * 0.4f;
                _transperent += timeForTransperent;
                ActivateVentilationCheckTextColor.color = new Color(0.6603774f, 0.6603774f, 0.6603774f, _transperent);
            }
        }
        

    }
    public void DoorCutScenePlay()
    {
        if (_isPosMoved == true && _isRotMoved == true)
        {
            _ventelationTimeline.Play();
            _timeLinePlayed = true;
            _isPosMoved = false;
            _isRotMoved = false;
        }
    }
    public void DoorCutSceneEnd()
    {
        _ventelationTimeline.Stop();
    }
    public void SwitchOn()
    {
        _player.GetComponent<CharacterController>().enabled = true;
        _player.GetComponent<AddAnimationAndMoving>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_firstTriggerForOpenVintilation.ConfirmToVentilation == true)
        {
            _inTrigger = true;
            _border.SetActive(true);
            _sizer.SetActive(true);
            _text.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_firstTriggerForOpenVintilation.ConfirmToVentilation == true)
        {
            _inTrigger = false;
            _border.SetActive(false);
            _sizer.SetActive(false);
            _text.SetActive(false);
            _sizer.transform.localScale = new Vector3(0, 0, 0);
            fillerEnd = 0;
            filler = 0;
            FillerSupport = 1;
        }
    }
    public void NewCameraPositionAfterCutscene(CinemachineFreeLook FreeLook)
    {
        FreeLook.transform.localPosition = new Vector3(-5.26310015f, 0.887600005f, -6.24130011f);
    }
}
