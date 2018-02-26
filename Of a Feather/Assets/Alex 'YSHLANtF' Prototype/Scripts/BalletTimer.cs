using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalletTimer : MonoBehaviour {


	public int timer = 0;
	public GameObject shoes;
	public GameObject bshoes;

	// Use this for initialization
	void Start () {
		shoes.SetActive (false);
		bshoes.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {

		timer--;
		Debug.Log (timer);
		if (timer <= 0) {

			shoes.SetActive (true);
			bshoes.SetActive (true);
			timer = 0;
		}
	}
}
