using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Steered Cohesion")] // Create a menu for the Steered Cohesion behavior
public class SteeredCohesionBehavior : FilteredFlockBehavior // Using Flock Behavior
{
    // Testing IMPORTANT, could just add the 3 lines at the bottom to CohesionBehavior and not have this script
    Vector2 currentVelocity; // The current velocity
    public float agentSmoothTime = 0.5f; // The agent smooth time
    
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) // Calculate the move of the agent
    {
        // If there are no neighbors, return no adjustment
        if (context.Count == 0) // If there are no neighbors
        {
            return Vector2.zero; // Return no adjustment
        }

        // Add all points together and average
        Vector2 cohesionMove = Vector2.zero; // The cohesion move
        foreach (Transform item in context) // Loop through the context
        {
            cohesionMove += (Vector2)item.position; // Add the position of the item to the cohesion move
        }
        cohesionMove /= context.Count; // Divide the cohesion move by the number of items in the context

        // Create offset from agent position, Testing IMPORTANT, could just add the 3 lines at the bottom to CohesionBehavior and not have this script
        cohesionMove -= (Vector2)agent.transform.position; // Subtract the position of the agent from the cohesion move

        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime); // Smooth the cohesion move, using the current velocity and the agent smooth time, to make the movement more natural

        return cohesionMove; // Return the cohesion move
    }
}
