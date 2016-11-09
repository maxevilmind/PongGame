using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject ballTemplate;

	public Text firstPlayerScoreText;
	public Text secondPlayerScoreText;

	private int firstPlayerScoreCount;
	private int secondPlayerScoreCount;

	void OnTriggerExit(Collider other) {
		print ("OnTriggerExit with object" + other.gameObject.tag);
		if (other.gameObject.CompareTag ("Ball")) {
			print ("OnTriggerExit if statement");
			GameObject ball = other.gameObject;

			if (ball.transform.position.z < transform.position.z) {
				firstPlayerScoreCount++;
				firstPlayerScoreText.text = firstPlayerScoreCount.ToString();
			} else {
				secondPlayerScoreCount++;
				secondPlayerScoreText.text = secondPlayerScoreCount.ToString();
			}
			ball.transform.position = new Vector3(10,0,10);
			Rigidbody ballRb = ball.GetComponent<Rigidbody> ();
			ballRb.velocity = new Vector3 (0,0,0);
			ballRb.AddForce (new Vector3 (1, 0, 1) * 20);
			//Destroy (ball);
			//Instantiate (ballTemplate);
		}
	}
}
