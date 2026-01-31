using UnityEngine;
using System.Collections;

public class realspider : MonoBehaviour
{
    private float speed = 5;
    Vector3 direction = new Vector3(0, 1, 0);
    private bool canMove = true;

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
        if (canMove) {
            transform.position += (direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canMove = false;
        StartCoroutine(WaitOnHit());
        
    }
}
