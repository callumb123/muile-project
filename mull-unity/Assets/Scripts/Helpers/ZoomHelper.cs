using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/* A static helper class providing functions to help with zooming in 
TODO: make object make more sense - refactor helper functions into a Settlements/Panel object class?*/

public static class ZoomHelper {

	/* Sets the visibility of the passed canvasGroup panel */
	public static void setUIVisibility (CanvasGroup panel, bool isVisible)
	{
		panel.interactable = isVisible;
		panel.alpha = isVisible ? 1 : 0;
		panel.blocksRaycasts = isVisible;
	}

	/** Turns off every marker for each settlement 
	TODO: refactor away this into a method called on each settlement itself?**/
	public static void setMarkerVisibility(bool isVisible, string tag="SettlementMarker") {
		GameObject[] settlements = GameObject.FindGameObjectsWithTag (tag);
		setPlayerVisibility (isVisible);
		foreach (GameObject settlement in settlements) {
			SettlementInformation settlementInfo = settlement.GetComponentInParent<SettlementInformation> ();

			if (isVisible) {
				setMarker (settlement, settlementInfo.getIsFound());
			} else {
				setMarker (settlement, false);
			}
		}
			

	}

	private static void setMarker(GameObject settlement, bool isOn) {
		
		settlement.GetComponent<Toggle> ().enabled = isOn;
		settlement.GetComponent<Image> ().enabled = isOn;

	}

	public static void setPlayerVisibility(bool isVisible) {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponentInChildren<Toggle> ().enabled = isVisible;
		player.GetComponentInChildren<Image> ().enabled = isVisible;
	}
}