using UnityEngine;
using System.Collections;

public class planeController : MonoBehaviour {
    // camera speed
    public float cameraSpeed = 0.8f;

    private Vector3 tCamerPos;
    // trigger altitude
    public float tTriggerAltitude = 30.0f;

    //game over controll
    private GameOver Isgameover;
    // Use this for initialization
    void Start () {
        Isgameover = GameObject.FindGameObjectWithTag("plane").GetComponent<GameOver>();
    }
	
	// Update is called once per frame
	void Update () {

        // camera's local position
        tCamerPos = gameObject.transform.localPosition;

        if (tCamerPos.y < tTriggerAltitude && !Isgameover.IsGameOver())
        {
            gameObject.transform.Translate(0, Time.deltaTime * cameraSpeed, 0);
        }

    }
}
