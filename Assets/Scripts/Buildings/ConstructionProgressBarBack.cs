using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConstructionProgressBarBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Image image = GetComponent<Image>();
		image.color = Color.gray;
		image.fillAmount = 1f;
	}
}
