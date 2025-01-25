using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] GameObject pauseScreen;
    bool isPaused;
    

    void Start()
    {
        pauseScreen.SetActive(false);
        isPaused = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseScreen.SetActive(isPaused);

            if (isPaused == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

    }

}
