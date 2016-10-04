using UnityEngine;
using System.Collections;

public class FadeUIElement : MonoBehaviour {

    public float WaitTime;
	// Use this for initialization
	void Start ()
    {
            GameObject.Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
