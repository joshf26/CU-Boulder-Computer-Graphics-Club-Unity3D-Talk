using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    public GameObject explosion;
    
    private Rigidbody _rigidbody;
    
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        var moveHorizontal = Input.GetAxis ("Horizontal");
        var moveVertical = Input.GetAxis ("Vertical");

        var movement = new Vector3 (moveHorizontal, 0, moveVertical);

        _rigidbody.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.parent && collision.transform.parent.name == "Arena") return;

        var collisionLocalScale = collision.transform.localScale;

        GameObject explosionObject;
        if (transform.localScale.x > collisionLocalScale.x) {
            transform.localScale += collisionLocalScale/4;
            
            explosionObject = Instantiate(explosion, collision.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(collision.gameObject);
        }
        else {
            explosionObject = Instantiate(explosion, transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }

        explosionObject.transform.localScale = collisionLocalScale;
    }
}
