using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : GameMonoBehaviour
{
	// TODO : this code is for test
	[SerializeField]
	private List<BaseObject> objects;

	public void Init()
	{
		SetStage();
	}

	private void SetStage()
	{

	}

	public List<BaseObject> GetObjects()
	{
		return objects;
	}
}
