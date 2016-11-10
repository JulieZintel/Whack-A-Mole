using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {
	// Mole Prefab
	public GameObject mole;
	public float aliveTime = 1;

	// Spawn Interval
	public int intervalMin = 4;
	public int intervalMax = 15;

	// Use this for initialization
	void Start () {
		Invoke("Spawn", Random.Range(intervalMin, intervalMax));
	}

	void Spawn() {
		// Spawn the mole
		GameObject g = (GameObject)Instantiate(mole, transform.position, Quaternion.identity);

		// Make sure to destroy it after a few seconds
		Destroy(g, aliveTime);

		// Next Spawn
		Invoke("Spawn", Random.Range(intervalMin, intervalMax));
	}

	//----score count---------------------
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "Mole") // If the fish and fisherman collide.
		{
			Destroy(other.gameObject); // Destroys the fish.
			score += 1; // 1 point is added to the player's score.
		}
}