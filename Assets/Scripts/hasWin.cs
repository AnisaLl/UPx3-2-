using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnitySampleAssets.Characters.ThirdPerson;

public class hasWin : MonoBehaviour {

    public Canvas winCanvas;
    public Button win_mainmenu;
    Animator anim;
    GameObject Animacamera;
    private ThirdPersonUserControl ThirdPersonUserControl;

    // Use this for initialization
    void Start () {
        winCanvas.enabled = false;
        win_mainmenu.enabled = false;
        Animacamera = GameObject.Find("AnimCamera_over");
        Debug.Log(Animacamera);
        anim = Animacamera.GetComponent<Animator>();
        ThirdPersonUserControl = GameObject.FindGameObjectWithTag("blue").GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        Animacamera.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (ThirdPersonUserControl.hasWon == true)
        {
            Debug.Log("hasWon_anime");
            Animacamera.SetActive(true);
            anim.SetTrigger("gamewin");
            Invoke("showwinCanvas", 2.0f);
        }

    }

    void showwinCanvas()
    {
        winCanvas.enabled = true;
        win_mainmenu.enabled = true;
    }
}
