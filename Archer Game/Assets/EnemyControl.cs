using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;  // Reference to the main character's transform
    public float speed = 5f;  // Speed at which the enemy moves towards the main character
    private float currentHealth = 100f;
    private float decreaseRate = 25f;
    void Start()
    {
        InvokeRepeating("DecreaseHealth", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        // Ensure there is a valid target assigned
        if (target == null)
        {
            Debug.LogWarning("No target assigned to the enemy!");
            return;
        }

        // Calculate the direction towards the target
        Vector3 direction = target.position - transform.position;
        direction.y = 0f;  // Optional: Ignore the y-axis for movement in a 2D environment

        // Move the enemy towards the target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Rotate the enemy to face the target
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10f * Time.deltaTime);


    }

    private void DecreaseHealth()
    {
        currentHealth -= decreaseRate;
        if (currentHealth <= 0f)
        {
            Destroy(gameObject); // Remove the enemy from the game
        }
    }
}
