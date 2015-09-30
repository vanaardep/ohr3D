using UnityEngine;
using System.Collections;

public class LightBulbHover : MonoBehaviour {

	float maxUpAndDown = 0.2f;             // amount of meters going up and down
	float speed = 150;            // up and down speed
	protected float angle = 0;            // angle to determin the height by using the sinus
	protected float toDegrees = Mathf.PI / 180;    // radians to degrees
	
	void Update()
	{
		angle += speed * Time.deltaTime;
		if (angle > 360) angle -= 360;
		transform.position = new Vector3 (transform.position.x, maxUpAndDown * Mathf.Sin(angle * toDegrees), transform.position.z);
	}
}
