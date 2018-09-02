using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour 
{
	public static TrashBin Instance;

	void Awake()
	{
		if(Instance == null){
			Instance = this;
		}
	}

	public void ThrowInTrash(Transform trashItem){
		trashItem.SetParent(this.transform);
	}
}
