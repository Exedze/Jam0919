using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Vector3 delta;
    public Vector3 prevcord;

    [SerializeField]
    private Rigidbody2D body;

    private Vector2 playerMoveTrack;

    private float speed=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

     void Update()
        {
    delta = transform.position - prevcord;
                body.AddForce(playerMoveTrack * Time.deltaTime*speed*100);
                /*transform.up = (Vector2) Vector3.Slerp(transform.up, playerMoveTrack, 2 * Time.deltaTime);
                velocity += playerMoveTrack.magnitude * Time.deltaTime;
                velocity -= velocity * brakingForce * Time.deltaTime;*/
            
    
            
            if (delta.magnitude > 0.001f)
            {
                transform.up = Vector3.Slerp(transform.up, transform.position - prevcord, 0.9f);
            }
    
            // transform.position+=transform.up*Time.deltaTime*velocity*speed;
       prevcord = transform.position;
        }
    
        private void OnMove(InputValue value)
        {
            playerMoveTrack = value.Get<Vector2>();
        }
}
