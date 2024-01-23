using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component spawns the given object whenever the player presses the space key.
 */
public class ClickSpawner : MonoBehaviour
{
    [SerializeField] protected InputAction spawnAction;
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected float speed = 5f;

    void OnEnable()
    {
        // Create a new InputAction for the space key
        spawnAction = new InputAction(binding: "<Keyboard>/space", type: InputActionType.Button);

        // Enable the InputAction
        spawnAction.Enable();
    }

    void OnDisable()
    {
        // Disable the InputAction
        spawnAction.Disable();
    }

private bool hasSpawned = false;  // Flag to track if the object has been spawned

protected virtual GameObject SpawnObject()
{
    if (hasSpawned)
    {
        // If it has already spawned, do nothing
        return null;
    }

    Debug.Log("Spawning a new object");

    // Step 1: spawn the new object.
    GameObject newObject = Instantiate(prefabToSpawn);

    // Step 2: set the local position and rotation of the new object to match its parent.
    newObject.transform.SetParent(transform);  // Set the parent first
    newObject.transform.localPosition = Vector3.zero;  // Set local position to zero
    newObject.transform.localRotation = Quaternion.identity;  // Set local rotation to identity

    Vector3 localScale = newObject.transform.localScale;
    // Step 3: flip the object on the Y-axis by scaling it negatively.
    newObject.transform.localScale = new Vector3(localScale.x, localScale.y * -1f, localScale.z);  // Flip on the Y-axis

    // Step 4: calculate the velocity based on the spawned object's rotation.
    Vector3 velocity = newObject.transform.right * speed;  // Use transform.right for Z rotation

    // Step 5: modify the velocity of the new object.
    Mover newObjectMover = newObject.GetComponent<Mover>();
    if (newObjectMover)
    {
        newObjectMover.SetVelocity(velocity);
    }

    // Set the flag to true after spawning
    hasSpawned = true;

    return newObject;
}

    private void Update()
    {
        if (spawnAction.triggered)
        {
            SpawnObject();
        }
    }
}
