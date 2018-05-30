using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Increased the size of the hiker image when it is hovered over
public class OnHoverHiker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public Quaternion initialRotation;
	void Awake() {
		initialRotation = transform.rotation;
	}

	//Increases hiker by a factor of 5 when pointer is over it
	public void OnPointerEnter(PointerEventData eventData) {
		GameObject hikerIcon = GameObject.FindGameObjectWithTag ("HikerIcon");
		hikerIcon.transform.localScale += new Vector3(5,5,0);
	}
	
	//When no longer hovering, puts hiker back to original size
	public void OnPointerExit(PointerEventData eventData) {
		GameObject hikerIcon = GameObject.FindGameObjectWithTag ("HikerIcon");
		hikerIcon.transform.localScale -= new Vector3(5,5,0);
	}

}
