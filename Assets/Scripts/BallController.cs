using UnityEngine;
using System.Collections;
using System;

public class BallController : MonoBehaviour {
	public int initialForceMultiplier = 1;
	public Rigidbody rigidbody;
	public float InputForceScale = 10.0f;
	// Use this for initialization
	void Start () {
		Vector3 force = 
			Quaternion.Euler(0, (int)UnityEngine.Random.Range(-30,30), 0)*
			Vector3.forward;
		force = force * InputForceScale;

		rigidbody.AddForce (force);
	}
}
