using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class GestureController : MonoBehaviour {
    public enum GestureEnumOption
    {
        moveWithRightHand,
        rotateWithRightHand,
        rotateWithTwoHand
    };

    public GestureEnumOption gestureOption;
    public float rotationSmooth;
    public GameObject handLeft;
    public GameObject handRight;
    public GameObject kinectController;
    private BodySourceManager _bodyManager;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isTracked())
        {
            if (gestureOption == GestureEnumOption.moveWithRightHand)
            {
                this.transform.position = handRight.transform.position;
            }
            if (gestureOption == GestureEnumOption.rotateWithRightHand)
            {
                Vector3 rotationVector = handRight.transform.position * rotationSmooth;
                this.transform.rotation = Quaternion.LookRotation(rotationVector);
            }

            if (gestureOption == GestureEnumOption.rotateWithTwoHand)
            {
                Vector3 rotationVector = (handRight.transform.position- handLeft.transform.position) * rotationSmooth;
                this.transform.rotation = Quaternion.LookRotation(rotationVector);
            }
        }
	}

    public bool isTracked()
    {
        if (kinectController== null)
        {
            return false;
        }
        _bodyManager = kinectController.GetComponent<BodySourceManager>();
        if (_bodyManager == null)
        {
            return false;
        }
        Body[] data = _bodyManager.GetData();
        if (data == null)
        {
            return false;
        }
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                return true;
            }
        }

        return false;
    }
    
}
