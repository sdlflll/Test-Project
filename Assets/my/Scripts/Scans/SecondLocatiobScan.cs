using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLocatiobScan : MonoBehaviour
{
    [SerializeField] private GameObject _runSizer;
    [SerializeField] private GameObject _jumpSizer;
    [SerializeField] private GameObject _triggerForRunAndJump;
    private float _fillerSupport = 1;
    private float _filler = 0;
     private float _filler2 = 0;
    [SerializeField] private Scan _scan;
    private bool _toScaner;
    private bool _scaned = false;
    private bool _getElements;
    private bool _onQ;
    private bool _onE;
    public bool _getRun;
    public bool _getJump;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _toScaner = _scan.ScanActive;
        if (_toScaner == true &&_scaned == false)
        {
            _getElements = false;
            if (_getElements == false)
            {
                GetScan2ElementsEnebledTrue();
                _getElements = true;
            }
           
            ToRun();
            ToJump();
     

        }
        else
        {
            GetScan2ElementsEnebledFalse();
            _getElements = true;
        }
 
    }

    private void ToRun()
    {
        if (Input.GetKey(KeyCode.E) && _filler < 0.1f)
        {
            _onE = true;
            _filler += _fillerSupport * Time.deltaTime;
            _runSizer.transform.localScale = new Vector3(_filler, _filler, _filler);
        }
        else if (_filler >= 0.1f)
        {
            _getElements = false;
            _getRun = true;
            _triggerForRunAndJump.SetActive(true);
            if (_getElements == false)
            {
                foreach (var scan in GameObject.FindGameObjectsWithTag("Scan2"))
                {
                    if (scan.TryGetComponent(out SpriteRenderer spriteRenderer))
                    {
                        spriteRenderer.enabled = false;

                    }
                    else if (scan.TryGetComponent(out MeshRenderer MeshRenderer))
                    {
                        MeshRenderer.enabled = false;

                    }

                    _getElements = true;
                }
            }
        }
        else
        {
            _filler = 0.00f;
            _runSizer.transform.localScale = new Vector3(0, 0, 0);
        }
    }
    private void ToJump()
    {
        if (Input.GetKey(KeyCode.Q) && _filler2 < 0.1f)
        {
            _onQ = true;
            _filler2 += _fillerSupport * Time.deltaTime;
            _jumpSizer.transform.localScale = new Vector3(_filler2, _filler2, _filler2);
        }
        else if (_filler2 >= 0.1f)
        {
            _getElements = false;
            _getJump = true;
            _triggerForRunAndJump.SetActive(true);
            if (_getElements == false)
            {
                foreach (var scan in GameObject.FindGameObjectsWithTag("Scan2"))
                {
                    if (scan.TryGetComponent(out SpriteRenderer spriteRenderer))
                    {
                        spriteRenderer.enabled = false;

                    }
                    else if (scan.TryGetComponent(out MeshRenderer MeshRenderer))
                    {
                        MeshRenderer.enabled = false;

                    }

                    _getElements = true;
                }
            }
        }
        else
        {
            _filler2 = 0.00f;
            _jumpSizer.transform.localScale = new Vector3(0, 0, 0);
        }
    }
    private void GetScan2ElementsEnebledTrue()
    {
        foreach (var scan in GameObject.FindGameObjectsWithTag("Scan2"))
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
    private void GetScan2ElementsEnebledFalse()
    {
        foreach (var scan in GameObject.FindGameObjectsWithTag("Scan2"))
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
} 
