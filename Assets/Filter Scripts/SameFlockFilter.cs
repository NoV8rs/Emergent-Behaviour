using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")] // Create a menu for the Same Flock filter
public class SameFlockFilter : ContextFilter // Same Flock filter class
{
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original) // Filter the context
    {
        List<Transform> filtered = new List<Transform>(); // The filtered context
        foreach (Transform item in original) // Loop through the original context
        {
            FlockAgent itemAgent = item.GetComponent<FlockAgent>(); // Get the flock agent of the item
            if (itemAgent != null && itemAgent.AgentFlock == agent.AgentFlock) // If the item has a flock agent and the item's flock is the same as the agent's flock
            {
                filtered.Add(item); // Add the item to the filtered context
            }
        }
        return filtered; // Return the filtered context
    }
}
