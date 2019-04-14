using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findChildComponent : MonoBehaviour {

	public GameObject FindObject(string name)
	{
		Transform[] trs= gameObject.GetComponentsInChildren<Transform>(true);
		foreach(Transform t in trs){
			if(t.name == name){
				return t.gameObject;
			}
		}
		return null;
	}
}
