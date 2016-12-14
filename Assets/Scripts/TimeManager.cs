using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TimeManager : MonoBehaviour
{
		
	public static float timeLeft = 20.0f;
	Text text;

		void Awake ()
	{
		text = GetComponent <Text> ();
	}
	void Update(){
		timeLeft -= Time.deltaTime;


			text.text = "Time Left:" + Mathf.Round (timeLeft);
			if (timeLeft < 0) {
						Application.LoadLevel("gameOver");
		}
	}
}