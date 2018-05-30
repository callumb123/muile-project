using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

	SettlementInformation settlementInfo;
	GameObject status;
	StatusController statusController;
	AudioSource discoveredSound;
	
	// Use this for initialization
	void Start () {
		settlementInfo = GetComponentInParent<SettlementInformation> ();
		status = GameObject.FindGameObjectWithTag ("Status");
		statusController = status.GetComponent<StatusController> ();
		discoveredSound = GetComponent<AudioSource> ();	
	}
	
	// Detects when a player is near a settlement
	void OnTriggerEnter(Collider c) {
		if (c.gameObject.CompareTag ("Player")) {
			
			//Checks if the player has found this settlement before
			if(!settlementInfo.getIsFound() && statusController.getCanDiscover()) {
				StartCoroutine(pauseIsFound());
			}
			
			//If they have then set text to white and dont play sound
			else if(statusController.getCanDiscover()) {
				statusController.setTimer(1000f);
				Color colorAlreadyFound = Color.white;
				statusController.setDiscovered (settlementInfo, colorAlreadyFound);
			}
		}
	}
	
	//Once player has moved away from settlement, remove the headname text
	void OnTriggerExit(Collider c) {
		if (c.gameObject.CompareTag ("Player")) {
			statusController.setTimer(0f);
		}
	}
	
	/* If player hasnt found settlement before, play sound and set text to gold */
	IEnumerator pauseIsFound() {
		statusController.setTimer(3f);
		Color colorNotFound = new Color32(204, 163, 14, 255);
		statusController.setDiscovered (settlementInfo, colorNotFound);
		discoveredSound.Play();
		settlementInfo.findSettlement ();
		yield return new WaitForSeconds(3f);
    }
}
