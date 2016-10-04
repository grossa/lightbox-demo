using UnityEngine;
using System.Collections;

public class FadeUIElement : MonoBehaviour {

    public float WaitTime;

	void Start ()
    {
            GameObject.Destroy(gameObject, 5.0f);
    }
}
