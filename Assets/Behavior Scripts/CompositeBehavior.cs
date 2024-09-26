using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")] // Create a menu for the Composite behavior
public class CompositeBehavior : FlockBehavior
{
    public FlockBehavior[] behaviors; // The behaviors to composite
    public float[] weights; // The weights of the behaviors

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (weights.Length != behaviors.Length) // If the number of weights does not equal the number of behaviors
        {
            Debug.LogError("Data mismatch in " + name, this); // Log an error
            return Vector2.zero; // Return no adjustment
        }
        
        Vector2 move = Vector2.zero; // Move vector
        
        for (int i = 0; i < behaviors.Length; i++) // Loop through the behaviors
        {
            Vector2 partialMove = behaviors[i].CalculateMove(agent, context, flock) * weights[i]; // Calculate the partial move
            if (partialMove != Vector2.zero) // If the partial move is not zero
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i]) // If the square magnitude of the partial move is greater than the square of the weight
                {
                    partialMove.Normalize(); // Normalize the partial move
                    partialMove *= weights[i]; // Multiply the partial move by the weight
                }
                move += partialMove; // Add the partial move to the move
            }
        }
    }
}
