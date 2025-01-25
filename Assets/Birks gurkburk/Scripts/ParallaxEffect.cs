using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxEffect : MonoBehaviour
{
    private float startPosX, startPosY, length, height;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceX = cam.transform.position.x * parallaxEffect;
        float distanceY = cam.transform.position.y * parallaxEffect;
        float movementX = cam.transform.position.x * (1 - parallaxEffect);
        float movementY = cam.transform.position.y * (1 - parallaxEffect);
        transform.position = new Vector3(startPosX + distanceX, startPosY + distanceY, transform.position.z);
        if (movementX > startPosX + length && movementY > startPosY + height)
        {
            startPosX += length;
            startPosY += height;
        }
        else if (movementX < startPosX - length && movementY < startPosY - height)
        {
            startPosX -= length;
            startPosY -= height;
        }
    }
}
