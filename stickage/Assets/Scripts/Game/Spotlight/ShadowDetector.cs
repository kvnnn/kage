using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShadowDetector : GameMonoBehaviour
{
	private List<BaseObject> objects;

	public void Init(List<BaseObject> objects)
	{
		this.objects = objects;
	}

	public List<BaseObject> GetObjects()
	{
		return objects;
	}

	public void UpdateShadowData()
	{
		List<BaseObject> objectsInLight = new List<BaseObject>();
		foreach (BaseObject obj in objects)
		{
			if (IsObjectInLight(obj))
			{
				objectsInLight.Add(obj);
			}
		}

		foreach (BaseObject obj in objectsInLight)
		{
			obj.UpdateShadowBounds(transform.position, GetComponent<Light>().range);
		}
	}

	private bool IsObjectInLight(BaseObject obj)
	{
		Vector3 targetDir = obj.transform.position - transform.position;
		Vector3 forward = transform.forward;
		float angle = Vector3.Angle(targetDir, forward);

		return angle < GetComponent<Light>().spotAngle/2 && Vector3.Distance(obj.transform.position, transform.position) < GetComponent<Light>().range;
	}
}
