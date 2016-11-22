using UnityEngine;
using System.Collections;

public class StormTrooperColision : MonoBehaviour {

	// Use this for initialization

	public static bool hit;

	void Start () {
		hit = false;
	}
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnTriggerEnter(Collider other) { 
		hit = true;
	}


}
