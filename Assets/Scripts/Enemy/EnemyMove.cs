using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public AudioClip hurtSound2;

     Transform player;
	 Transform TeslaSpotlight;
	 Transform baseCar;
	
	public float speed = 1.2f;
	//float angleSpread = 20;
	float enemyFreezeTime = 2f;

	// Distances and light	
	bool frozen = false;
	//bool playingSound = false;
	float distanceToPlayer;
	float distanceToCar;
	//Vector3 playerZRotation;
	//Vector3 enemyPosition;
	//Vector3 facing;

	bool ghoulDead = false;
	public GUIStyle mainFont;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Auron").transform;
		frozen = false;
        distanceToCar = 10;
        distanceToPlayer = 10;
		//TeslaSpotlight = GameObject.Find ("TeslaSpotlight").transform;
		baseCar = GameObject.Find ("baseCar").transform;

		InvokeRepeating ("checkDistances", 0, 1.0f);
	}
	

    void Attack()
    {
        Debug.Log("Calling ATTACK");
        this.GetComponent<Animator>().Play("Attack");
        Debug.Log("Distance to Player: " + distanceToPlayer);
        frozen = true;
        if (distanceToPlayer >= 2 && distanceToCar >= 2)
        {
            Debug.Log("Start Moving inside IF");
            this.GetComponent<Animator>().Play("walk");
            frozen = false;
        }
    }
	// Update is called once per frame
	void Update () {

        //Debug.Log("Distance to Player : " + distanceToPlayer);

       /* if(distanceToPlayer <= 1.5 || distanceToCar <= 1.5)
        {
             Debug.Log("IN ATTACK");
          
            //freezeEnemy();
            // this.GetComponent<Animator>().Play("Attack");

            InvokeRepeating("Attack", 0, 2.0f);

        }*/

		if (!frozen) {

			if (distanceToPlayer < distanceToCar) 
				{
					// Move towards player
					transform.LookAt(player.position, Vector3.up);
					transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
				}
		   		 else
					{
						transform.LookAt(baseCar.position, Vector3.up);
						transform.position = Vector3.MoveTowards (transform.position, baseCar.position, speed * Time.deltaTime);
					}
		}
	}

	void checkDistances(){
        Debug.Log("Still Calling");
		distanceToPlayer = (this.transform.position - player.position).sqrMagnitude;//Vector2.Distance (this.transform.position, player.transform.position);
		distanceToCar = (this.transform.position - baseCar.position).sqrMagnitude;//Vector2.Distance (this.transform.position, baseCar.transform.position);
		
		
	}
	
	/*void unfreezeEnemy () {
        if (distanceToPlayer >= 2 && distanceToCar >= 2)
        {
            frozen = false;

            Debug.Log("INSIDE IF CAN START MOVING");
            this.GetComponent<Animator>().Play("walk");
        }
	}

	public void freezeEnemy () {
		frozen = true;
		Invoke ("unfreezeEnemy", enemyFreezeTime);
	}*/

	public void killGhoul(){

		// Resource gain show
		ghoulDead = true;
		
		this.GetComponent<Animator> ().Play ("die");
		frozen = true;
		this.GetComponent<Rigidbody> ().Sleep ();
		//Destroy (gameObject, 24); //24 is length of death animation

		// Tell enemy manager this enemy died

	}

	public void removeEnemy(){
		Destroy (gameObject,0.3f);
	}

	void OnGUI () {
		if (ghoulDead) {
			Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
			//Debug.Log("target is " + screenPos.x + " pixels from the left");
		
			GUI.Label (new Rect (screenPos.x - 70, (Screen.height - screenPos.y) - 90, 100, 100), "+5%", mainFont);
		}
	}
}
