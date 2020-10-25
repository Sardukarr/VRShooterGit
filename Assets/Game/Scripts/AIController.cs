﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour, IAction
{

    [SerializeField] float TimeBetweenAttacks = 2.0f;
    [SerializeField] float Range = 2.0f;
    [SerializeField] Health target = null;
    private float TimeSinceLastAttack = 0f;
   // private Health target = null;
    private ActionScheduler actionScheduler = null;
    private Mover mover = null;
    //TODO:: animation has to be for comercial use
    private Animator animator = null;

    private void Awake()
    {
        actionScheduler = GetComponent<ActionScheduler>();
        mover = GetComponent<Mover>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        actionScheduler.StartAction(this);
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceLastAttack += Time.deltaTime;
        if (!CanAttack()) return;

        if (IsInRange())
        {
            AttackBehavior();
            mover.Cancel();
        }
        else
        {
              mover.MoveTo(target.transform.position, 1f);
          //  mover.MoveWithinRange(target.transform.position, 2f);
        }
    }
    public void Attack(GameObject combatTarget)
    {
        actionScheduler.StartAction(this);
        target = combatTarget.GetComponent<Health>();

    }

    private void AttackBehavior()
    {
        Vector3 lookAt = target.transform.position;
        lookAt.y = 0;
        transform.LookAt(lookAt);
        if (TimeSinceLastAttack >= TimeBetweenAttacks && !target.IsDead())
        {
            animator.ResetTrigger("stopAttack");
            animator.SetTrigger("attack");
            //  animator.speed = currentWeapon.GetAnimationSpeed();
            TimeSinceLastAttack = 0f;
        }
    }
    public void Cancel()
    {
        animator.SetTrigger("stopAttack");
        mover.Cancel();
        target = null;
    }
    public bool CanAttack()
    {
        return target != null && !target.IsDead();
    }
    private bool IsInRange()
    {
        return target != null && (Vector3.Distance(transform.position, target.transform.position) <= Range);
    }
}