using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpotlightManager : GameMonoBehaviour
{
	[SerializeField]
	private Transform mainLightTransform;

	public void Init()
	{
		DeactivateMainLight();
	}

#region MainLight
	private void ActivateMainLight()
	{
		mainLightTransform.gameObject.SetActive(true);
	}

	private void DeactivateMainLight()
	{
		mainLightTransform.gameObject.SetActive(false);
	}

	public void StartLightCoroutine()
	{
		StartCoroutine(LightCoroutine());
	}

	private IEnumerator LightCoroutine()
	{
		// TODO : stop when game finish
		while(true)
		{
			if (IsTouch())
			{
				UnityEngine.Debug.LogError(GetTouchPosition());
			}

			yield return null;
		}
	}
#endregion
}
