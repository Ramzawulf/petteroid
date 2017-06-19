using Helpers.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PetBehaviour : Singleton<PetBehaviour>
{

    public string PetName;
    public float Age;
    public float MaxHealth;
    public float CurrentHealth;
    public float MaxHunger;
    public float CurrentHunger;
    public float MaxHappiness;
    public float CurrentHappiness;
    public float MaxEnergy;
    public float CurrentEnergy;
    private NavMeshAgent agent;
    private Animator anim;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        CurrentHealth -= Time.deltaTime;
        CurrentHunger -= Time.deltaTime;
        CurrentHappiness -= Time.deltaTime;
        CurrentEnergy -= Time.deltaTime;
        anim.SetFloat("Speed", agent.velocity.magnitude);
        print(agent.velocity.magnitude);
    }

    public void Play()
    {
        CurrentHappiness += 2;
    }

    public void MoveTo(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void InteractWith(IInteractable target)
    {
        StopCoroutine(_InteractWith(target));
        StartCoroutine(_InteractWith(target));
    }

    private IEnumerator _InteractWith(IInteractable target)
    {
        agent.SetDestination(target.Destination);
        while (true)
        {
            //Reached Destination
            if (agent.remainingDistance < 0.1f)
            {
                yield return null;
                target.Interact();
                break;
            }
        }
    }

    public void Sleep()
    {
        CurrentEnergy += 5;
    }

    public void Eat()
    {
        CurrentHunger += 2;
    }

}
