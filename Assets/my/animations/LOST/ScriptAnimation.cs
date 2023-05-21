using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _playerPos = new Vector3(-0.425000012f, -0.528999984f, -1.41499996f);
    [SerializeField] private Vector3 _playerRot = new Vector3(0f, 0f, 0f);
    void Start()
    {
        Destroy(gameObject, 18f);
        Invoke("AddPlayer", 18f);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    void AddPlayer()
    {
        Instantiate(_player, _playerPos, Quaternion.Euler(_playerRot));
    }
} 
