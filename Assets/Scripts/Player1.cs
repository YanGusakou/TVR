using UnityEngine;

public class Player1 : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 60f;
    //public float maxBoundsAngle = 75f;
    
    private void Awake() 
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.direction = Vector2.up;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            this.direction = Vector2.down;
        }
        else
        {
            this.direction = Vector2.zero;
        }
    }

    private void Start()
    {
        ResetPlayer1();
    }
    
    
    private void FixedUpdate() 
    {
        if(this.direction != Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction * this.speed);
        }
    }

    public void ResetPlayer1()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = new Vector2(-6.5f, 0f);
    }

    //    private void OnCollisionEnter2D(Collision2D collision) 
    // {
    //     Puck puck = collision.gameObject.GetComponent<Puck>();

    //     if(puck != null)
    //     {
    //         Vector3 player1Position = this.transform.position;
    //         Vector2 contactPoint = collision.GetContact(0).point;

    //         float offset = player1Position.x - contactPoint.x;
    //         float width = collision.otherCollider.bounds.size.x / 2;

    //         float currentAngle = Vector2.SignedAngle(Vector2.right, puck.rigidbody.velocity);
    //         float boundsAngle = (offset / width) * this.maxBoundsAngle;
    //         float newAngle = Mathf.Clamp(currentAngle + boundsAngle, -this.maxBoundsAngle, this.maxBoundsAngle);

    //         Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
    //         puck.rigidbody.velocity = rotation * Vector2.right * puck.rigidbody.velocity.magnitude;
    //     }
    // }
}
