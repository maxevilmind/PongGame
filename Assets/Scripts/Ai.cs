using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {
	public Rigidbody ball;
	public Rigidbody paddle;
	public bool Horizontal;
	public int ForceMultiplier;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		if (!Horizontal) {
			if (ball.position.z < paddle.position.z) {
				paddle.AddForce (new Vector3 (0, 0, -1 * ForceMultiplier));
			} else if (ball.position.z >= paddle.position.z) {
				paddle.AddForce (new Vector3 (0, 0, 1 * ForceMultiplier));
			}
		} else {

			if (ball.position.x < paddle.position.x) {
				paddle.AddForce (new Vector3 (-1 * ForceMultiplier, 0, 0));
			} else if (ball.position.x >= paddle.position.x) {
				paddle.AddForce (new Vector3 (1 * ForceMultiplier, 0, 0));
			}
		}
	}
}
