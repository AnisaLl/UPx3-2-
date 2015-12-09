using UnityEngine;
using System.Collections;

public class AnimCameraController : MonoBehaviour {

    Animator anim;                          // Reference to the animator component.
    //game over controll
    private GameOver Isgameover;
    GameObject Animacamera;

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        Animacamera = gameObject.GetComponent<GameObject>();
    }

    // Use this for initialization
    void Start()
    {
        Isgameover = GameObject.FindGameObjectWithTag("plane").GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update () {

        if (Isgameover.IsGameOver())
        {
            anim.SetTrigger("gameover");
        }
        	
	}

    void OnMouseDown()
    {
        Animacamera.SetActive(false);
    }
}
