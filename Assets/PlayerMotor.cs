using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D Rigidbody2D;
    public float speed = 10;
    public float jumpForce = 10;
    private bool canJump = true;
    private bool canDash = true;
    public float maxSpeed = 5;
    public float stoppingForce = 10;
    public float dashForce = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame (not anymore :)))
    private void FixedUpdate()
    {
        //transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
        HandlePlayerXMovement();
        MaxSpeedLimiting();
    }

    private void MaxSpeedLimiting()
    {
        if (!canDash)
        {
            return;
        }

        if (Rigidbody2D.linearVelocityX >= maxSpeed)
        {
            Rigidbody2D.linearVelocityX = maxSpeed;
        }
        else if (Rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            Rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    private void HandlePlayerXMovement()
    {
        if (direction.x != 0)
        {
            Rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
        }
        else if (direction.x != 0)
        {
            Rigidbody2D.AddForce(new Vector2(-Rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnDash()
    {
        if (canDash)
        {
            if(direction.x != 0)
            {
                Rigidbody2D.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
            }
            else
            {
                Rigidbody2D.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);
            }
            canDash = false;
            StartCoroutine(ResetDash(1));
        }
    }

    IEnumerator ResetDash (float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
