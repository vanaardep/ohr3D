using UnityEngine;
using System.Collections;

public class RemoveBuilding : MonoBehaviour {

	private Color startcolor;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("CHANGE COLOR");

		//startcolor = rend.material.color;
		//rend.material.color = Color.yellow;

		Destroy(this.gameObject);
	}
	void OnMouseExit()
	{
		//rend.material.color = startcolor;
	}
}
