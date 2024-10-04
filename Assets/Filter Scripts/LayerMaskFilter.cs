using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Layer Mask")] // Create a menu for the Layer Mask filter
public class LayerMaskFilter : ContextFilter
{
    public LayerMask mask; // The layer mask
    
    public override List<Transform> Filter(FlockAgent agent, List<Transform> original) // Filter the context
    {
        List<Transform> filtered = new List<Transform>(); // The filtered context
        foreach (Transform item in original) // Loop through the original context
        {
            if (mask == (mask | (1 << item.gameObject.layer))) // If the mask is the same as the item's layer
            {
                filtered.Add(item); // Add the item to the filtered context
            }
        }
        return filtered; // Return the filtered context
    }
}
