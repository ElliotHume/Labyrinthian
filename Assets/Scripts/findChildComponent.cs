using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findChildComponent : MonoBehaviour {

	public GameObject FindObject(string name)
	{
		Debug.Log ("I'm being called");
		Transform[] trs= gameObject.GetComponentsInChildren<Transform>(true);
		foreach(Transform t in trs){
			if(t.name == name){
				Debug.Log (t.name);
				return t.gameObject;
			}
		}
		return null;
	}
}
