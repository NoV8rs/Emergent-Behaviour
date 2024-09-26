using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")] // Create a menu for the Alignment behavior
public class AlignmentBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) // Calculate the move of the agent
    {
        // If there are no neighbors, maintain current alignment
        if (context.Count == 0) // If there are no neighbors
        {
            return agent.transform.up; // Return the current alignment
        }

        // Add all points together and average
        Vector2 alignmentMove = Vector2.zero; // The alignment move
        foreach (Transform item in context) // Loop through the context
        {
            alignmentMove += (Vector2)item.transform.up; // Add the up vector of the item to the alignment move
        }
        alignmentMove /= context.Count; // Divide the alignment move by the number of items in the context

        return alignmentMove; // Return the alignment move
    }
}
