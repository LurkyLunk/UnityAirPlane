using UnityEngine;
using System.Collections;

public class AirplaneTakeoff : MonoBehaviour
{
    public float takeoffSpeed = 10f;
    public float takeoffHeight = 50f;

    private Rigidbody rb;
    private bool isTakingOff = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTakingOff)
        {
            isTakingOff = true;
            StartCoroutine(TakeoffRoutine());
        }
    }

    private IEnumerator TakeoffRoutine()
    {
        while (transform.position.y < takeoffHeight)
        {
            Vector3 takeoffMovement = transform.forward * takeoffSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + takeoffMovement);
            yield return null;
        }

        isTakingOff = false;
    }
}
