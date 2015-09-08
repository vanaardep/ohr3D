using UnityEngine;

[RequireComponent(typeof(Light))]

public class Flicker2 : MonoBehaviour { 
	public float minIntensity = 0.25f; 
	public float maxIntensity = 0.5f;
	//public float delay;
	
	float random;
	
	void Start()
	{
		random = Random.Range(0.0f, 65200.0f);
	}
	
	void Update()
	{
		float noise = Mathf.PerlinNoise(2f, Time.time);
		//GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
		this.GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);;
	}
}