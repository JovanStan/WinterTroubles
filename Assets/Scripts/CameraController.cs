using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float speed = .4f;


	void Update()
	{
		MoveCamera();
	}

	public void MoveCamera()
	{
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime,
								 -touchDeltaPosition.y * speed * Time.deltaTime,
								 0f, Space.Self);
		}
	}

}
