﻿using UnityEngine;
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
    // camera speed
    private float cameraSpeed = 0.8f;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private float worldCenterY;
   

    // Use this for initialization
    void Start()
    {
        crystal = GameObject.FindGameObjectWithTag("crystal");
        gameObject.transform.position = new Vector3(crystal.transform.position.x, -10, crystal.transform.position.z);
        gameObject.transform.rotation = Quaternion.identity;
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        player3 = GameObject.Find("player3");
        player1.GetComponent<Char1Controller>().enabled = false;
        player2.GetComponent<Char2Controller>().enabled = false;
        player3.GetComponent<Char3Controller>().enabled = true;
        worldCenterY = this.GetComponent<Transform>().eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {

        // camera's local position
        tCamerPos = gameObject.transform.localPosition;
       
        if (tCamerPos.y < tTriggerAltitude && _isRotating == false) {
            gameObject.transform.Translate(0, Time.deltaTime * cameraSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _isRotating = true;
            rotateTween(120);
            StartCoroutine(MyCoroutine());
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _isRotating = true;
            rotateTween(-120);
            StartCoroutine(MyCoroutine());
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

    IEnumerator MyCoroutine()
    {
        //This is a coroutine
        yield return new WaitForSeconds(1);

        worldCenterY = this.GetComponent<Transform>().eulerAngles.y;
        Debug.Log(worldCenterY);
        if (worldCenterY > -20.0f && worldCenterY < 20.0f)
        {
            player1.GetComponent<Char1Controller>().enabled = false;
            player2.GetComponent<Char2Controller>().enabled = false;
            player3.GetComponent<Char3Controller>().enabled = true;
        }
        if (worldCenterY > 340.0f && worldCenterY < 380.0f)
        {
            player1.GetComponent<Char1Controller>().enabled = false;
            player2.GetComponent<Char2Controller>().enabled = false;
            player3.GetComponent<Char3Controller>().enabled = true;
        }
        else if (worldCenterY > 100.0f && worldCenterY < 140.0f)
        {
            player1.GetComponent<Char1Controller>().enabled = false;
            player2.GetComponent<Char2Controller>().enabled = true;
            player3.GetComponent<Char3Controller>().enabled = false;
        }
        else if (worldCenterY > 220.0f && worldCenterY < 260.0f)
        {
            player1.GetComponent<Char1Controller>().enabled = true;
            player2.GetComponent<Char2Controller>().enabled = false;
            player3.GetComponent<Char3Controller>().enabled = false;
        }
        yield return new WaitForSeconds(1);
    }
}
