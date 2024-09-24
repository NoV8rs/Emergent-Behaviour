using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Collider2D agentCollider; // The collider of the agent, what we will use to detect other agents, it's not public because we don't want to expose it to the inspector
    public Collider2D AgentCollider { get { return agentCollider; } } // Property to get the collider of the agent, we use this to get the collider from the FlockBehavior script
    
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 velocity) // Move the agent, the Flocks
    {
        transform.up = velocity; // Rotate the agent to face the direction it's moving
        transform.position += (Vector3)velocity * Time.deltaTime; // Framerate independent movement
        
    }
}
