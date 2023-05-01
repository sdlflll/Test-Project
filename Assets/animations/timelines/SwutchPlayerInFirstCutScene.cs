using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwutchPlayerInFirstCutScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchOn ()
    {
        gameObject.SetActive(true);
    }
    public void SwitchOff()
    {
        gameObject.SetActive(false);
    }
}
