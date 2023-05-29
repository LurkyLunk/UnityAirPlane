using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float pitchRate = 2f; // Adjust the pitch rate as needed
    public float liftCoefficient = 0.1f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get input from arrow keys or WASD for movement
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Apply forward movement
        Vector3 forwardMovement = transform.forward * speed * moveVertical * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMovement);

        // Apply rotation
        float rotation = moveHorizontal * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Calculate pitch based on pitch rate
        float pitch = moveVertical * pitchRate * Time.deltaTime;
        Quaternion pitchRotation = Quaternion.Euler(-pitch, 0f, 0f);
        rb.MoveRotation(rb.rotation * pitchRotation);

        // Calculate lift based on speed and angle of attack
        float angleOfAttack = Vector3.Dot(rb.velocity.normalized, transform.forward);
        Vector3 liftForce = Vector3.up * liftCoefficient * angleOfAttack * speed * speed;

        // Apply lift force
        rb.AddForce(liftForce, ForceMode.Force);
    }
}


