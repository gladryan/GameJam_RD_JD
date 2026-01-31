using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class realspider : MonoBehaviour
{
    private float speed = 5;
    Vector3 direction = new Vector3(0, 1, 0);
    private bool canMove = true;
    private int health = 3;
    public GameObject enemy;
    public GameObject player;
    public Image star;
    public Sprite spiderStar;

    IEnumerator WaitOnHit() {
        yield return new WaitForSeconds(2f);
        direction.y *= -1;
        canMove = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(enemy);
            player.GetComponent<PlayerController>().uses = 2;
            player.GetComponent<PlayerController>().abilitySelector = 1;
            star.sprite = spiderStar;
        }
        if (canMove) {
            transform.position += (direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Ground"))
        {
            canMove = false;
            StartCoroutine(WaitOnHit());
        }      
    }
}
