using UnityEngine;
using System.Collections;

public class EnemyMole : MonoBehaviour {

	public GameObject onHit;
	public int scoreValue = 1;

	void OnMouseDown() {
		// Load On-Hit effect
		GameObject f = (GameObject)Instantiate(onHit, transform.position, Quaternion.identity);

		// Destroy it after a while
		Destroy(f, 0.2f);
		ScoreManager.score -= scoreValue;

	}
}
