using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : GameMonoBehaviour
{
	private StageManager stageManager;
	private SpotlightManager spotlightManager;

	[SerializeField]
	private GameObject stagePrefab;
	[SerializeField]
	private GameObject spotlightPrefab;

#region Init
	public void InitGame()
	{
		stageManager = InstantiateManager<StageManager>(stageManager, stagePrefab);
		stageManager.Init();

		spotlightManager = InstantiateManager<SpotlightManager>(spotlightManager, spotlightPrefab);
		spotlightManager.Init();

		PrepareGame();
	}

	private T InstantiateManager<T>(T manager, GameObject prefab)
		where T : GameMonoBehaviour
	{
		if (manager == null)
		{
			GameObject gameObject = Instantiate(prefab);
			gameObject.transform.SetParent(transform);
			manager = gameObject.GetComponent<T>();
		}

		return manager;
	}
#endregion

	public void PrepareGame()
	{
		spotlightManager.StartLightCoroutine();
	}
}
