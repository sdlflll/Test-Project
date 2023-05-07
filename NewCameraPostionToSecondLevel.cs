using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraPostionToSecondLevel : CameraPositionMenegment
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private Vector3 _newCameraPositionToSecondLevel;
    public override void SetNewCameraPosition(Vector3 NewCameraPosition, GameObject Camera)
    {
        NewCameraPosition = _newCameraPositionToSecondLevel;
        Camera = _camera;
        Camera.transform.position = NewCameraPosition;
    }
}
