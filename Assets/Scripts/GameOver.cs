using UnityEngine;

public class GameOver : MonoBehaviour
{

    Health health;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        
    }
}
