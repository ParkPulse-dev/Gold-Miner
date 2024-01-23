using UnityEngine;
using UnityEngine.UI;

public class HookSwing : MonoBehaviour
{
    public float swingSpeed = 40f;  // Adjust the speed of the swing
    public float maxSwingAngle = 180f;  // Adjust the maximum swing angle
    public float forwardSpeed = 5f;  // Adjust the forward movement speed
    public float maxForwardDistance = 10f;  // Adjust the maximum forward distance
    private float currentSwingAngle = 230f;
    private bool isSwingingForward = false;  // Start with the hook swinging backward
    private bool isMovingForward = false;
    private Vector3 initialPosition;
    private GameObject hookedObject;

    private ScoreAdder scoreManager;  // Reference to the ScoreManager script

    void Start()
    {
        // Store the initial position for returning after forward movement
        initialPosition = transform.position;
    }

    void Update()
    {
        // Check if the player pressed the "space" key to start forward movement
        if (Input.GetKeyDown(KeyCode.Space) && !isMovingForward)
        {
            // Stop the swing and move forward
            isMovingForward = true;
            isSwingingForward = false;
        }

        if (isMovingForward)
        {
            HandleForwardMovement();
        }
        else
        {
            // Update the swing angle based on the current direction
            currentSwingAngle += (isSwingingForward ? 1 : -1) * swingSpeed * Time.deltaTime;

            // Check if the maximum swing angle is reached, and change direction if necessary
            if ((Mathf.Abs(currentSwingAngle - 240f) >= maxSwingAngle) || (currentSwingAngle >= 230.01))
            {
                isSwingingForward = !isSwingingForward;
            }
            // Apply rotation to the hook object
            transform.rotation = Quaternion.Euler(0f, 0f, currentSwingAngle);
        }
    }

    void HandleForwardMovement()
    {
        // Implement forward movement logic here
        transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime);

        // Check if the forward movement distance exceeds the limit
        if ((Vector3.Distance(initialPosition, transform.position) >= maxForwardDistance))
        {
            // Reset the position to the initial position
            transform.position = initialPosition;
            isMovingForward = false;
        }
    }
}
