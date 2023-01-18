using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class KeyValuePair
{
    public string key;
    public string val;
}

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] Waypoints wPoints;

    public List<KeyValuePair> stateList = new List<KeyValuePair>();
    private Dictionary<string, string> playerState = new Dictionary<string, string>();

    private Animator animator;
    private string currentState;

    // Waypoints
    private int waypointIndex;
    private Vector2 lastDirection;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        MapListToDict(stateList);
    }

    private void FixedUpdate()
    {
        Transform currentWaypoint = wPoints.waypoints[waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, walkSpeed * Time.deltaTime);
        Vector3 direction = (currentWaypoint.position - transform.position).normalized;

        if (direction.x != 0 || direction.y != 0)
        {
            lastDirection = direction;
            UpdateMovingDirection(direction);
        }

        if (Vector2.Distance(transform.position, currentWaypoint.position) == 0)
        {
            if (waypointIndex < wPoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                UpdateIdleDirection(lastDirection);
            }
        }
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);
        currentState = newState;
    }

    private void MapListToDict(List<KeyValuePair> state)
    {
        foreach (var kvp in stateList)
        {
            playerState[kvp.key] = kvp.val;
        }
    }

    private void UpdateMovingDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            ChangeAnimationState(playerState["Move_Right"]);
        }
        else if (direction.x < 0)
        {
            ChangeAnimationState(playerState["Move_Left"]);
        }
        else if (direction.y > 0)
        {
            ChangeAnimationState(playerState["Move_Back"]);
        }
        else if (direction.y < 0)
        {
            ChangeAnimationState(playerState["Move_Front"]);
        }
    }

    private void UpdateIdleDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            ChangeAnimationState(playerState["Idle_Right"]);
        }
        else if (direction.x < 0)
        {
            ChangeAnimationState(playerState["Idle_Left"]);
        }
        else if (direction.y > 0)
        {
            ChangeAnimationState(playerState["Idle_Back"]);
        }
        else if (direction.y < 0)
        {
            ChangeAnimationState(playerState["Idle_Front"]);
        }
    }
}