using UnityEngine;

public class spookyspider : MonoBehaviour
{
    private float speed = 3f;
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = player.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(player.position, transform.position) > 1.0f)
        {
            transform.position += (displacement * speed * Time.deltaTime);

        }
    }
}
