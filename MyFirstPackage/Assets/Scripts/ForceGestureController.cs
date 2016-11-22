using UnityEngine;
using System.Collections;

public class ForceGestureController : GestureController
{
    Rigidbody forceRigidbody;
    private float intensity;
    private float minimumElapsedTime;
    private float elapsedTime;
    private float deltaScale;
    // Use this for initialization

    void Start ()
    {
        base.StartConstructor();
        intensity = 0;
        forceRigidbody = this.GetComponent<Rigidbody>();
        forceRigidbody.velocity = new Vector3(0, 0, 0);
        minimumElapsedTime = 1.2f;
        elapsedTime = 0.0f;
        deltaScale = 0.2f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (!isTracked())
        //    return;
        if (forceRigidbody.velocity.z == 0.0f)
        {
            elapsedTime += Time.deltaTime;
            base.VerifyOnUpdate();
            if (gestureOption == GestureEnumOption.moveWithRightHand)
            {
                if (closesHand || elapsedTime < minimumElapsedTime)
                {
                    intensity += 1;
                }
                else
                {
                    if (!closesHand && intensity > 0)
                    {
                        forceRigidbody.velocity = new Vector3(0, 0, -intensity);
                        intensity = 0;
                    }

                }
            }
            else
            {
                intensity = 0;
            }
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x+deltaScale, transform.localScale.y + deltaScale, transform.localScale.z + deltaScale);
        }
        if (transform.position.z<-10)
        {
            restoreToDefaults();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        restoreToDefaults();

    }

    private void restoreToDefaults()
    {
        transform.position = originPosition;
        forceRigidbody.velocity = new Vector3(0, 0, 0);
        minimumElapsedTime = 1.2f;
        elapsedTime = 0.0f;
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) ;
    }

}
