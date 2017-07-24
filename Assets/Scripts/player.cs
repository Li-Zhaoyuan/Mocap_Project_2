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

    protected int dirToEnemy = 1;

    protected float inputH;
    protected float inputV;
    protected float xAxis, zAxis;
    protected float movementValue = 0;

    protected bool run,isRunning = false,isJumping = false;

    // Use this for initialization
    public virtual void Start () {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        run = false;
        CheckForDirection();
    }
	
	// Update is called once per frame
	public virtual void Update () {
        Movement();
    }

    public virtual void CheckForDirection()
    {
        if (enemy.transform.position.z > transform.position.z && transform.rotation.y != 90)
        {
            //transform.rotation = new Quaternion(0, 90, 0, 0);
            dirToEnemy = 1;
        }
        else if (enemy.transform.position.z < transform.position.z && transform.rotation.y != -90)
        {
            //transform.rotation = new Quaternion(0, 90, 0, 0);
            dirToEnemy = -1;
        }
    }

    public virtual void Attack()
    {

    }

    public virtual void Guard()
    {

    }

    public virtual void Movement()
    {
        if (plyer_number == PLAYER_NUM.TWO)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementValue = Mathf.Clamp(movementValue - (Time.deltaTime * 2f), -1f, 1f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                movementValue = Mathf.Clamp(movementValue + (Time.deltaTime * 2f) , -1f, 1f);
            }
            else
            {
                if (movementValue > 0f)
                {
                    movementValue = Mathf.Clamp(movementValue - (Time.deltaTime * 2f), 0, 1f);
                }
                else if (movementValue < 0f)
                {
                    movementValue = Mathf.Clamp(movementValue + (Time.deltaTime * 2f), -1f, 0f);
                }
            }
           
            
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                movementValue = Mathf.Clamp(movementValue - (Time.deltaTime * 2f), -1f, 1f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movementValue = Mathf.Clamp((Time.deltaTime * 2f) + movementValue, -1f, 1f);
            }
            else
            {
                if (movementValue > 0f)
                {
                    movementValue = Mathf.Clamp(movementValue - (Time.deltaTime * 2f), 0, 1f);
                }
                else if (movementValue < 0f)
                {
                    movementValue = Mathf.Clamp(movementValue + (Time.deltaTime * 2f), -1f, 0f);
                }
            }
            
           
        }


        anim.SetFloat("inputH", movementValue * dirToEnemy);
        //anim.SetFloat("inputV", xAxis);
        //anim.SetBool("run", run);
        float moveX = 0;//xAxis * 100f * Time.deltaTime;
        float moveZ = movementValue * 100f * Time.deltaTime;


        //Debug.Log(moveX);
        
        if (moveZ <= 0)
        {
            moveX = 0f;
        }
        else if (run)
        {
            moveZ *= 3;
            moveX *= 3;
        }
        rigidBody.velocity = new Vector3(moveX, 0, moveZ);
    }
}


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
//transform.rotation = new Quaternion(0, 0, 0, 0);
//if (enemy.transform.position.z > transform.position.z && transform.rotation.y != 90)
//{
//    transform.rotation = new Quaternion(0,90,0,0);
//    dirToEnemy = 1;
//}
//else if(enemy.transform.position.z < transform.position.z && transform.rotation.y != -90)
//{
//    transform.rotation = new Quaternion(0, 90, 0, 0);
//    dirToEnemy = -1;
//}