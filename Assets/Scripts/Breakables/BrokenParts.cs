using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrokenParts : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    private Vector3 movementDirection;

    [SerializeField] float haltingFactor = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementDirection.x = Random.Range(-moveSpeed, moveSpeed);
        movementDirection.y = Random.Range(-moveSpeed, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementDirection * Time.deltaTime;

        movementDirection = Vector3.Lerp(movementDirection, Vector3.zero, haltingFactor * Time.deltaTime);
    }
}
