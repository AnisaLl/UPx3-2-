using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public float rotateTime = 1.0f;

    private bool _isTweening = false;
    //private DisablePlayer _disablePlayer;
    private GameObject crystal;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;

    // Use this for initialization
    void Start()
    {
        crystal = GameObject.FindGameObjectWithTag("crystal");
        gameObject.transform.position = new Vector3(crystal.transform.position.x, 0, crystal.transform.position.z);
        gameObject.transform.rotation = Quaternion.identity;
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        player3 = GameObject.Find("player3");
        player1.GetComponent<Char1Controller>().enabled = false;
        player2.GetComponent<Char2Controller>().enabled = false;
        player3.GetComponent<Char3Controller>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rotateTween(120);
            if (GameObject.Find("worldCenter").transform.rotation.y > -20 && GameObject.Find("worldCenter").transform.rotation.y < 20)
            {
                player1.GetComponent<Char1Controller>().enabled = false;
                player2.GetComponent<Char2Controller>().enabled = false;
                player3.GetComponent<Char3Controller>().enabled = true;
            }
            if (GameObject.Find("worldCenter").transform.rotation.y > 100 && GameObject.Find("worldCenter").transform.rotation.y < 140)
            {
                player1.GetComponent<Char1Controller>().enabled = false;
                player2.GetComponent<Char2Controller>().enabled = true;
                player3.GetComponent<Char3Controller>().enabled = false;
            }
            if (GameObject.Find("worldCenter").transform.rotation.y > 220 && GameObject.Find("worldCenter").transform.rotation.y < 260)
            {
                player1.GetComponent<Char1Controller>().enabled = true;
                player2.GetComponent<Char2Controller>().enabled = false;
                player3.GetComponent<Char3Controller>().enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            rotateTween(-120);
            if (GameObject.Find("worldCenter").transform.rotation.y > -20 && GameObject.Find("worldCenter").transform.rotation.y < 20)
            {
                player1.GetComponent<Char1Controller>().enabled = false;
                player2.GetComponent<Char2Controller>().enabled = false;
                player3.GetComponent<Char3Controller>().enabled = true;
            }
            if (GameObject.Find("worldCenter").transform.rotation.y > 100 && GameObject.Find("worldCenter").transform.rotation.y < 140)
            {
                player1.GetComponent<Char1Controller>().enabled = false;
                player2.GetComponent<Char2Controller>().enabled = true;
                player3.GetComponent<Char3Controller>().enabled = false;
            }
            if (GameObject.Find("worldCenter").transform.rotation.y > 220 && GameObject.Find("worldCenter").transform.rotation.y < 260)
            {
                player1.GetComponent<Char1Controller>().enabled = true;
                player2.GetComponent<Char2Controller>().enabled = false;
                player3.GetComponent<Char3Controller>().enabled = false;
            }
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
