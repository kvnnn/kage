using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpotlightManager : GameMonoBehaviour
{
	[SerializeField]
	private Transform mainLightTransform;

	private ShadowDetector shadowDetector_;
	private ShadowDetector shadowDetector
	{
		get
		{
			if (shadowDetector_ == null)
			{
				shadowDetector_ = mainLightTransform.GetComponentInChildren<ShadowDetector>();
			}
			return shadowDetector_;
		}
	}

	public void Init(List<BaseObject> objects)
	{
		shadowDetector.Init(objects);
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

	private void CheckShadowCollision()
	{
		foreach (BaseObject obj in shadowDetector.GetObjects())
		{
			foreach (BaseObject compareObj in shadowDetector.GetObjects())
			{
				if (obj == compareObj) {continue;}
				if (HasShadowCollision(obj.GetShadowPointList(), compareObj.GetShadowPointList()))
				{
					if (obj.collider.bounds.size.magnitude > compareObj.collider.bounds.size.magnitude)
					{
						compareObj.SetAttractingGameObject(obj.transform);
					}
					else
					{
						obj.SetAttractingGameObject(compareObj.transform);
					}
				}
			}
		}
	}

	public void StartLightCoroutine()
	{
		StartCoroutine(LightCoroutine());
	}

	private IEnumerator LightCoroutine()
	{
		// TODO : stop when game finish
		while (true)
		{
			if (IsTouch())
			{
				ActivateMainLight();
				mainLightTransform.RotateLocalEulerAnglesY(CalculateDegreeFromCenter() * -1);

				shadowDetector.UpdateShadowData();
				CheckShadowCollision();
			}
			else
			{
				// DeactivateMainLight();
			}

			yield return null;
		}
	}
#endregion

	private float CalculateDegreeFromCenter()
	{
		var p1 = new Vector2(Screen.width/2, Screen.height/2);
		var p2 = GetTouchPosition();
		float dx = p2.x - p1.x;
		float dy = p2.y - p1.y;
		float rad = Mathf.Atan2(dy, dx);
		return rad * Mathf.Rad2Deg;
	}

	private bool HasShadowCollision(List<Vector2> points, List<Vector2> comparePoints)
	{
		foreach (Vector2 point in points)
		{
			if (HasContainsPoint(comparePoints, point))
			{
				return true;
			}
		}
		return false;
	}

	private bool HasContainsPoint(List<Vector2> points, Vector2 p)
	{
		int j = points.Count - 1;
		bool inside = false;
		for (int i = 0; i < points.Count; j = i++) {
			if (((points[i].y <= p.y && p.y < points[j].y) ||
					(points[j].y <= p.y && p.y < points[i].y)) &&
			    (p.x < (points[j].x - points[i].x) * (p.y - points[i].y) / (points[j].y - points[i].y) + points[i].x))
			{
				inside = !inside;
			}
		}
		return inside;
	}
}
