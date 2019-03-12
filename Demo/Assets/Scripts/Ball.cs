using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed;
    
    private Rigidbody _rigidbody;
    
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate() {
        if (Random.value < 0.01f) {
            _rigidbody.AddForce(new Vector3(
                Random.Range(-speed, speed),
                0,
                Random.Range(-speed, speed)
            ));
        }
    }
}