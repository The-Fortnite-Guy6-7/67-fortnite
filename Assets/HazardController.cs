using UnityEngine;

public class HazardController : MonoBehaviour
{
    public float damageAmount = 10f; // Amount of damage dealt by the hazard
    public string playerTag = "Player"; // Tag used to identify the player object

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the specified player tag
        if (other.CompareTag(playerTag))
        {
            // Try to get the PlayerHealth component from the colliding object
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // If the PlayerHealth component exists, apply damage
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log($"Player took {damageAmount} damage from {gameObject.name}");
            }
        }
    }

    // You might also use OnTriggerStay for hazards that deal damage over time
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Example: Deal damage over time
                playerHealth.TakeDamage(damageAmount * Time.deltaTime); 
            }
        }
    }
    */
}