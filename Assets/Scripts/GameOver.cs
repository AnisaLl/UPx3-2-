using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    //bool seen = false;
    bool gameOver = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      
    }

    void OnTriggerEnter(Collider collider)
    {
        if (gameOver == false)
        {
            if (collider.tag == "blue" || collider.tag == "red" || collider.tag == "green")
            {
                Debug.Log("Game over");
                gameOver = true;
            }
        }
    }
}
