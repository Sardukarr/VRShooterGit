using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;
    int currentHealth;
    [SerializeField] float disappearTime = 5f;
    [SerializeField] int scoreValue = 10;
    [SerializeField] bool IsEnviroment = true;

    [SerializeField] UnityEvent onDie;

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

    public int getCurrentHP()
    {
        return currentHealth;
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
            //TODO player death
          //  Death();
        }
    }
    void Death()
    {
        isDead = true;
        onDie.Invoke();

        if (!IsEnviroment)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelAction();
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            UIManager.ScorePoints(scoreValue);
        }

        Disappear();
    }

    public void Disappear()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        isDisapeparing = true;
        Destroy(gameObject,disappearTime);
    }
}
