using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    private Rigidbody Rb;
    public Vector3 velocity;
    private Vector3 playerPos;

    private Vector3 seperation;
    private Vector3 cohesion;
    public float seperationDistance = 100f;
    public float cohesionRadius = 20;
    private Collider[] boids;
    private int seperationCount;
    private Vector3 alignment;
    private float maxSpeed = 15f;
    private int layerMask = 1 << 11;
    public float rotateSpeed = 50;
    public float forceFieldSize = 10;

    private float lastCohesion;

    public bool Attacking;
    private bool cohesionActive;
    private bool seperationActive;
    private bool alignmentActive;
    private bool rotating;
    private bool IncreasingForceField;
    private bool spasOut;
    public bool PerformFunction;
    public bool goBack;

    public Dictionary<Boid, Vector3> takenVelocity = new Dictionary<Boid, Vector3>();

    private void Start()
    {
        cohesionRadius = 20;
        Rb = GetComponent<Rigidbody>();
        //Player = GameObject.Find("[CameraRig]");
        PerformFunction = true;
        InvokeRepeating("CalculateVelocity", 0, 1f);
        //Invoke("CalculateVelocity", 1f);
    }
    void CalculateVelocity()
    {
        if(PerformFunction)
        {
            velocity = Vector3.zero;
            cohesion = Vector3.zero;
            seperation = Vector3.zero;
            seperationCount = 0;
            alignment = Vector3.zero;

            boids = Physics.OverlapSphere(transform.position, cohesionRadius, layerMask);

            foreach (Collider boid in boids)
            {
                cohesion += boid.transform.position;
                alignment += boid.GetComponent<Boid>().velocity;
                if (boid != GetComponent<SphereCollider>() && (transform.position - boid.transform.position).magnitude < seperationDistance)
                {
                    seperation += (transform.position - boid.transform.position) / (transform.position - boid.transform.position).magnitude;
                    seperationCount++;
                }
            }
            cohesion /= boids.Length;
            cohesion -= transform.position;
            cohesion = Vector3.ClampMagnitude(cohesion, maxSpeed);
            if (seperationCount > 0)
            {
                seperation /= seperationCount;
                seperation = Vector3.ClampMagnitude(seperation, maxSpeed);
            }
            alignment /= boids.Length;
            alignment = Vector3.ClampMagnitude(alignment, maxSpeed);

            //if(Attacking == true)
            //{
            //    //velocity = playerPos.normalized + cohesion + seperation * 10 + alignment * 1.5f; 
            //}
            //else
            //{
            //    velocity += cohesion + seperation * 10 + alignment * 1.5f;
            //}
            velocity += cohesion + seperation * 10 + alignment * 1.5f;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }      
    }

    private void Update()
    {
        if (cohesionRadius <= 0)
        {
            cohesionRadius = 0;
        }
        playerPos = Player.transform.position;
        Vector3 pos = transform.position;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cohesionActive = !cohesionActive;
        }
        if (cohesionActive == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                cohesionRadius -= 25 * Time.deltaTime;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                cohesionRadius += 25 * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            seperationActive = !seperationActive;
        }
        if (seperationActive == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                seperationDistance -= 25 * Time.deltaTime;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                seperationDistance += 25 * Time.deltaTime;
            }
        }
        else
        {
            //seperationDistance = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //lastCohesion = cohesionRadius;
            Attacking = !Attacking;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PerformFunction = !PerformFunction;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            rotating = !rotating;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            IncreasingForceField = !IncreasingForceField;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            spasOut = !spasOut;
        }
        if (IncreasingForceField == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                forceFieldSize -= 25 * Time.deltaTime;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                forceFieldSize += 25 * Time.deltaTime;
            }
        }
        if (rotating == true)
        {
            bool around = true;
            bool with = false;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                around = !around;
                with = !with;
            }
            if (around == true)
            {
                transform.RotateAround(playerPos, Vector3.up, rotateSpeed * Time.deltaTime);
            }
            if (with == true)
            {
                transform.RotateAround(Vector3.zero, playerPos, rotateSpeed * Time.deltaTime);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                rotateSpeed -= 100 * Time.deltaTime;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                rotateSpeed += 100 * Time.deltaTime;
            }
        }
        if (goBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position.normalized, 25 * Time.deltaTime);
        }
        if (Attacking == false)
        {
            //cohesionRadius = lastCohesion;
            if (transform.position.magnitude > 25)
            {
                velocity += -transform.position.normalized;
            }
        }
        else
        {
            cohesionRadius = 1;
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position + (transform.position - Player.transform.position).normalized * forceFieldSize, 25 * Time.deltaTime);
            //transform.position = Player.transform.position + (transform.position - Player.transform.position).normalized * forceFieldSize;
            transform.RotateAround(playerPos, Vector3.up, 30 * Time.deltaTime);
            //Vector3 location = (pos - transform.position).normalized * 25;
            //transform.position = Vector3.MoveTowards(transform.position, pos, 25 * Time.deltaTime);
            //Rb.velocity = location;
        }

        if (spasOut == true)
        {
            transform.position += velocity + playerPos * Time.deltaTime;
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
        }

        //Debug.DrawRay(transform.position, seperation, Color.green);
        //Debug.DrawRay(transform.position, cohesion, Color.magenta);
        //Debug.DrawRay(transform.position, alignment, Color.blue);
    }
}
