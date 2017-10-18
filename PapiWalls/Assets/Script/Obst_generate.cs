using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obst_generate : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >=12f && Generate.obs_genrate == false) {
			Generate.obs_genrate = true;
			Destroy (this.gameObject);
		}
	}
}
