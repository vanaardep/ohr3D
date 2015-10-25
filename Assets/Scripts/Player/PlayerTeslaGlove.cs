using UnityEngine;
using System.Collections;

public class PlayerTeslaGlove : MonoBehaviour
{

    public bool gloveActive;
    public AudioClip shootSound1;
    public AudioClip shootSound2;
    public AudioClip shootSound3;
    public AudioClip shootSound4;
    private int cooldown;
    public float bulletSpeed = 30f;
    Vector3 direction;

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
    public GameInputManager gameInputScript;

    // Use this for initialization
    void Start()
    {
        gameInputScript = gameObject.GetComponent<GameInputManager>();
        //this.GetComponent<Light> ().intensity = 0;
        gloveActive = false;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown (gameInputScript.teslaKey)) {
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		}

        if (Input.GetKeyUp(gameInputScript.teslaKey)) {
            
			Cursor.SetCursor(null, Vector2.zero, cursorMode);

            if (cooldown == 0 && gloveActive == false)
            {
                //tesla shot creation
                Vector3 playerPosition = GameObject.Find("Auron").transform.position;
                GameObject thisObject = Instantiate(Resources.Load("bulletPrefab"), playerPosition, Quaternion.identity) as GameObject;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    direction = hit.point - playerPosition;
                    Debug.Log(hit.point);
                }
                Debug.Log(ray.direction);

                thisObject.transform.Translate(direction * 0.1f);
                thisObject.transform.LookAt(direction);
                //Debug.Log(direction);
                //bulletSpeed = bulletSpeed * 0.8f;
                thisObject.GetComponent<Rigidbody>().AddForce(direction * 0.3f *bulletSpeed);
                thisObject.GetComponent<Rigidbody>().AddForce(transform.up * 300);
                SoundManager.instance.PlayPlayerShootAudio(shootSound1, shootSound2, shootSound3, shootSound4);
                gloveActive = true;
                cooldown = 5;
                Invoke("disabletTesla", 2);
            }
        }
        else
        {
            //this.GetComponent<Light> ().intensity = 0;
            gloveActive = false;

        }
    }

    void disabletTesla()
    {
        //this.GetComponent<Light> ().intensity = 0;
        gloveActive = false;

        InvokeRepeating("coolDownDec", 0, 1f);
    }

    void coolDownDec()
    {
        if (cooldown > 0)
        {
            cooldown--;
        }
        else
        {
            CancelInvoke("coolDownDec");
        }
    }
}
