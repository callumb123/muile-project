using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHelper{

	/*Helper class to convert lots of json into a parameterized  */

	/* Converts json string into generic typed array */
	public static T[] FromJson<T>(string json) {
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (json);
		return wrapper.Items;
	}

	/* Adds prefix to json string in order to make it processable 
	TODO: refactor into some constructor lol?*/
	public static string FixJson(string value) {
		value = "{\"Items\":" + value + "}";
		return value;

	}

	/* Serializable wrapper class to help convert json into <TYPE>*/
	[System.Serializable]
	private class Wrapper<T>
	{
		public T[] Items;
	}

}
