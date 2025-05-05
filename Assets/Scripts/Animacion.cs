using Unity.VisualScripting;
using UnityEngine;

public class Animacion : MonoBehaviour
{
    public static Animacion singleton;
    public State state = State.idle;
    public float movSpeed;
    public float jmpForce;

    public enum State
    {
        idle,//0
        walk,//1
        jump//2
    }

    public Rigidbody2D body;

    Vector2 direction;

    void Start()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Debug.Log($"State: {state}");
        switch (state)
        {
            case State.idle:
                Onidle();
                break;
            case State.walk:
                Onwalk();
                break;
            case State.jump:
                Onjump();
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "plataform")
        {
            state = State.walk;
        }
    }
    void Onwalk()
    {
        if (!HorizontalMove())
        {
            state = State.idle;
        }
        if (jump())
        {
            state = State.jump;
        }
        transform.Translate(direction * Time.deltaTime);
    }

    void Onidle()
    {
        if (HorizontalMove())
        {
            state = State.walk;
        }
        if (jump())
        {
            state = State.jump;
        }
    }

    void Onjump()
    {
        if (HorizontalMove())
        {
            transform.Translate(direction * Time.deltaTime);
        }
    }

    bool HorizontalMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            return true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            return true;
        }
        return false;
    }

    bool jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            body.AddForceY(jmpForce);
            return true;
        }
        return false;
    }

}
