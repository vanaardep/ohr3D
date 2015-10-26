using UnityEngine;
using System.Collections;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class LightTurretAttack : MonoBehaviour
    {

        AICharacterControl aiCharacterControl;
        private float fireStart = 0f;
        public float PowerUsageDelay = 2;
        public float fireCooldown = 5f; // 5cd of turret

        private float fireAnimStart = 0f;
        private float fireAnimCooldown = 1f; // 1 second light pulse animation
        GameObject thisObj;
        public SoundManagerLightTurret lightTurretAttackSoundObj;
        public AudioClip lightTurretAttackSound;


        void Start()
        {
            thisObj = this.gameObject;
            PowerUsageDelay = 3;
            fireCooldown = 5f;
            fireAnimStart = 0f;
            fireAnimCooldown = 1f;
            lightTurretAttackSoundObj = thisObj.GetComponent<SoundManagerLightTurret>();
        }

        void Update()
        {

            PowerUsageDelay -= Time.deltaTime;
            if (PowerUsageDelay < 0 && PlayerGUI.batteryPerc != 0)
            {
                PlayerGUI.batteryPerc--;
                PowerUsageDelay = 3;
            }


            if (Time.time > fireAnimStart + fireAnimCooldown)
            {
                fireAnimStart = Time.time;
                this.GetComponentInChildren<Light>().intensity = 0;
            }
        }

        void OnCollisionStay(Collision col)
        {
            if ((col.gameObject.tag == "Enemy") && (Time.time > fireStart + fireCooldown) && (PlayerGUI.batteryPerc > 0))
            {
                fireStart = Time.time;
                //Debug.Log("LIGHTTURRET ATTACKKKKKKKKKKKKKKKK");
                lightTurretAttackSoundObj.instance.PlayLightTurretAttack(lightTurretAttackSound);
                EnemyManager.enemyKillCount--;
                PlayerGUI.batteryPerc += 5;
                //Destroy(col.gameObject);
                ((AICharacterControl)col.gameObject.GetComponent(typeof(AICharacterControl))).killGhoul();
                this.GetComponentInChildren<Light>().intensity = 8;
            }

        }
    }
		
}
