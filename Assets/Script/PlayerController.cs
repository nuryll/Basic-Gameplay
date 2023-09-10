using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public float minZ = -1f;         // Minimum Z position the player can move to
    public float maxZ = 10f;          // Maximum Z position the player can move to

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Calculate movement based on player input (typically W and S keys or up and down arrow keys)
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Compute the new position
        float newZ = transform.position.z + moveZ;

        // Ensure the new position is within the specified range
        newZ = Mathf.Clamp(newZ, minZ, maxZ);

        // Update player position
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
