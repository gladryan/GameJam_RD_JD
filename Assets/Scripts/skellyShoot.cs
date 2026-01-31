using UnityEngine;
using System.Collections;

public class skellyShoot : MonoBehaviour
{

    public GameObject arrow;
    public Transform player;
    private float arrowSpeed = 25;
    private bool canShoot = true;

    IEnumerator ShootWait(Vector3 dp) {
        yield return new WaitForSeconds(1f);
        Shoot(dp);
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
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
}
