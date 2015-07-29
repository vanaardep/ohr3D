using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Vector2 Margin;
	public Vector2 Smoothing;
	public BoxCollider Bounds;
	private Vector3 _min,_max;
	//float minFov  = 15;
	//float maxFov  = 90;
	//float sensitivity  = 10;

	// Use this for initialization

	public bool IsFollowing{ get; set; }

	void Start () {
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		IsFollowing = true;
		//target = GameObject.Find ("Player").transform;

		// Set camera zoom
		//Camera.main.orthographic = true;
		//Camera.main.orthographicSize = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		float x = transform.position.x;
		float y = transform.position.y;

		if (IsFollowing) 
		{
			if(Mathf.Abs(x- target.position.x) > Margin.x)
			{
				x = Mathf.Lerp(x,target.position.x,Smoothing.x *Time.deltaTime);
			}

			if(Mathf.Abs(y - target.position.y) > Margin.y)
			{
				y = Mathf.Lerp (y,target.position.y,Smoothing.y*Time.deltaTime);
			}
		}

		float cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + Camera.main.orthographicSize, _max.y - Camera.main.orthographicSize);
		//transform.position = target.position + new Vector3 (0, 0, -2);

		transform.position = new Vector3 (x, y, transform.position.z);
	}
}
