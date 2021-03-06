﻿using UnityEngine;
using System.Collections;

public class ObjectDisappearance : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = GetComponent<Renderer>().material.color;
        float alpha = color.a;
        color.a = Mathf.Lerp(alpha, 0, 0.01f);
        GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, color.a);
        GetComponent<BoxCollider>().enabled = false;
		this.GetComponent<GameObject> ().SetActive (false);
    }
}
