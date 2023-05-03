using UnityEngine;
using System.Collections;

// https://codereview.stackexchange.com/questions/85319/rocket-controller-for-a-unity-game

public class Missile : MonoBehaviour 
{
    public float thrustMultiplier;
    public float rotationSpeed;
    private bool applyThrust = false;
    public AudioSource rocketFlyingSound; // component for the rocket flying sound

    void Start () { transform.forward = transform.up; }

    // function for destroying missile on collision
    void OnCollisionEnter(Collision collision){
        Destroy(this.gameObject);
    }

    // Check for misc keypresses
    void CheckMiscKeys ()
    {
        // Start applying thrust
        if (Input.GetKey (KeyCode.Space))
        {
            applyThrust = true;
        }

        // Stop applying thrust
        if (Input.GetKey (KeyCode.LeftShift))
        {
            applyThrust = false;
        }
    }

    // Check for rotation keypresses
    void CheckRotationKeys ()
    {
        // Rotate forward
        if (Input.GetKey (KeyCode.W))
        {
            transform.Rotate (rotationSpeed * new Vector3 (1, 0, 0));
        }

        // Rotate backwards
        if (Input.GetKey (KeyCode.S))
        {
            transform.Rotate (rotationSpeed * new Vector3 (-1, 0, 0));
        }

        // Rotate left
        // SAMUEL: I swapped the key from A to D to make the rotation uninverted
        // Original: if (Input.GetKey (KeyCode.A))
        if (Input.GetKey (KeyCode.D))
        {
            transform.Rotate (rotationSpeed * new Vector3 (0, -1, 0));
        }

        // Rotate right
        // SAMUEL: I swapped the key from D to A to make the rotation uninverted
        // Original: if (Input.GetKey (KeyCode.D)) 
        if (Input.GetKey (KeyCode.A))
        {
            transform.Rotate (rotationSpeed * new Vector3 (0, 1, 0));
        }
    }

    // Apply thrust to the rocket's rigidbody
    void ApplyRocketThrust ()
    {
        if (applyThrust)
        {
            Vector3 force = transform.forward * thrustMultiplier;
            GetComponent<Rigidbody>().AddForce(force);
        }
    }

    // Run physics calculations and misc events
    void FixedUpdate ()
    {
        CheckMiscKeys ();
        CheckRotationKeys ();
        ApplyRocketThrust ();

                // Condtional check if missile is moving, if true: play sound else stop
        if(GetComponent<Rigidbody>().velocity.magnitude > 0){
            if(!rocketFlyingSound.isPlaying){
                rocketFlyingSound.Play();
            }
        } else {
            rocketFlyingSound.Stop();
        }
    }
}