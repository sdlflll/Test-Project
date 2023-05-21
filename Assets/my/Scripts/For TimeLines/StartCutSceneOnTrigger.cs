using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
public class StartCutSceneOnTrigger : MonoBehaviour
{
    [SerializeField] private bool _animationPlayed = true;
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _playerRotation;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private Vector3 _nextPlayerPosition;
    [SerializeField] private Vector3 _nextPlayerRotation;
    [SerializeField] private bool _isPosMoved;
    [SerializeField] private bool _isRotMoved;
    [SerializeField] private PlayableDirector _timeline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_animationPlayed == false)
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
            if (_isPosMoved == true && _isRotMoved == true)
            {
                _timeline.Play();
                _animationPlayed = true;
                _isPosMoved = false;
                _isRotMoved = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        _animationPlayed = false;
        print("ах ах ты вошел в триггер");
    }
    public void SwitchOn()
    {
        _player.GetComponent<CharacterController>().enabled = true;
        _player.GetComponent<AddAnimationAndMoving>().enabled = true;
        GameObject.Destroy(gameObject);
    }
    public void SetActive (GameObject SetActive)
    {
        SetActive.SetActive(true);
    }
    public void SetFalse(GameObject SetActive)
    {
        SetActive.SetActive(false);
    }
}


