using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public enum PLAYER_NUM
{
    ONE,
    TWO,
    TOTAL,
};

public enum ATTACK_TYPE
{
    LOW,
    HIGH,
    BLOCKED,
}
public class player : MonoBehaviour {

    public Animator anim;
    public Rigidbody rigidBody;
    public GameObject enemy;
    public PLAYER_NUM plyer_number;
	public Image healthBar;
    protected int dirToEnemy = 1;

    protected float inputH;
    protected float inputV;
    protected float xAxis, zAxis;
    protected float movementValue = 0;

	protected bool run;
	protected bool isRunning = false;
	protected bool isJumping = false;

	[SerializeField]
	protected int max_Health = 100;
	protected int health;

	[SerializeField]
	protected int blockValue = 10;
	protected bool isBlock = false;

	protected bool isAttack = false;
    protected bool isHitLow = false;
    protected bool isHitHigh = false;
    protected float constAttackTimer = 0.5f;//TODO :Remove hardcode
	protected float attackTimer = 0.7f;
	[SerializeField]
	protected AttackBox attack_left;//set this to active when its attacking
	[SerializeField]
	protected AttackBox attack_right;//set this to active when its attacking
    // Use this for initialization
    public virtual void Start () {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        run = false;
        CheckForDirection();
		health = max_Health;


		attack_left.gameObject.SetActive(false);
		attack_right.gameObject.SetActive(false);//will be turned on when the animation starts
    }
	public void AttackFinished(bool attacked)
	{
		isAttack = attacked;
	}
	// Update is called once per frame
	public virtual void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            isHitHigh = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            isHitLow = true;
        }
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
		//attack_left.gameObject.SetActive(true);
		//attack_right.gameObject.SetActive(true);//will be turned off when the animation ends
    }

    public virtual void Guard()
    {
		isBlock = true;
    }
	public virtual void TakeDamage(int damage, ATTACK_TYPE type = ATTACK_TYPE.BLOCKED)
	{
		
	}
    public virtual void Movement()
    {
        if (plyer_number == PLAYER_NUM.TWO)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                AudioManager.instance.playsound("challenger_walk");
                movementValue = Mathf.Clamp(movementValue - (Time.deltaTime * 2f), -1f, 1f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                AudioManager.instance.playsound("challenger_walk");
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
                AudioManager.instance.playsound("champion_walk");
                movementValue = Mathf.Clamp(movementValue - (Time.deltaTime * 2f), -1f, 1f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                AudioManager.instance.playsound("champion_walk");
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
        float moveX = 0;//xAxis * 100f * Time.deltaTime;
        float moveZ = movementValue * 100f * Time.deltaTime;


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