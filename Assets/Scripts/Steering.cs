using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Seek,
    Flee,
    Keyboard,
    Pursuit,
    Evade,
    Wander,
    Path
}
public class Steering : MonoBehaviour
{
    public State state;
    //vehicle settings
    public float mass = 70f;
    public float maxForce = 5f / 3.6f;
    public float maxSpeed = 5f / 3.6f;
    public float stopDistance = 1f;
    public float lookAheadTime = 1f;
    public float wanderAngle = 15;
    public float wanderNoiseAngle = 15;
    public float wanderCircleDistance = 2f;
    public float wanderCircleRadius = 2f;
    public float avoidanceDistance = 2f;
    public float maxAvoidanceForce = 2f;
    private int currentPath = 0;

    //vehicle runtime steering behaviour
    private Vector3 position;
    public Vector3 velocity;
    private Vector3 velocityDesired;
    private Vector3 steering;

    //runtime specific
    private Vector3 directionTarget;
    private Vector3 positionTarget;
    private Vector3 requestedDirection;
    public GameObject target;
    public GameObject[] Path;
    public Transform bulletEmitter;

    private bool returnPath = false;
    private float gizmoScale = 2f;
    private CharacterController characterController;
    // Start is called before the first frame update
    private void OnDrawGizmosSelected()
    {
        if (state == State.Wander)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(position + velocity.normalized * wanderCircleDistance, wanderCircleRadius);
            Gizmos.DrawLine(transform.position, position + velocity.normalized * wanderCircleDistance);
        }
    }
    void Start()
    {
        if (transform.childCount > 0)
        {
            bulletEmitter = transform.GetChild(0);
        }
        position = transform.position;
        velocity = new Vector3(0f, 0f, 0f);

        if (state == State.Keyboard)
        {
            target = null;
        }
        else
        {
            if (target == null)
            {
                target = GameObject.Find("Player");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        directionTarget = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        bool still_moving = directionTarget != Vector3.zero;

        if (still_moving)
        {
            positionTarget = position + directionTarget * maxSpeed;
        }
        else
        {
            positionTarget = position;
        }
        if (currentPath == Path.Length)
        {
            currentPath--;
            returnPath = true;
        }
        if (returnPath)
        {
            if (currentPath <= 0)
            {
                returnPath = false;
            }
        }
    }
    private void FixedUpdate()
    {
        DoSteering(Time.fixedDeltaTime);
        transform.position = new Vector3(position.x, position.y, position.z);
        //if(bulletEmitter != null && target != null)
        //{
        //    bulletEmitter.LookAt(target.transform);
        //}

        Debug.DrawRay(transform.position, gizmoScale * velocity, Color.red);
        Debug.DrawRay(transform.position, gizmoScale * velocityDesired, Color.blue);
        Debug.DrawLine(transform.position, positionTarget, Color.magenta);
        //velocityDesired = Vector3.Normalize(positionTarget - position) * maxSpeed;
        //
        //steering = velocityDesired - velocity;
        //steering = Vector3.ClampMagnitude(steering, maxForce);
        //steering = steering / mass;
        //
        //velocity = Vector3.ClampMagnitude(velocity + steering, maxSpeed);
        //position += velocity * Time.fixedDeltaTime;
        //
        //transform.position = position;

        //Debug.DrawRay(transform.position, gizmoScale * velocity, Color.red);
        //Debug.DrawRay(transform.position, gizmoScale * velocityDesired, Color.blue);
        //
        //switch(state)
        //{
        //    case State.Seek:
        //        velocityDesired = player.position * maxSpeed;
        //        steering = velocity - velocity;
        //        break;
        //    case State.Flee:
        //
        //        break;
        //}
    }
    private void DoSteering(float dT)
    {
        Vector3 targetPos = CalculateTargetPosition(dT);

        bool slowDownAtArrival = (state == State.Seek || state == State.Pursuit);
        bool moveAwayFromTarget = (state == State.Flee || state == State.Evade);

        float _maxSpeed = maxSpeed;
        if (slowDownAtArrival)
        {
            float distanceToTarget = (target.transform.position - transform.position).magnitude - stopDistance;
            float decelerationTime = velocity.magnitude / maxForce;
            _maxSpeed = Mathf.Min(distanceToTarget / decelerationTime, maxSpeed);
        }

        DoLocomotion(targetPos, _maxSpeed, moveAwayFromTarget, dT);
    }
    private Vector3 CalculateTargetPosition(float dT)
    {
        Vector3 targetPos;
        switch (state)
        {
            case State.Seek:
                targetPos = target.transform.position;
                break;
            case State.Flee:
                targetPos = target.transform.position;
                break;
            case State.Pursuit:
                targetPos = target.transform.position + requestedDirection * lookAheadTime + ObstacleAvoidance();
                break;
            case State.Evade:
                targetPos = target.transform.position + requestedDirection * lookAheadTime;
                break;
            case State.Wander:
                targetPos = DoWander(dT) + requestedDirection * lookAheadTime + ObstacleAvoidance();
                break;
            case State.Keyboard:
                targetPos = DoKeyboard(dT);
                break;
            case State.Path:
                targetPos = DoPath(dT);
                break;

            default:
                targetPos = DoKeyboard(dT);
                break;
        }
        return targetPos;
    }
    private Vector3 DoPath(float dT)
    {
        float distance = Vector3.Distance(transform.position, Path[currentPath].transform.position);
        Vector3 targetPos = Path[currentPath].transform.position;
        if (distance <= 0.1f)
        {
            if (!returnPath)
            {
                currentPath++;
            }
            else if (returnPath)
            {
                currentPath--;
            }
        }

        return targetPos;
    }
    private Vector3 ObstacleAvoidance()
    {
        const int OBSTACLE_LAYER = 1 << 9;
        RaycastHit rayHit;
        bool hitFound = false;
        Vector3 sensorPosition;

        if (Physics.Raycast(position, velocity, out rayHit, avoidanceDistance, OBSTACLE_LAYER, QueryTriggerInteraction.Ignore))
        {
            hitFound = true;
            
            sensorPosition = position + velocity.normalized * avoidanceDistance;
            
            Vector3 velocityDesired = (sensorPosition - rayHit.collider.transform.position).normalized * maxAvoidanceForce;
            positionTarget = sensorPosition + velocityDesired;
            return velocityDesired - velocity;
            //return velocity = -velocity;
        }
        else
            return Vector3.zero;

    }
    private void DoLocomotion(Vector3 targetPosition, float maxSpeed, bool moveAwayFromTarget, float dT)
    {
        //I'll remember target position 
        positionTarget = targetPosition;

        velocityDesired = (targetPosition - position).normalized * maxSpeed;
        if (moveAwayFromTarget)
        {
            velocityDesired = -velocityDesired;
        }

        steering = velocityDesired - velocity;
        steering += ObstacleAvoidance();
        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, maxSpeed);
        position += velocity * dT;
    }
    private Vector3 DoWander(float dT)
    {
        wanderAngle += Random.Range(-0.5f * wanderNoiseAngle * Mathf.Deg2Rad,
                                     0.5f * wanderNoiseAngle * Mathf.Deg2Rad);

        Vector3 centerOfCircle = position + velocity.normalized * wanderCircleDistance;

        Vector3 offset = new Vector3(wanderCircleRadius * Mathf.Cos(wanderAngle), wanderCircleRadius * Mathf.Cos(wanderAngle), wanderCircleRadius * Mathf.Sin(wanderAngle));

        return centerOfCircle + offset;
    }
    private Vector3 DoKeyboard(float dT)
    {
        requestedDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (requestedDirection != Vector3.zero)
        {
            return position + requestedDirection * maxSpeed;
        }
        else
        {
            return position;
        }
    }
}
