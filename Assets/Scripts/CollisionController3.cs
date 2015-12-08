using UnityEngine;
using System.Collections;

public class CollisionController3 : MonoBehaviour {

	public string colliderName;
	public string playerName;
	public triggerController particle_blue;
	private GameObject blockCollider;
	//public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake()
	{
		blockCollider = GameObject.FindGameObjectWithTag(colliderName);
		//GameObject.FindGameObjectWithTag(colliderName).SetActive(false);
	}

	void OnTriggerStay(Collider collider)
	{
		
		if (collider.tag == playerName)
		{
			//Debug.Log(collider.tag);
			//Resources.FindObjectsOfTypeAll<Transform?>
			//Debug.Log(GetComponent<Transform>().Find(colliderName).tag);
			if (blockCollider != null)
			{
				//Debug.Log("Entered here");
				//float step = speed*Time.deltaTime;
				//Invoke("Effect", 4.0f);
				//StartCoroutine(MyCoroutine());
				Effect();
				//StartCoroutine(MyCoroutine());
				gameObject.SetActive(false);
				//blockCollider.SetActive(true);
				//particle_blue.Display();
				//blockCollider.GetComponent<ObjectAppear>().enabled = true;
				//GameObject.FindGameObjectWithTag(colliderName).GetComponent<ObjectAppear>().enabled = true;
				// StartCoroutine(MyCoroutine());
			}
		}
	}

	void Effect()
	{
		blockCollider.transform.localPosition = Vector3.MoveTowards(blockCollider.transform.localPosition, new Vector3(0.07f, 1.53f, 0.72f), 0.2f);
	}

	IEnumerator MyCoroutine()
	{
		//This is a coroutine
		yield return new WaitForSeconds(2.0f);
	//	Effect ();
		yield return new WaitForSeconds(2.0f);
	}

	//void OnTriggerExit(Collider collider)
	//{
	//	if (collider.tag == playerName) {
	//		gameObject.SetActive(false);
	//	}
	//}
	
}
