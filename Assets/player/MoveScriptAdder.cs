using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptAdder : MonoBehaviour
{
    private AddAnimationAndMoving _moving;
    void Start()
    {
       
       StartCoroutine(AddScript(18));
    }

    private IEnumerator AddScript (float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.AddComponent<AddAnimationAndMoving>();
    }

    // pdate is called once per frame
}
