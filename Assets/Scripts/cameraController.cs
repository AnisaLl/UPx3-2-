using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public float rotateTime = 1.0f;

    private bool _isTweening = false;
    private bool _isRotating = false;
    //private DisablePlayer _disablePlayer;
    private GameObject crystal;
    private Vector3 tCamerPos;
    // trigger altitude
    private float tTriggerAltitude = 30.0f;

    // Use this for initialization
    void Start()
    {
        crystal = GameObject.FindGameObjectWithTag("crystal");
        gameObject.transform.position = new Vector3(crystal.transform.position.x, -10, crystal.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // camera's local position
        tCamerPos = gameObject.transform.localPosition;
       
        if (tCamerPos.y < tTriggerAltitude && _isRotating == false) {
            gameObject.transform.Translate(0, Time.deltaTime * 1.0f,0);
        }

        

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _isRotating = true;
            rotateTween(120);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _isRotating = true;
            rotateTween(-120);
        }

    }

    private void rotateTween(float amount)
    {
        if (_isTweening == false)
        {
            _isTweening = true;
            //_disablePlayer.disable();
            Vector3 rot = new Vector3(0, amount, 0);
            iTween.RotateAdd(gameObject, iTween.Hash(iT.RotateAdd.time, rotateTime, iT.RotateAdd.amount, rot, iT.RotateAdd.easetype, iTween.EaseType.easeInOutSine, iT.RotateAdd.oncomplete, "onColorTweenComplete"));
        }
    }

    private void onColorTweenComplete()
    {
        _isTweening = false;
        _isRotating = false;
        //_disablePlayer.enable();
    }

}
