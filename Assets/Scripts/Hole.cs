using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {
	// Mole Prefab
	public GameObject mole;
	//public GameObject enemyMole;	
	public float aliveTime = 1;
	public static bool isLevelComplete ;

	// Spawn Interval
	public int intervalMin = 4;
	public int intervalMax = 15;


	// Use this for initialization
	void Start () {

		Invoke("Spawn", Random.Range(intervalMin, intervalMax));
	}
		
	void Spawn() {

		if (Random.value > 0.5f) {

	/*		//Spawn the enemyMole
			GameObject f = (GameObject)Instantiate (enemyMole, transform.position, Quaternion.identity);
			// Make sure to destroy it after a few seconds
			Destroy (f, aliveTime);
		} else {*/
			// Spawn the mole
			GameObject g = (GameObject)Instantiate (mole, transform.position, Quaternion.identity);
			// Make sure to destroy it after a few seconds
			Destroy (g, aliveTime);
		}
	
		// Next Spawn

		if (!isLevelComplete) {
			Invoke ("Spawn", Random.Range (intervalMin, intervalMax));
		}
}


}