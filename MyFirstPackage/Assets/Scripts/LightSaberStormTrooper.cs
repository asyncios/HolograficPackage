using UnityEngine;
using System.Collections;

public class LightSaberStormTrooper : MonoBehaviour {

    // Use this for initialization
    public UnityEngine.UI.Text score;
	public static bool hit;

	void Start () {
		hit = false;
	}
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnTriggerEnter(Collider other) {
        if (!other.gameObject.name.Equals("PersonCube"))
        {
            hit = true;
            score.text = (int.Parse(score.text) + 100).ToString(); ;    
        }
		
	}


}
