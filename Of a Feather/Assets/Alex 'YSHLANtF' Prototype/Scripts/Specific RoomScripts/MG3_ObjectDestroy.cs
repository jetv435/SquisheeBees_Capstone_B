﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG3_ObjectDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		gameObject.SetActive (false);
	}
}
