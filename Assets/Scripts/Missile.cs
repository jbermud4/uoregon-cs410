using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

// https://codereview.stackexchange.com/questions/85319/rocket-controller-for-a-unity-game

public class Missile : MonoBehaviour 
{
    public float thrustMultiplier;
    public float rotationSpeed;
    private bool applyThrust = false;
    private Vector3 startingPosition;
    private Quaternion startingRotation;
    public AudioSource rocketFlyingSound; // component for the rocket flying sound
    public AudioSource collisionExplosion;
    //public AudioSource WinSound;
    public int damage = 1;
    public int health;
    private int healthMax;
    public ParticleSystem exhaustParticles;
    public ParticleSystem impactParticles;
    public MeshDisable mesh;
    public Rigidbody rb;

    public CameraShake cameraShake;

    public int scoreNeeded;             //Managing score
    private int scoreLeft = 0;
    public TextMeshProUGUI scoreText;
    //private EnemyScript enemyScript;

    public TextMeshProUGUI winText;
    

    
    void Start () { 
        // EDIT: I took this out since it was doing weird things with the starting camera position
        //transform.forward = transform.up;
        // rb = GetComponent<Rigidbody>();
        startingPosition = transform.position; // get position on start
        startingRotation = transform.rotation; // get the rotation on start
        scoreLeft = scoreNeeded;
        scoreText.text = "Enemies left: " + scoreLeft.ToString();
        healthMax = health;
    }

    public void respawn()
    {
        // make missile visible again and stop explosion particles
        mesh.meshEnable(true);
        impactParticles.Stop();
        rb.detectCollisions = true;
        
        transform.position = startingPosition;
        transform.rotation = startingRotation;
        // slows it down after moving to starting point
        applyThrust = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        health = healthMax;
    }

    // function for moving missile to starting point on collision
    void OnCollisionEnter(Collision collision){ //For hitting walls.
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Debug.Log("Hit Enemy or Arrow");
            return;
            
        }
        else
        {
            Debug.Log("Hit not enemy or arrow");
            collisionExplosion.Play();
            respawn();
        }
    }

    private void OnTriggerEnter(Collider other) //For hitting the enemy.
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            collisionExplosion.Play();

            // make missile invisible and play explosion particles.
            mesh.meshEnable(false);
            rb.detectCollisions = false;

            // we stop missile from going crazy movement after collision
            applyThrust = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            impactParticles.transform.position = transform.position;
            StartCoroutine(cameraShake.Shake(1.5f, 0.3f));
            impactParticles.Play();
            
            // wait 2 seconds before respawning
            Invoke("respawn", 2);
        }
    }

    IEnumerator EndingWin()
    {
        Time.timeScale = 0f;
        winText.text = "You Win!";
        //WinSound.Play();
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Score(int value)
    {
        scoreLeft -= value;
        scoreText.text = "Enemies left: " + scoreLeft.ToString();
        if (scoreLeft <= 0)
        {
            scoreText.text = "Enemies left: 0!";
            StartCoroutine(EndingWin());
        }
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
        // TODO: Switch rotation from Euler angles to quaternions?
        // Rotate forward
        if (Input.GetKey (KeyCode.W))
        {
            transform.Rotate (rotationSpeed * new Vector3 (-1, 0, 0));
        }

        // Rotate backwards
        if (Input.GetKey (KeyCode.S))
        {
            transform.Rotate (rotationSpeed * new Vector3 (1, 0, 0));
        }

        // Rotate left
        // SAMUEL: I swapped the key from A to D to make the rotation uninverted
        // Original: if (Input.GetKey (KeyCode.A))
        if (Input.GetKey (KeyCode.D))
        {
            transform.Rotate (rotationSpeed * new Vector3 (0, 1, 0));
        }

        // Rotate right
        // SAMUEL: I swapped the key from D to A to make the rotation uninverted
        // Original: if (Input.GetKey (KeyCode.D)) 
        if (Input.GetKey (KeyCode.A))
        {
            transform.Rotate (rotationSpeed * new Vector3 (0, -1, 0));
        }

        // Roll left
        if (Input.GetKey (KeyCode.Q))
        {
            transform.Rotate(rotationSpeed * new Vector3(0, 0, 1));
        }

        // Roll right
        if (Input.GetKey (KeyCode.E))
        {
            transform.Rotate(rotationSpeed * new Vector3(0, 0, -1));
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
        if(applyThrust == true){
            if(!rocketFlyingSound.isPlaying){
                rocketFlyingSound.Play();
            }
            if(!exhaustParticles.isPlaying) {
                exhaustParticles.Play();
            }
        } else {
            rocketFlyingSound.Stop();
            exhaustParticles.Stop();
        }
    }
}