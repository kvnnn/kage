using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMonoBehaviour : MonoBehaviour
{
	protected bool IsTouch()
	{
		return Input.touchCount > 0 || Input.GetMouseButton(0);
	}

	protected Vector2 GetTouchPosition()
	{
#if UNITY_EDITOR
		return Input.mousePosition;
#else
		Touch touch = Input.GetTouch(0);
		return touch.position;
#endif
	}
}
