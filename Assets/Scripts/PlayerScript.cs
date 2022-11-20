using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float speed = 10f;
    public float padding = 0.8f;
    float minX;
    float maxX;
    float minY;
    float maxY;

    // Start is called before the first frame update
    void Start()
    {
        FindBoundaries();
    }

    // clamping player b/w the boundaries
    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        // moving player using Input Manager
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXPos, newYPos);
    }
}
