using System.Collections;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class death : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public bool Invincibility;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator wait3Seconds()
    {
        yield return new WaitForSeconds(1f);
        Invincibility = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            if (Invincibility == false)
            {
                SceneManager.LoadScene("Level Selection");
            }
            else
            {
                StartCoroutine(wait3Seconds());
                rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            }
        }
    }



}
