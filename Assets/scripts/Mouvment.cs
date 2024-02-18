using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvment : MonoBehaviour
{
    Rigidbody rb;
    public float rotationSpeed = 100f;
    public float speed = 200f;
    public float force = 10f;


    public static int score = 0;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horz = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        Vector3 mvt = new Vector3(Horz, 0f, Vert);
        rb.velocity = (mvt* speed * Time.deltaTime);

        GameObject[] cherrys = GameObject.FindGameObjectsWithTag("Cherry");
        GameObject[] rewards = GameObject.FindGameObjectsWithTag("Reward");

        foreach (GameObject cherry in cherrys)
        {
            cherry.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        foreach (GameObject reward in rewards)
        {
            reward.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Cherry"))
        {
            Destroy(collision.gameObject);
            score += 1;
            Debug.Log("Score: " + score);

        }
        if (collision.gameObject.tag.Equals("Reward"))
        {
            Destroy(collision.gameObject);
            score += 20;
            Debug.Log("Score: " + score);

        }
    }


}
