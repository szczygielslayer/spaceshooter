using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    public int hp = 3;

    public float moveSpeed = 2f;

    public Transform minXValue;
    public Transform maxXValue;

    public GameObject bulletPrefab;
    public Transform gunEndPosition;

    public float firerate = 0.2f;
    private float timeSinceLastAction = 0f;

    // Start is called before the first frame update
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

        if (hp <= 0)
        {
            Debug.Log("koniec gry");
            Application.Quit();
        }
    }


    void PlayerMovement()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInputValue, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movementVector);

        if (transform.position.x > maxXValue.position.x)
        {
            transform.position = new Vector2(maxXValue.position.x, transform.position.y);
        }

        if (transform.position.x < minXValue.position.x)
        {
            transform.position = new Vector2(minXValue.position.x, transform.position.y);
        }


    }
    void Shoot()
    {

        timeSinceLastAction += Time.deltaTime;

        if (timeSinceLastAction >= firerate)
        {

            Instantiate(bulletPrefab, gunEndPosition.position, Quaternion.identity);
            timeSinceLastAction = 0;
        }
    }


    public void HittedByBullet()
    {
        // hp = 2
        //GameManager.uiManager.DisableHpSprite(hp);

        hp = hp - 1;
        //1
        Debug.Log("Trafiono");
    }
}

