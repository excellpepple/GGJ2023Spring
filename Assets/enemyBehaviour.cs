using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public float speed = 3f;
    public float direction1 = 1f;
    public float range = 6f;
    public bool stop = false;
    public float jumpForce = 5.0f;
    public float moveBackForce = 3.0f;

   // public Transform target;



    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Collision detected! -> we hit {other.gameObject.tag}");
          
            stop = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Collision detected with -> we hit{collision.gameObject.tag}");   
        }
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()

    {
       // Vector3 targetPosition = target.position;
       // Vector3 direction = Vector3.Lerp(transform.position,targetPosition,speed);

      //  transform.position = direction;
        if (stop)
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //GetComponent<Rigidbody>().AddForce(Vector3.down * moveBackForce, ForceMode.Impulse);
            
            stop = false;
            
        }
        transform.position += new Vector3(direction1 * speed * Time.deltaTime,0, 0);

        if (transform.position.x >= range || transform.position.x <= -range)
        {
            direction1 *= -1f;
        }

    }
}
