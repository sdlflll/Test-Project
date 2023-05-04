using UnityEngine;

public class FirstTriggerForOpenVintilation : MonoBehaviour
{
    [SerializeField] private GameObject _sizer;
    [SerializeField] private GameObject _player;
    public RuntimeAnimatorController DoorKickAnimation;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private Quaternion _nextPlayerRotation = new Quaternion(0f, 0f, 0f,  0f);
    [SerializeField] private Vector3 _nextPlayerPosition = new Vector3(4.5f, 0.995105624f, 3.1f);
    private bool _inTrigger = false;
    public float FillerSupport = 1; 
    public float filler = 0;
    public float fillerEnd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && _inTrigger == fillerEnd < 0.1) {

            filler += FillerSupport * Time.deltaTime;

            fillerEnd = filler / 20;

            _sizer.transform.localScale = new Vector3(fillerEnd, fillerEnd, fillerEnd);

            if (fillerEnd >= 0.1f)
            {
                Quaternion rotationQuaternionPlayer = _player.transform.rotation;
                _player.transform.position = Vector3.Lerp(_player.transform.position, _nextPlayerPosition, 5);
                _player.transform.rotation = Quaternion.Lerp(rotationQuaternionPlayer, _nextPlayerRotation, 5);

            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _inTrigger = false;
    }
}
