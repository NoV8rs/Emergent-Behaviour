using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")] // Create a menu for the Avoidance behavior
public class AvoidanceBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) // Calculate the move of the agent
    {
        // If there are no neighbors, return no adjustment
        if (context.Count == 0) // If there are no neighbors
        {
            return Vector2.zero; // Return no adjustment
        }

        // Add all points together and average
        Vector2 avoidanceMove = Vector2.zero; // The avoidance move
        int nAvoid = 0; // The number of neighbors to avoid
        foreach (Transform item in context) // Loop through the context
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius) // If the square magnitude of the position of the item minus the position of the agent is less than the square avoidance radius
            {
                nAvoid++; // Increment the number of neighbors to avoid
                avoidanceMove += (Vector2)(agent.transform.position - item.position); // Add the position of the agent minus the position of the item to the avoidance move
            }
        }
        if (nAvoid > 0) // If there are neighbors to avoid
        {
            avoidanceMove /= nAvoid; // Divide the avoidance move by the number of neighbors to avoid
        }

        return avoidanceMove; // Return the avoidance move
    }
}
