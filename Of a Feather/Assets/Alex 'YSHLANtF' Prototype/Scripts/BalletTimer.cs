using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalletTimer : MonoBehaviour {


	public int timer = 0;
	public GameObject shoes;


	// Use this for initialization
	void Start () {
		shoes.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {

		timer--;
		Debug.Log (timer);
		if (timer <= 0) {

			shoes.SetActive (true);
			timer = 0;
		}
	}
}
