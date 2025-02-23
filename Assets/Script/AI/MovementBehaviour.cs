using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "movement", menuName = "behaviour/movement")]
public class MovementBehaviour : BasicBehaviour {

    public float speed;
    public float senseRange;
    private NavMeshAgent navMeshAgent;

    public override void OnStart(GameObject self, Transform destinationParent) {
        base.OnStart(self, destinationParent);
        navMeshAgent = self.GetComponent<NavMeshAgent>(); // get the navmesh agent
        navMeshAgent.speed = speed; // set the navmesh agent speed to the enemy speed
        if (navMeshAgent == null) { // if the agent is null
            Debug.Log("The NavMeshAgent is not atached to " + self.name); // let the console know the enemy is missing a navmesh.
        }
    }

    public override void OnUpdate(GameObject self) {
        navMeshAgent = self.GetComponent<NavMeshAgent>(); // get the navmesh agent
        if (navMeshAgent != null) { // and the agent is not null
            SetDestination(navMeshAgent, self); // set the destination of the navmesh
        }
    }

    private void SetDestination(NavMeshAgent navMeshAgent, GameObject self) {
        // TODO: SET THE DESTINATION TO A WEIGHTED RANDOM NODE
        if (Vector3.Distance(navMeshAgent.transform.position, navMeshAgent.destination) < 1f)
        {
            navMeshAgent.SetDestination(destinationParent.GetChild(GenerateWeightedRandomTransformIndex()).position);
        }
    }

    public int GenerateWeightedRandomTransformIndex()
    {
        // List to store weights based on distance
        List<float> weights = new List<float>();

        // Calculate weights based on distance from targetTransform
        for (int i = 0; i < destinationParent.childCount; i++)
        {
            Transform transform = destinationParent.GetChild(i);
            float distance = Vector3.Distance(transform.position, navMeshAgent.destination);

            // Invert the distance to make closer transforms less likely
            float weight = 1f / distance;

            weights.Add(weight);
        }

        // Use the GenerateWeightedRandomIndex method with the calculated weights
        return GenerateWeightedRandomIndex(weights);
    }

    // Method to generate a weighted random index
    private int GenerateWeightedRandomIndex(List<float> weights)
    {
        // Total weight sum
        float totalWeight = 0;

        // Calculate total weight sum
        foreach (float weight in weights)
        {
            totalWeight += weight;
        }

        // Generate a random number between 0 and totalWeight
        float randomNum = Random.Range(0f, totalWeight);

        // Iterate through weights to find the corresponding index
        for (int i = 0; i < weights.Count; i++)
        {
            // Subtract current weight from random number
            randomNum -= weights[i];

            // If random number is less than or equal to 0, return current index
            if (randomNum <= 0)
            {
                return i;
            }
        }

        // In case of failure, return -1
        return -1;
    }

}
