using UnityEngine;
using System.Collections;
using UnitySampleAssets.Characters.ThirdPerson;

public class AnimCameraController : MonoBehaviour {

    Animator anim;                          // Reference to the animator component.
    //game over controll
    //private bool hasWon;
    GameObject Animacamera;

    void Awake()
    {
        Animacamera = GameObject.Find("AnimCamera");
        anim = Animacamera.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {


    }

    public void disableCamera()
    {
        if(Animacamera.active == true)
        {
            Animacamera.SetActive(false);
        }
        
    }

    //void OnMouseDown()
    //{
    //    Animacamera.SetActive(false);
    //}
}
