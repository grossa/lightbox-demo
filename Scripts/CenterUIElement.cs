using UnityEngine;
using System.Collections;

// This class helps center the UI elements so they are fixed at the center of the image
public class CenterUIElement : MonoBehaviour {

    public GameObject LeftDome180;
	
	void Update ()
    {
        transform.eulerAngles = new Vector3(LeftDome180.transform.eulerAngles.x, LeftDome180.transform.eulerAngles.y, 0);
        transform.position = LeftDome180.transform.position + LeftDome180.transform.forward * 0.3f;
    }
}
