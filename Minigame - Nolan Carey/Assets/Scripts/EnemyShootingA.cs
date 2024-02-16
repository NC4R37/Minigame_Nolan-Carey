using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShootingA : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject player;
    //public float delta;
    public float shotDelay;
    //public float aSide;
    //public float bSide;
    //public float cSide;
    //public float firingAngle;
    public float bulletForce;
    public Vector3 newVector;
    public float moveLine;
    public float moveSpeed;
    
    
    

    // Update is called once per frame
    void FixedUpdate()
    {
        float curPosY = transform.position.y;
        newVector = (player.transform.position - this.transform.position).normalized;
        
        if (curPosY >= moveLine - 0.5) 
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }
        
        if (curPosY <= moveLine ) 
        {
            if (shotDelay >= 100)
            {
                StartCoroutine(ShootingCoroutine());
                shotDelay = 0;
            }

            else
            {
                shotDelay += 1;
            }
        }
        
    }
    

    void Shoot()
    {
        Debug.Log("startshootfunc");
        //aSide = this.transform.position.y - player.transform.position.y;
        //bSide = this.transform.position.x - player.transform.position.x;
        // cSide = (math.sqrt(aSide * aSide) + (bSide * bSide));
        //firingAngle = ((aSide / cSide));
        
        //Debug.Log(firingAngle);
        
      
        Debug.LogFormat("Enemy: {0}, Player {1}, New Vector {2}", transform.position, player.transform.position, newVector);
        
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation );
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(newVector * bulletForce, ForceMode2D.Force);
    }

    IEnumerator ShootingCoroutine()
    {
        Shoot();
        yield return new WaitForSeconds((float).1);
        Shoot();
        yield return new WaitForSeconds((float).1);
        Shoot();
        
    }
}
