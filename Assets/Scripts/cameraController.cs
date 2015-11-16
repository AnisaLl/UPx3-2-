using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public float rotateTime = 1.0f;

    private bool _isTweening = false;
    //private DisablePlayer _disablePlayer;
    private GameObject crystal;

    // Use this for initialization
    void Start()
    {
        crystal = GameObject.FindGameObjectWithTag("crystal");
        gameObject.transform.position = new Vector3(crystal.transform.position.x, 0, crystal.transform.position.z);
        gameObject.transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rotateTween(120);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
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
        //_disablePlayer.enable();
    }
}
