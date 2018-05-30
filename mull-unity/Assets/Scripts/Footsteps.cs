using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	//Both compenents for player
	PlayerController player;
	Rigidbody playerBody;
	
	//Different audio sources for water and ground footsteps
	AudioSource groundFootsteps;
	AudioSource waterFootsteps;

	void Start () {
		
		//Gets both compenents for player, one for grounded other for velocity
		player = GetComponent<PlayerController> ();
		playerBody = GetComponent<Rigidbody> ();
		
		//Gets list of all audio sources and assigns footsteps to different audio sources
		AudioSource[] allFootsteps = GetComponents<AudioSource> ();
		groundFootsteps = allFootsteps[0];
		waterFootsteps = allFootsteps[1];
	}


	void Update () {
		
		//Checks that the player is on the ground and currently moving
		if (player.isGrounded() == true && playerBody.velocity.magnitude > 2f) {
			
			//Checks that the player is above the water so that groundFootsteps is played
			//Ensures that the sound is not already currently playing
			if(player.getYValue() >= 2.0f && groundFootsteps.isPlaying == false) {
				
				//Prevents sound overlapping by stopping waterFootsteps as soon as player is above water
				if(waterFootsteps.isPlaying == true) waterFootsteps.Stop();
				
				//Creates random range of pitches/volume to make it more realistic
				groundFootsteps.volume = Random.Range (0.8f, 1);
				groundFootsteps.pitch = Random.Range (0.6f, 0.8f);
				groundFootsteps.Play ();
			}
			
			//Checks the player is now in the water and is not currently playing waterFootsteps
			else if(player.getYValue() < 2.0f && waterFootsteps.isPlaying == false) {
				
				//Stops groundFootsteps audio if currently playing
				if(groundFootsteps.isPlaying == true) groundFootsteps.Stop();
				
				//Creates random range of pitches/volume to make it more realistic
				waterFootsteps.volume = Random.Range (0.8f, 1);
				waterFootsteps.pitch = Random.Range (0.6f, 0.8f);
				waterFootsteps.Play ();
			}
		}
	}
}
