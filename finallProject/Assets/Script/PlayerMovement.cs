using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 500f;
    public float lateralForce = 15f;
    public float targetSpeed = 100f;
    public float maxLateralPos = 6f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ForwardMovement();
        LateralMovement();
    }

    void ForwardMovement(){
        // Get the current forward speed (z-axis component of velocity)
        float currentSpeed = rb.velocity.z;

        if (currentSpeed < targetSpeed)
        {
            rb.AddForce(Vector3.forward * forwardForce * Time.fixedDeltaTime, ForceMode.Force);
        }
        else if (currentSpeed > targetSpeed)
        {
            // Clamp the velocity to the target speed
            Vector3 clampedVelocity = rb.velocity;
            clampedVelocity.z = targetSpeed;
            rb.velocity = clampedVelocity;
        }
    }

    void LateralMovement(){
        float direction = Input.GetAxis("Horizontal");
        Vector3 lateralVelocity = rb.velocity;

        lateralVelocity.x = direction * lateralForce;
        rb.velocity = lateralVelocity;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxLateralPos, maxLateralPos);
        transform.position = clampedPosition;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Умираем (или останавливаем игрока)
            Die();
        }
    }

    private void Die()
    {
        // Останавливаем игрока
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;  // Останавливаем физику

        // Открываем меню Game Over
        GameStateManager.instance.ChangeToGameMenu();
    }
}
