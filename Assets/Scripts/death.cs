using UnityEngine;

public class death : MonoBehaviour
{
    public GameObject player;
    Vector2 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            player.transform.position = startPos;
        }
    }



}
