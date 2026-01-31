using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;

public class skellyShoot : MonoBehaviour
{

    public GameObject arrow;
    public Transform player;
    private float arrowSpeed = 25;
    private bool canShoot = true;
    private int health = 2;
    public GameObject enemy;
    public Image star;
    public Sprite skeletonStar;
    public Sprite mask;

    IEnumerator ShootWait(Vector3 dp) {
        yield return new WaitForSeconds(1f);
        Shoot(dp);
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(enemy);
            player.GetComponent<PlayerController>().uses = 1;
            player.GetComponent<PlayerController>().abilitySelector = 4;
            player.GetComponent<PlayerController>().maskRenderer.sprite = mask;
            star.sprite = skeletonStar;
        }
        Vector3 displacement = player.position - transform.position;
        displacement = displacement.normalized;
        if (canShoot) {
            StartCoroutine(ShootWait(displacement));
        }
    }

    void Shoot(Vector3 dp) {
        if (canShoot) {
            GameObject bullet = Instantiate(arrow, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                bullet.transform.rotation = Quaternion.Euler(0, 0, 45f);
                bullet.transform.position += dp;
                rb.AddForce(new Vector2(dp.x, dp.y) * arrowSpeed, ForceMode2D.Impulse);
            }
            canShoot = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
