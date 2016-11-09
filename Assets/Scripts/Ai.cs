using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {
	public Rigidbody ball;
	public Rigidbody paddle;
	public int ForceMultiplier;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.position.x < paddle.position.x) {
			paddle.AddForce (new Vector3 (-1 * ForceMultiplier, 0, 0));
		} else {
			paddle.AddForce (new Vector3 (1 * ForceMultiplier, 0, 0));
		}
	}
}
