using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float windForce = 10.0f;
    [SerializeField] private KeyCode windButton = KeyCode.Space;

    void Update()
    {
        // Check if wind button is pressed
        if (Input.GetKeyDown(windButton))
        {
            // Find all colliders in scene
            Collider[] colliders = FindObjectsOfType<Collider>();

            // Iterate through all colliders and apply wind force to objects with a rigidbody
            foreach (Collider collider in colliders)
            {
                Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    // Calculate direction from wind source to object and apply wind force
                    Vector3 direction = rigidbody.transform.position - transform.position;
                    rigidbody.AddForce(direction.normalized * windForce, ForceMode.Impulse);
                }
            }
        }
    }
}
