using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] float disappearTime = 5f;
    [SerializeField] int scoreValue = 10;

    bool isDead;
    bool isDisapeparing;


    void Awake()
    {
        currentHealth = startingHealth;
        isDead = false;
    }

    public bool IsDead()
    {
        return isDead;
    }
    void Update()
    {
        if (isDisapeparing)
        {
        //    transform.Translate(-Vector3.up * disappearTime * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(int amount )
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
       //     Death();
        }
    }
    void Death()
    {
        isDead = true;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Animator>().SetTrigger("die");
        GetComponent<ActionScheduler>().CancelAction();
        Disappear();
    }

    public void Disappear()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isDisapeparing = true;
        Destroy(gameObject,disappearTime);
    }
}
