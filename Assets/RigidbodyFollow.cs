using UnityEngine;

public class RigidbodyFollow : MonoBehaviour
{

    [SerializeField] private float radius = 5f; // the radius in which objects float around the player
    [SerializeField] private float height = 3f; // the height at which objects float around the player
    [SerializeField] private float rotationSpeed = 10f; // the speed at which objects rotate in the air
    [SerializeField] private LayerMask layerMask; // the layer mask that determines which objects should be affected
    
    private Transform playerTransform; // the player's transform
    
    private void Start()
    {
        playerTransform = transform; // get the player's transform
    }

    private void FixedUpdate()
    {
        // find all objects within the radius that are on the specified layer
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position, radius, layerMask);

        foreach (Collider collider in colliders)
        {
            // check if the object is not tagged as "Player"
            if (!collider.CompareTag("Player"))
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    // make the object float at the specified height
                    Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + height, playerTransform.position.z);
                    rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, Time.fixedDeltaTime));

                    // make the object rotate in the air
                    rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * rotationSpeed * Time.fixedDeltaTime));
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // draw a wire sphere around the player to visualize the radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}


