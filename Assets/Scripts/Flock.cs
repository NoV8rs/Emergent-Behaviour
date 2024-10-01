using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab; // The prefab of the agent
    List<FlockAgent> agents = new List<FlockAgent>(); // List of agents
    public FlockBehavior behavior; // The behavior of the flock
    
    [Range(10, 750)] // Range of the number of agents
    public int startingCount = 250; // The number of agents
    const float agentDensity = 0.08f; // The density of the agents
    
    [Range(1f, 100f)] // Range of the distance of the agents
    public int driveFactor = 10; // The distance of the agents

    [Range(1f, 100f)] // Range of the maximum speed of the agents
    public int maxSpeed = 5; // The maximum speed of the agents
    
    [Range(1f, 10f)] // Range of the neighbor radius of the agents
    public float neighborRadius = 1.5f; // The neighbor radius of the agents, major fps drop if too high, IMPORTANT!.
    [Range(0f, 1f)] // Range of the avoidance radius of the agents
    public float avoidanceRadiusMultiplier = 0.5f; // The avoidance radius of the agents

    float squareMaxSpeed; // The square of the maximum speed
    float squareNeighborRadius; // The square of the neighbor radius
    float squareAvoidanceRadius; // The square of the avoidance radius
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } } // The square of the avoidance radius
    
    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed; // The square of the maximum speed
        squareNeighborRadius = neighborRadius * neighborRadius; // The square of the neighbor radius
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier; // The square of the avoidance radius
        
        for (int i = 0; i < startingCount; i++) // Loop through the number of agents
        {
            FlockAgent newAgent = Instantiate( // Create a new agent
                agentPrefab, // The prefab of the agent
                UnityEngine.Random.insideUnitSphere * startingCount * agentDensity, // The position of the agent
                Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0f, 360f)), // The rotation of the agent
                transform); // The parent of the agent
            newAgent.name = "Agent " + i; // The name of the agent
            newAgent.Initialize(this); // Initialize the agent
            agents.Add(newAgent); // Add the agent to the list of agents
        }   
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents) // Loop through the agents
        {
            var (context, obstacles) = GetNearbyObjects(agent); // Get the nearby objects
            Vector2 move = behavior.CalculateMove(agent, context, this); // Calculate the move of the agent
            move *= driveFactor; // Multiply the move by the drive factor
            if (move.sqrMagnitude > squareMaxSpeed) // If the square magnitude of the move is greater than the square of the maximum speed
            {
                move = move.normalized * maxSpeed; // Normalize the move and multiply it by the maximum speed
            }
            agent.Move(move); // Move the agent
        }
    }
    
    private (List<Transform>, List<Transform>) GetNearbyObjects(FlockAgent flockAgent) // if you want to do something with the "alien" objects, return a tuple
    {
        var context = new List<Transform>();
        var obstacles = new List<Transform>();
        var contextColliders = Physics2D.OverlapCircleAll(flockAgent.transform.position, neighborRadius);

        foreach (var collider in contextColliders)
        {
            if (collider == flockAgent.AgentCollider)
                continue;

            if (collider.transform.parent == transform)
            {
                context.Add(collider.transform);
            }
            else if (!CompareTag(collider.tag)) // tag them by type (predatorFlock, obstacles, etc) in the editor
            {
                obstacles.Add(collider.transform);
            }
        }

        return (context, obstacles);
    }
}
