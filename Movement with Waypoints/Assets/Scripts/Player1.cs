using UnityEngine;

public class Player1 : MonoBehaviour
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
            ChangeAnimationState(Player1State.MoveRight);
        }
        else if (direction.x < 0)
        {
            ChangeAnimationState(Player1State.MoveLeft);
        }
        else if (direction.y > 0)
        {
            ChangeAnimationState(Player1State.MoveBack);
        }
        else if (direction.y < 0)
        {
            ChangeAnimationState(Player1State.MoveFront);
        }
    }

    private void UpdateIdleDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            ChangeAnimationState(Player1State.IdleRight);
        }
        else if (direction.x < 0)
        {
            ChangeAnimationState(Player1State.IdleLeft);
        }
        else if (direction.y > 0)
        {
            ChangeAnimationState(Player1State.IdleBack);
        }
        else if (direction.y < 0)
        {
            ChangeAnimationState(Player1State.IdleFront);
        }
    }
}

public static class Player1State
{
    public const string MoveLeft = "Player1_Move_Left";
    public const string MoveRight = "Player1_Move_Right";
    public const string MoveBack = "Player1_Move_Back";
    public const string MoveFront = "Player1_Move_Front";
    public const string IdleLeft = "Player1_Idle_Left";
    public const string IdleRight = "Player1_Idle_Right";
    public const string IdleBack = "Player1_Idle_Back";
    public const string IdleFront = "Player1_Idle_Front";
}
