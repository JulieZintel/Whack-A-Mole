using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour {

	public GameObject onHit;
	public int scoreValue = 1;

	void OnMouseDown() {
		// Load On-Hit effect
		GameObject g = (GameObject)Instantiate(onHit, transform.position, Quaternion.identity);

		// Destroy it after a while
		Destroy(g, 1.2f);
		ScoreManager.score += scoreValue;

	}
}
