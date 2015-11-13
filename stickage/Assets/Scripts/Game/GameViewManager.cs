using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameViewManager : ViewManager
{
	[SerializeField]
	private GameManager gameManager;

	[SerializeField]
	private Transform uiBaseTransform;

	protected override void BeforeShow()
	{
		gameManager.InitGame();
		InitUI();
	}

	private void InitUI()
	{

	}

	private T InstantiateUI<T>(GameObject prefab)
		where T : BaseUIParts
	{
		T uiParts = uiBaseTransform.GetComponentInChildren<T>();
		if (uiParts == null)
		{
			GameObject uiPartsGameObject = Instantiate(prefab);
			uiPartsGameObject.transform.SetParent(uiBaseTransform);
			uiParts = uiPartsGameObject.GetComponent<T>();
		}

		uiParts.Init();
		return uiParts;
	}
}
