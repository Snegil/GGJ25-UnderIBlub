using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] int hazardDamage;
    [SerializeField] int healAmount = 5;
    private Health health;
    void Start()
    {
       health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OxygenPickUp"))
        {
            Destroy(collision.gameObject);
            health.Heal(healAmount);
        }
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            health.TakeDamage(hazardDamage);
        }
    }
}
