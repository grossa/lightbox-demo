using UnityEngine;
using System.Collections;

public class CenterUIElement : MonoBehaviour {

    public GameObject LeftDome180;

    // Use this for initialization
    void Start ()
    {
        //transform.eulerAngles = new Vector3(LeftDome180.transform.eulerAngles.x, LeftDome180.transform.eulerAngles.y, 0);
        //transform.position = new Vector3(LeftDome180.transform.position.x, LeftDome180.transform.position.y, LeftDome180.transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.eulerAngles = new Vector3(LeftDome180.transform.eulerAngles.x, LeftDome180.transform.eulerAngles.y, 0);
        transform.position = LeftDome180.transform.position + LeftDome180.transform.forward * 0.3f;
    }
}
