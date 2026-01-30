using UnityEngine;

public class ineedmorebullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float prevDist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prevDist = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.x < prevDist)
            {
                backShoot();
            }
            else
            {
                Shoot();
            }
        }
        prevDist = transform.position.x;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            bullet.transform.position += new Vector3(1, 0, 0);
            rb.AddForce(new Vector2(25, 0), ForceMode2D.Impulse);
        }
    }

    void backShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            bullet.transform.position += new Vector3(-1, 0, 0);
            rb.AddForce(new Vector2(-25, 0), ForceMode2D.Impulse);
        }
    }
}
