using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force;
    public float powerUpStrange;
    public Rigidbody playerRb;
    public GameObject focalPoint;
    public GameObject powerUp;
    public bool hasPowerUp;
    private float _verticalInput;
    
    void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * force * Time.deltaTime * _verticalInput);
        powerUp.transform.position = transform.position + new Vector3(0, 0, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUp.SetActive(true);
            StartCoroutine(PowerupCoroutine());
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Игрок столкнулся с" + collision.gameObject + "и применил суперсилу");
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            enemyRb.AddForce(awayFromPlayer * powerUpStrange, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCoroutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUp.SetActive(false);
    }
}
