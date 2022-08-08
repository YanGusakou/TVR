using UnityEngine;

public class Puck : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 70f;
    
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Start() 
    {
        ResetPuck();
    }

    public void ResetPuck()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);
    }
    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = 0f;

        this.rigidbody.AddForce(force.normalized * this.speed);
    }


     private void OnCollisionEnter2D(Collision2D collision) {
         
     }
}
