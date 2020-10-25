using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour, IAction
{
    [SerializeField] float maxSpeed = 6f;
    NavMeshAgent myAgent;
    ActionScheduler actionScheduler;
    Health myHealth;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        actionScheduler = GetComponent<ActionScheduler>();
        myHealth = GetComponent<Health>();
    }
    void Update()
    {
        myAgent.enabled = !myHealth.IsDead();
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = myAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
    public void StartMoveAction(Vector3 destination, float speedFraction)
    {
        actionScheduler.StartAction(this);
       
    }

    public void MoveTo(Vector3 destination, float speedFraction)
    {
        myAgent.isStopped = false;
        myAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
        //destination.y = 0;
        myAgent.destination = destination;
    }
   public void MoveAwayFrom(Vector3 destination, float speedFraction)
    {
        myAgent.isStopped = false;
        myAgent.speed = -maxSpeed * Mathf.Clamp01(speedFraction);
        //destination.y = 0;
        Vector3 newDestination = transform.position - destination;
        newDestination.Normalize();

        myAgent.destination = newDestination;
    }
    public void MoveWithinRange(Vector3 destination, float distance)
    {
        myAgent.SetDestination(destination);
        actionScheduler.StartAction(this);
        var remainingDistance = Vector3.Distance(transform.position, destination);
        if (remainingDistance <= distance)
        {
            actionScheduler.CancelAction();
        }
        else
        {
            myAgent.isStopped = false;
        }
    }

    public void Cancel()
    {
        myAgent.isStopped = true;
    }

    private void FootL()
    {
        //basicly a stepo meter
        // print("footl");
    }
    private void FootR()
    {
        //  print("footr");
    }
}