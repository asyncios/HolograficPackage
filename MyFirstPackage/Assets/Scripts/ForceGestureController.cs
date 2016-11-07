using UnityEngine;
using System.Collections;

public class ForceGestureController : GestureController
{
    Rigidbody forceRigidbody;
    private float intensity;
	// Use this for initialization
	void Start () {
        base.StartConstructor();
        intensity = 0;
        forceRigidbody = this.GetComponent<Rigidbody>();
        forceRigidbody.velocity = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (forceRigidbody.velocity.z == 0.0f)
        {
            base.VerifyOnUpdate();
            if (gestureOption == GestureEnumOption.moveWithRightHand)
            {
                if (closesHand)
                {
                    intensity += 1;
                }
                else
                {
                    if (intensity > 0)
                    {
                        forceRigidbody.velocity = new Vector3(0, 0, -intensity);
                    }
                    intensity = 0;
                }
            }
            else
            {
                intensity = 0;
            }
        }
        
	}
}
