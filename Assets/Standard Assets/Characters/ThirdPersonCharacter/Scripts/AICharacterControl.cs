using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        Transform target; // target to aim for

        //OWN rules
        public Transform player;
        public Transform baseCar;
        float distanceToPlayer;
        float distanceToCar;

        bool frozen = false;

        bool ghoulDead = false;
        public GUIStyle mainFont;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            frozen = false;

            ghoulDead = false;

            agent.updatePosition = true;

            player = GameObject.Find("Auron").transform;
            baseCar = GameObject.Find("baseCar").transform;
            target = player;
            InvokeRepeating("checkDistances", 0, 1.0f);
        }

        void Attack()
        {
            //Debug.Log("Calling ATTACK");
            this.GetComponent<Animator>().Play("Attack");

            if (distanceToCar <= 3)
            {
                //this.GetComponent<Animator>().Play("die");
                this.GetComponent<Animator>().Play("die");
                Destroy(this.gameObject, 1f);

            }
            frozen = true;
            if (distanceToPlayer >= 2.1 && distanceToCar >= 3.5)
            {
                CancelInvoke("Attack");
                this.GetComponent<Animator>().Play("walk");
                frozen = false;
            }
        }
        // Update is called once per frame
        private void Update()
        {
            // Debug.Log("DISTNCE : " + distanceToPlayer);

            if (distanceToPlayer <= 1.5 || distanceToCar <= 3)
            {
                InvokeRepeating("Attack", 0, 1.0f);

            }

            if (target != null)
            {
                if (!frozen)
                {
                    //Debug.Log("Inside not frozen");
                    if (distanceToPlayer < distanceToCar)
                    {
                        target = player;
                    }
                    else
                    {
                        target = baseCar;
                    }

                    agent.SetDestination(target.position);
                    character.Move(agent.desiredVelocity, false, false);
                }


            }
            else
            {
                // We still need to call the character's move function, but we send zeroed input as the move param.
                character.Move(Vector3.zero, false, false);
            }

        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        void checkDistances()
        {
            //Debug.Log("Calling check Distances");
            distanceToPlayer = (this.transform.position - player.position).sqrMagnitude;//Vector2.Distance (this.transform.position, player.transform.position);
            distanceToCar = (this.transform.position - baseCar.position).sqrMagnitude;//Vector2.Distance (this.transform.position, baseCar.transform.position);
        }

        public void killGhoul()
        {

            // Resource gain show
            Debug.Log("INSIDE KILL GHOUL");

            ghoulDead = true;

            this.GetComponent<Animator>().Play("die");
            frozen = true;
            this.GetComponent<Rigidbody>().Sleep();

        }

        public void removeEnemy()
        {
            Destroy(gameObject, 0.3f);
        }

        void OnGUI()
        {
            if (ghoulDead)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                //Debug.Log("target is " + screenPos.x + " pixels from the left");

                GUI.Label(new Rect(screenPos.x - 70, (Screen.height - screenPos.y) - 90, 100, 100), "+5%", mainFont);
            }
        }

    }
}
