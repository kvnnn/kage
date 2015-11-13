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
#endregion

#region Move Light
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
				ActivateMainLight();
				mainLightTransform.RotateLocalEulerAnglesY(CalculateDegreeFromCenter() * -1);
			}
			else
			{
				// DeactivateMainLight();
			}

			yield return null;
		}
	}

	private float CalculateDegreeFromCenter()
	{
		var p1 = new Vector2(Screen.width/2, Screen.height/2);
		var p2 = GetTouchPosition();
		float dx = p2.x - p1.x;
		float dy = p2.y - p1.y;
		float rad = Mathf.Atan2(dy, dx);
		return rad * Mathf.Rad2Deg;
	}
#endregion
}
