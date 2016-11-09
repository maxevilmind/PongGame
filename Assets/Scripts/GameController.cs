using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class GameController : MonoBehaviour {
	public GameObject ballTemplate;

	public Text firstPlayerScoreText;
	public Text secondPlayerScoreText;
	public Text timeInSeconds;

	private int firstPlayerScoreCount;
	private int secondPlayerScoreCount;
	public int WinPoints;
	public int timeSeconds;

	System.Timers.Timer t;

	void Start(){
		t = new Timer ();
		t.Elapsed += new ElapsedEventHandler (onTimer);
		t.Interval = 1000;
		t.Start ();
	}

	void onTimer(object source, ElapsedEventArgs e){
		timeSeconds--;
	}
	void Update(){
		timeInSeconds.text = timeSeconds.ToString ();
		timeInSeconds.fontSize=8;
		CheckTime ();
	}

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
			CheckWin ();
			//Destroy (ball);
			//Instantiate (ballTemplate);
		}
	}
	void CheckWin(){
		if (firstPlayerScoreCount == WinPoints) {
			firstPlayerScoreText.text = "WIN!";
			GameOver ();
		} 
		if (secondPlayerScoreCount == WinPoints) {
			secondPlayerScoreText.text = "WIN!";
			GameOver ();
		} 

	}
	void CheckTime(){
		if(timeSeconds == 0)
		{
			if (firstPlayerScoreCount > secondPlayerScoreCount) {
				firstPlayerScoreText.text = "WIN!";
				GameOver ();
			} else if (firstPlayerScoreCount < secondPlayerScoreCount) {
				secondPlayerScoreText.text = "WIN!";
				GameOver ();
			} else {
				firstPlayerScoreText.text = "DRAW";
				secondPlayerScoreText.text = "DRAW";
				GameOver ();
			}
		}
	}
	void GameOver(){
		firstPlayerScoreCount = 0;
		secondPlayerScoreCount = 0;
		timeSeconds = 120;

	}
}
