using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    private Transform _camera;
    private Transform _pivot;

    private Vector3 _localRotation;
    private float _cameraDistance = 15f;    // the same distance as the camera is offest from the pivot

    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public bool CameraDisabled = false;

    void Start()
    {
        _camera = this.transform;
        _pivot = this.transform.parent;
    }

    void Update()
    {
        // nb: need camera to render after scene is calculated (avoid cropping/clipping)

        if (Input.GetKeyDown(KeyCode.LeftShift))    // todo: feels like this is actually auto mode or not as we never want to release the mouse...
            CameraDisabled = !CameraDisabled;   

        // Only capture user input if camera enabled 
        if(!CameraDisabled)
        {
            //Rotation of the Camera based on Mouse Coordinates
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)  // todo: could overload with arrow and wsad keys?
            {
                _localRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _localRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                _localRotation.y = Mathf.Clamp(_localRotation.y, -75f, 90f);    // todo orginal code clamped at 0 to avoid clipping... we probably need to do this when moving the camera somehow...
            }

            //Zoom based on scroll wheel...
            if(Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                var scrollAmout = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                scrollAmout *= (this._cameraDistance * 0.3f);   // allows further away from object to increase zoom
                _cameraDistance += scrollAmout * -1f;

                _cameraDistance = Mathf.Clamp(_cameraDistance, 1.5f, 50f);
            }
        }

        // Move the camera
        var qt = Quaternion.Euler(_localRotation.y, _localRotation.x, 0);
        _pivot.rotation = Quaternion.Lerp(_pivot.rotation, qt, Time.deltaTime * OrbitDampening);

        if(_camera.localPosition.z != _cameraDistance * -1f)
            _camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(_camera.localPosition.z, _cameraDistance * -1f, Time.deltaTime * ScrollDampening));
        
    }
}
