using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : GameMonoBehaviour
{
	private StageManager stageManager;

	[SerializeField]
	private GameObject stagePrefab;

#region Init
	public void InitGame()
	{
		InitStage();
		PrepareGame();
	}

	private void InitStage()
	{
		if (stageManager == null)
		{
			GameObject stageGameObject = Instantiate(stagePrefab);
			stageGameObject.transform.SetParent(transform);
			stageManager = stageGameObject.GetComponent<StageManager>();
		}

		stageManager.Init();
	}
#endregion

	public void PrepareGame()
	{

	}
}
