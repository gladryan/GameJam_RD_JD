using UnityEngine;
using UnityEngine.UI;

public class gobby : MonoBehaviour
{
    Vector3 startpos;
    private float speed = 15f;
    public Transform player;
    private int health = 1;
    public GameObject enemy;
    public Image star;
    public Sprite spiderStar;
    public Sprite mask;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(enemy);
            player.GetComponent<PlayerController>().uses = 2;
            player.GetComponent<PlayerController>().abilitySelector = 3;
            player.GetComponent<PlayerController>().maskRenderer.sprite = mask;
            star.sprite = spiderStar;
            
        }
        Vector3 displacement = player.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(player.position, transform.position) > 1.0f)
        {
            transform.position += (displacement * speed * Time.deltaTime);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = startpos;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health -= 1;
        }
    }
}
