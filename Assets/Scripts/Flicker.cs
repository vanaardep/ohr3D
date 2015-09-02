using UnityEngine;

[RequireComponent(typeof(Light))]

public class Flicker : MonoBehaviour { 
	public float minIntensity = 0.25f; 
	public float maxIntensity = 0.5f;
	public float speed = 0.07f;
	private float randomizer = 0f;
	private Light myLight;
	
	void Start()
	{
		myLight = GetComponent<Light>();
	}

	
	void FixedUpdate()
	{

			randomizer = Random.Range (0f, 1.1f);
			if (randomizer <= speed) {
				//myLight.enabled = false;
				myLight.intensity = minIntensity;
			} else {
				//myLight.enabled = true;
				myLight.intensity = maxIntensity;
			}

	}

}