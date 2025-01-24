using UnityEngine;
using UnityEngine.UI;

public class DistanceLighting : MonoBehaviour
{
    Image image;
    GameObject player;

    [SerializeField] GameObject top;
    [SerializeField] GameObject bottom;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        image = GetComponent<Image>();
    }

    
    void Update()
    {
        float levelLength = Mathf.Abs(top.transform.position.y - bottom.transform.position.y);
        float playerPosition = Mathf.Abs(player.transform.position.y - top.transform.position.y);

        float playerPositionPercentage = playerPosition / levelLength;

        image.color = new Color(image.color.r, image.color.g, image.color.b, playerPositionPercentage);


    }
}
