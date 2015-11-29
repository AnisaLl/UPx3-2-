using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour
{
    public string colliderName;
    public string playerName;
    public triggerController particle_blue;

    // Use this for initialization
    void Start()
    {
        
     
    }

    // Update is called once per frame
    void Update()
    {
    }


    //REMEMBER
    //Both objects have to have a collider
    //One of them has to be rigidbody. in this case I have made rigidbody the box since the player cannot be both rigidbody and character controller
    //The object with which the object is colliding has to have "Is Trigger" checked. In this case it doesn't act like a collider. Jsyk
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.tag);
        if (collider.tag == playerName)
        {
            //Debug.Log("Entered here");
            if (GameObject.FindGameObjectWithTag(colliderName) != null)
            {
                particle_blue.Display();
                GameObject.FindGameObjectWithTag(colliderName).GetComponent<ObjectDisappearance>().enabled = true;
                StartCoroutine(MyCoroutine());
            }
        }
    }


    //I delay the destruction of the object by 1 second so that it can firslty fade out and then it will be destroyed
    IEnumerator MyCoroutine()
    {
        //This is a coroutine
        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindGameObjectWithTag(colliderName));
        yield return new WaitForSeconds(1);
    }
}
