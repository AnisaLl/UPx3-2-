using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startMenuController : MonoBehaviour {
     
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showPanel_option(GameObject panel)
    {     
        panel.SetActive(!panel.activeSelf);
    }

    public void LoadScene(int level)
    {
        //loadingImage.SetActive(true);
        //Application.LoadLevel(level);
    }
}
