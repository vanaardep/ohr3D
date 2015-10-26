using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class BulletDetection : MonoBehaviour
    {
        // Use this for initialization
        AICharacterControl aiCharacterControl;
        public int timeDelay = 2;
        public int bulletLifetime = 5;
        void Start()
        {
            Destroy(gameObject, bulletLifetime);
        }

        // Update is called once per frame
        void Update()
        {
            /*timeDelay -= Time.deltaTime;
            if (timeDelay < 0) {
                PlayerGUI.batteryPerc --;
                timeDelay = 2;
            }*/

        }

        //Bullet collision
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                PlayerGUI.batteryPerc += 5;
                EnemyManager.enemyKillCount--;
                ((AICharacterControl)col.gameObject.GetComponent(typeof(AICharacterControl))).killGhoul();
                // Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
