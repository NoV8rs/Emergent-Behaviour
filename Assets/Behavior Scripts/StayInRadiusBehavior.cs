using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")] // Create a menu for the Stay In Radius behavior]
public class StayInRadiusBehavior : FlockBehavior
{
    public Vector2 center; // The center of the radius
    public float radius = 15f; // The radius of the circle
    
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) // Calculate the move of the agent
    {
        Vector2 centerOffset = center - (Vector2)agent.transform.position; // The center offset is the center minus the position of the agent
        float t = centerOffset.magnitude / radius; // The t is the magnitude of the center offset divided by the radius
        
        if (t < 0.9f) // If t is less than 0.9
        {
            return Vector2.zero; // Return no adjustment
        }
        
        return centerOffset * t * t; // Return the center offset multiplied by t squared
    }
}
