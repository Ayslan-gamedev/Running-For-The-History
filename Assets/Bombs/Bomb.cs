using UnityEngine;

public class Bomb : MonoBehaviour {

    private GameObject playerObject;

    [SerializeField] private protected Vector2 force;

    private void Start() {
        playerObject = GameObject.Find("Player");
    }

    private void Update() {
        if (transform.position.y < -6) Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        float playerDistance = playerObject.transform.position.x - transform.position.x;

        if (!collision.CompareTag("Bomb")) {
            if (playerDistance < 2.5 && playerDistance > -2.5 && playerObject.transform.position.y <= transform.position.y) {
                playerObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                playerObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force.x, force.y), ForceMode2D.Impulse);
                playerObject.GetComponent<PlayerMove>().LifeManager(-30);
            }
        }
        if (collision.CompareTag("Player")) {

        } else {
            
        }
    }
}