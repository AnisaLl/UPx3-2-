using UnityEngine;
using System.Collections;

public class toggleController : MonoBehaviour {

    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 100f);
    }
}
