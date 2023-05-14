using UnityEngine;

public class ToCamera : MonoBehaviour

{
    private Camera CameraTrans;
    // Start is called before the first frame update
    void Start()
    {
        CameraTrans = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(CameraTrans.transform);
    }
}
