using UnityEngine;
using System.Collections;

// This class helps with fading the UI elements after a short wait
public class FadeUIElement : MonoBehaviour {

    public float WaitTime;

	void Start ()
    {
            GameObject.Destroy(gameObject, WaitTime);
    }
}
