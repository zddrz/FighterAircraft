using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject explo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, -0.01f, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ship" || collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explo, transform.position, transform.rotation);
            if (collision.tag == "Ship")
            {
                Instantiate(explo, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                GameFunction.Instance.GameOver();
            }
            GameFunction.Instance.AddScore();
        }
    }
}
