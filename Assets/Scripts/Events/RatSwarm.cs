using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSwarm : MonoBehaviour
{
    [SerializeField] private Transform Rats;
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;

    private bool rushActive = false;
    private bool reachedTarget = false;
    private Coroutine RatRushCorroutine;

    private void Awake()
    {
        Rats.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        RatRushEventTrigger.OnRatRush += OnRatRush;
    }

    private void OnDisable()
    {
        RatRushEventTrigger.OnRatRush -= OnRatRush;
    }

    void Update()
    {
        if (rushActive)
        {
            if (!reachedTarget)
            {
                Rats.position = Vector3.MoveTowards(Rats.position, target.position, speed * Time.deltaTime);

                if (Rats.position == target.position)
                {
                    reachedTarget = true;
                }
            }
            else
            {
                rushActive = false;
                Rats.gameObject.SetActive(false);
            } 
        }
    }

    private void OnRatRush()
    {
        Debug.Log("OnRatRush Event Occurred.");
        Rats.gameObject.SetActive(true);
        rushActive = true;
    }

}
