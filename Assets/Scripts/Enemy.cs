using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        // If hit by a projectile
        if (other.CompareTag("Projectile"))
        {
            FindObjectOfType<ScoreManager>().AddScore(5);
            Destroy(other.gameObject);   // destroy projectile
            Destroy(gameObject);         // destroy enemy
            return; // stop here so it doesn't also check player
        }

        // If hit by the player
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Destroy enemy if it goes off screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
