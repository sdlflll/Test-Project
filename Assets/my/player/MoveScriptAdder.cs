using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptAdder : MonoBehaviour
{
    private AddAnimationAndMoving _moving;
    void Start()
    {
        _moving = GetComponent<AddAnimationAndMoving>();
    }

    // Update is called once per frame
    public void EnableMoving()
    {
        _moving.enabled = true;
    }
}
