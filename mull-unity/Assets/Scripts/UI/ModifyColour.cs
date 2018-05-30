using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifyColour : MonoBehaviour {

	Image image;
	Color defaultColour;
	Vector3 defaultSize;
	
	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
		defaultColour = image.color;
		defaultSize = transform.localScale;
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void correctColour() {
		image.color = Color.green;
		transform.localScale = defaultSize * 3f;

	}

	public void guessedColour() {
		image.color = Color.magenta;
		transform.localScale = defaultSize * 3f;
	}

	public void reset() {
		image.color = defaultColour;
		transform.localScale = defaultSize;
	}


}
