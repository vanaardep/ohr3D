using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for

		//OWN rules
		public Transform player;
		public Transform baseCar;
		float distanceToPlayer;
		float distanceToCar;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;

	        agent.updatePosition = true;

			player = GameObject.Find ("Auron").transform;
			baseCar = GameObject.Find ("baseCar").transform;
			target = player;
			InvokeRepeating ("checkDistances", 0, 1.0f);
        }


        // Update is called once per frame
        private void Update()
        {

            if (target != null)
            {
				if (distanceToPlayer < distanceToCar) 
				{
					target = player;
				}
				else
				{
					target = baseCar;
				}
                agent.SetDestination(target.position);

				
				
                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);
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

		void checkDistances(){

			distanceToPlayer = (this.transform.position - player.position).sqrMagnitude;//Vector2.Distance (this.transform.position, player.transform.position);
			distanceToCar = (this.transform.position - baseCar.position).sqrMagnitude;//Vector2.Distance (this.transform.position, baseCar.transform.position);
		}
    }
}
