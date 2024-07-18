using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform target;

	void LateUpdate()
	{
		if (target.position.y > transform.position.y)
		{
			Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
			transform.position = newPosition;
		}
	}
}
