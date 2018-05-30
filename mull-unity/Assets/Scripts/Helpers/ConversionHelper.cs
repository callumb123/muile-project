using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Quick and basic class to convert any osgb points into points on the Mull map */
public static class ConversionHelper {

	private const float INCH_KENNETH_UNITY_SIZE = 179.1074816974433f;
	private const float INCH_KENNETH_REAL_SIZE = 1904.052f;
	private const float BODGE_AMOUNT = 0.799f;

	private static readonly Vector2 bottomCorner = new Vector2(124000f, 707600f); //bottom corner of this map in easting northing, got by looking real hard and trial and error changes. Could change.
	private const float scalingFactor = (INCH_KENNETH_UNITY_SIZE/ INCH_KENNETH_REAL_SIZE) * BODGE_AMOUNT; //hardcoded scaling factor, taken by measuring distance from top of Inch kenneth to bottom on online distance checker (in metres) + unity map


	public static Vector2 GridReferenceToUnityCoords(Vector2 gridReference) {
		return (gridReference - bottomCorner) * scalingFactor;
	}
}
