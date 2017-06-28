using UnityEngine;
using System.Collections;
public enum PLAYER_NUM
{
    ONE,
    TWO,
    TOTAL,
};
public class player : MonoBehaviour {

    public Animator anim;
    public Rigidbody rigidBody;
    public GameObject enemy;
    public PLAYER_NUM plyer_number;

    int dirToEnemy = 1;

    float inputH;
    float inputV;
    float xAxis, zAxis;

    bool run,isRunning = false,isJumping = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        run = false;
    }
	
	// Update is called once per frame
	void Update () {
	    //if(Input.GetKeyDown("1"))
     //   {
     //       print("pressed 1");
     //       anim.Play("WAIT01", -1,0f);
     //   }
     //   else if (Input.GetKeyDown("2"))
     //   {
     //       print("pressed 2");
     //       anim.Play("WAIT02", -1, 0f);
     //   }
     //   else if (Input.GetKeyDown("3"))
     //   {
     //       print("pressed 3");
     //       anim.Play("WAIT03", -1, 0f);
     //   }
     //   else if (Input.GetKeyDown("4"))
     //   {
     //       print("pressed 4");
     //       anim.Play("WAIT04", -1, 0f);
     //   }
     //   else if(Input.GetMouseButtonDown(0))
     //   {
     //       int rand = Random.Range(0, 2);
     //       anim.Play("DAMAGED0" + rand.ToString(), -1, 0f);
     //   }

        //if(Input.GetKey(KeyCode.Space))
        //{
        //    anim.SetBool("jump", true);
        //}
        //else
        //{
        //    anim.SetBool("jump", false);
        //}
        if(enemy.transform.position.z > transform.position.z && enemy.transform.rotation.y != 0)
        {
            transform.rotation = new Quaternion(0,0,0,0);
            dirToEnemy = 1;
        }
        else if(enemy.transform.position.z < transform.position.z && enemy.transform.rotation.y != 180)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            dirToEnemy = -1;
        }
        
        if (plyer_number == PLAYER_NUM.TWO)
        {
            zAxis = Input.GetAxis("Horizontal");
            xAxis = Input.GetAxis("Vertical");
            //if(xAxis > 0 && !isJumping)

            if (/*xAxis > 0 && xAxis < 0.1f*/Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetBool("jump", true);
                
            }
            else
            {
                anim.SetBool("jump", false);
            }
            if (Input.GetKey(KeyCode.LeftShift) && zAxis * dirToEnemy > 0)
            {
                run = true;
            }
            else
            {
                run = false;
            }
        }
        else
        {
            zAxis = Input.GetAxis("Horizontal_p2");
            xAxis = Input.GetAxis("Vertical_p2");

            if (/*xAxis > 0 && xAxis < 0.1f*/Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool("jump", true);
               
            }
            else
            {
                anim.SetBool("jump", false);
            }
            if (Input.GetKey(KeyCode.LeftShift) && zAxis * dirToEnemy > 0)
            {
                run = true;
            }
            else
            {
                run = false;
            }
        }
        

        anim.SetFloat("inputH", zAxis * dirToEnemy);
        //anim.SetFloat("inputV", xAxis);
        anim.SetBool("run", run);
        float moveX = 0;//xAxis * 100f * Time.deltaTime;
        float moveZ = zAxis * 100f * Time.deltaTime;


        //Debug.Log(moveX);
        Debug.Log(zAxis);
        if(moveZ<=0)
        {
            moveX = 0f;
        }
        else if(run)
        {
            moveZ *= 3;
            moveX *= 3;
        }
        rigidBody.velocity = new Vector3(moveX, 0, moveZ);
    }
}
