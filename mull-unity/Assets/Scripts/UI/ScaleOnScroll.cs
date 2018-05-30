using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnScroll : MonoBehaviour {

	// The camera to base new dimsensions on
	GameObject mainCamera;

	// Multiply by this to make marker dimensions relative to camera height
	float scaleFactor = 0.05f;

	// Give the marker a minimum and maximum size
	float minSize = 20f;
	float maxSize = 100f;

	void Start () {

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

	}

	void Update () {

		// Calculate new dimensions by multiplying camera height by scaling factor
		float newDimensions = mainCamera.GetComponent<Transform>().position.y * scaleFactor;

		// Keep marker size within minimum and maximum limits
		if (newDimensions < minSize) newDimensions = minSize;
		else if (newDimensions > maxSize) newDimensions = maxSize;

		// Get the Rect Transform component of this marker
		RectTransform rt = GetComponent<RectTransform>();

		// Change the width and height to the new dimensions
		rt.sizeDelta = new Vector2 (newDimensions, newDimensions);

	}
}
