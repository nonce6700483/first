using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public enum DIRECTION
    {
        STOP,
        RIGHT,
        LEFT,
    }

    DIRECTION direction = DIRECTION.STOP;
    [SerializeField] Rigidbody2D rigidbody2D;
    float _speed;
    float _jumpPower = 300;

    // Update is called once per frame
    void Update()
    {
        var _x_val = Input.GetAxis("Horizontal");

        if (_x_val == 0)
        {
            direction = DIRECTION.STOP;
        }
        else if (_x_val > 0)
        {
            direction = DIRECTION.RIGHT;
        }
        else if (_x_val < 0)
        {
            direction = DIRECTION.LEFT;
        }

        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION.STOP:
                _speed = 0;
                break;
            case DIRECTION.RIGHT:
                _speed = 3;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case DIRECTION.LEFT:
                _speed = -3;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        rigidbody2D.velocity = new Vector2(_speed, rigidbody2D.velocity.y);
    }
    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * _jumpPower);
    }
}
