﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	//reference to star images
	private GameObject star1;
	private GameObject star2;
	private GameObject star3;

	//reference to next button
	private GameObject buttonNext;
	private GameObject buttonRestart;
	private GameObject starPanel;
	public GameObject scoreText;

	protected string currentLevel;
	protected int worldIndex;
	protected int levelIndex;
	public static bool isLevelComplete ;
	//timer text reference
	public Text timerText;
	//time passed since start of level
	protected int totalScore;
	public static int score;
	public static float timeLeft = 20.0f;
	//Scores
	public int scoreValue = 1;
	public GameObject onHit;
	private bool restart;
	//LevelStop


	// Use this for initialization
	void Start () {
		//set the level complete to false on start of level
		isLevelComplete = false;
		//get the star images
		star1 = GameObject.Find("star1");
		star2 = GameObject.Find("star2");
		star3 = GameObject.Find("star3");
		//get the next button
		buttonNext = GameObject.Find("Next");
		buttonRestart = GameObject.Find ("Restart");
		starPanel = GameObject.Find ("StarPanel");

		//disable the image component of all the star images
		star1.GetComponent<Image>().enabled = false;
		star2.GetComponent<Image>().enabled = false;
		star3.GetComponent<Image>().enabled = false;
		//disable the next button
		buttonNext.SetActive(false);
		buttonRestart.SetActive (false);
		starPanel.SetActive (false);
		//save the current level name
		currentLevel = Application.loadedLevelName;
	}

	// Update is called once per frame
	void Update () {

		//check if the level is completed
		if(!isLevelComplete){
			//update the timer value
			timeLeft -= Time.deltaTime;
			//display the timer value 
			timerText.text = "TIME: "+ Mathf.Round (timeLeft);
			Debug.Log(totalScore);
			//move the player based on left and right arrow keys
			transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*10f, 0, 0); //get input
			totalScore = scoreText.GetComponent<ScoreManager>().score1;
	}

			if(timeLeft < 0){

			Debug.Log ("star1:" + star1.GetComponent<Image> ().enabled + ", star2: " + star2.GetComponent<Image> ().enabled + ", star3: " + star3.GetComponent<Image> ().enabled);
			Debug.Log ("totalscore: "+totalScore);
			starPanel.SetActive (true);
			//set the isLevelComplete flag to true if the player hits an object with name Goal
			isLevelComplete = true;
			if(totalScore>=0 && totalScore<=5){
				//star3.GetComponent<Image>().enabled = false;
				//star2.GetComponent<Image>().enabled = false;
				star1.GetComponent<Image>().enabled = true;
				UnlockLevels(3);   //unlock next level funxtion 
			}
			else if(totalScore>5 && totalScore<=10){
				star2.GetComponent<Image>().enabled = true;
				//star3.GetComponent<Image>().enabled = false;
				//star1.GetComponent<Image>().enabled = false;
				UnlockLevels(2);   //unlock next level funxtion 
			}
			else if(totalScore>=15){
				//star1.GetComponent<Image>().enabled = false;
				//star2.GetComponent<Image>().enabled = false;
				star3.GetComponent<Image>().enabled = true;
				UnlockLevels(1);   //unlock next level funxtion 
			}
			buttonNext.SetActive(true);
			buttonRestart.SetActive (true);
			}

		}

	public void OnClickButton(){
		//load the World1 level 
		Application.LoadLevel("World1");

	}

	protected void  UnlockLevels (int stars){

		//set the playerprefs value of next level to 1 to unlock
		//also set the playerprefs value of stars to display them on the World levels menu
		for(int i = 0; i < LockLevel.worlds; i++){
			for(int j = 1; j < LockLevel.levels; j++){               
				if(currentLevel == "Level"+(i+1).ToString() +"." +j.ToString()){
					worldIndex  = (i+1);
					levelIndex  = (j+1);
					PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +levelIndex.ToString(),1);
					//check if the current stars value is less than the new value
					if(PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" +j.ToString()+"stars")< stars)
						//overwrite the stars value with the new value obtained
						PlayerPrefs.SetInt("level"+worldIndex.ToString() +":" +j.ToString()+"stars",stars);
				}
			}
		}

	}
	void OnMouseDown() {
		// Load On-Hit effect
		GameObject g = (GameObject)Instantiate(onHit, transform.position, Quaternion.identity);
		// Destroy it after a while
		Destroy(g, 0.2f);
		ScoreManager.score += scoreValue;

	}
	public void restartCurrentScene()
	{
	Application.LoadLevel("Level1.1");
		//int scene = SceneManager.GetActiveScene().buildIndex;
		//SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}


}
	