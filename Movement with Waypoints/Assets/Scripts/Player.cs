using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed = 4f;

    private Animator animator;
    private string currentState;

    // Waypoints
    private Waypoints wPoints;
    private int waypointIndex;
    private Vector2 lastDirection;

    private void Awake()
    {
        wPoints = FindObjectOfType<Waypoints>();
        animator = gameObject.GetComponent<Animator>();
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

    private void UpdateMovingDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            ChangeAnimationState(PlayerState.MoveRight);
        }
        else if (direction.x < 0)
        {
            ChangeAnimationState(PlayerState.MoveLeft);
        }
        else if (direction.y > 0)
        {
            ChangeAnimationState(PlayerState.MoveBack);
        }
        else if (direction.y < 0)
        {
            ChangeAnimationState(PlayerState.MoveFront);
        }
    }

    private void UpdateIdleDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            ChangeAnimationState(PlayerState.IdleRight);
        }
        else if (direction.x < 0)
        {
            ChangeAnimationState(PlayerState.IdleLeft);
        }
        else if (direction.y > 0)
        {
            ChangeAnimationState(PlayerState.IdleBack);
        }
        else if (direction.y < 0)
        {
            ChangeAnimationState(PlayerState.IdleFront);
        }
    }
}

public static class PlayerState
{
    public const string MoveLeft = "Player_Move_Left";
    public const string MoveRight = "Player_Move_Right";
    public const string MoveBack = "Player_Move_Back";
    public const string MoveFront = "Player_Move_Front";
    public const string IdleLeft = "Player_Idle_Left";
    public const string IdleRight = "Player_Idle_Right";
    public const string IdleBack = "Player_Idle_Back";
    public const string IdleFront = "Player_Idle_Front";
}
