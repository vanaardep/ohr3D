using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConstructionProgressBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Image image = GetComponent<Image>();
		image.fillAmount = Mathf.MoveTowards(image.fillAmount, 1f, Time.deltaTime * .2f);
	}
}
