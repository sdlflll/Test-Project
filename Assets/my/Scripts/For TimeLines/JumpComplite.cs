using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class JumpComplite : MonoBehaviour
{
    [SerializeField] private GameObject _sizerJump;
    [SerializeField] private PlayableDirector _endJumpTL;
    [SerializeField] private PlayableDirector _startJumpTL;
    [SerializeField] private GameObject Player;
    private float _fillerJump;
    private float _fillerEnd;
    private float _fillerSupport = 1;
    public bool jumpComplite;
    public bool _startTimer;
    private float _timer;
    public bool _lerp;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_startTimer == true)
        {
            if (Input.GetKey(KeyCode.E) && _fillerEnd <= 0.09f && _lerp == false)
            {
                _fillerJump += _fillerSupport * Time.deltaTime;
                _fillerEnd = _fillerJump * 1.5f;
                _sizerJump.transform.localScale = new Vector3(_fillerEnd, _fillerEnd, _fillerEnd);
            }
            else if (_fillerEnd >= 0.09f)
            {
                jumpComplite = true;
                _lerp = true;
                _startTimer = false;
            }
        }
    }
    public void SlowTime()
    {
        _startTimer = true;
        Time.timeScale = 0.1f;   
    }
    public void NormalTime()
    {
        if (jumpComplite == true)
        {
            Time.timeScale = 1f;
        }
        else if (jumpComplite == false)
        {
            Time.timeScale = 1f;
            _startJumpTL.Stop();
            Player.transform.position = new Vector3(5.30831718f, 2.43799996f, -5.10698938f);
            _endJumpTL.Play();
        }
    
    }
}
