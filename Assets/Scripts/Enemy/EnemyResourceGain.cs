using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyResourceGain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Image image = GetComponent<Image>();
		//image.fillAmount = 1f;
		//image.fillAmount = Mathf.MoveTowards(image.fillAmount, 1f, Time.deltaTime * .2f);
	}

	public void showResource(){
		Image image = GetComponent<Image>();
		image.fillAmount = 1f;

	}
}
