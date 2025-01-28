using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    private string runDirection;
    private List<string> memRunDirection = new List<string>();
    [SerializeField] private Animator anim;
    private bool[] currentDirection = {false,false,false,false};
    private Vector2 recDirection;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //memRunDirection = new string[4] {"","","",""};
    }

    void Update()
    {
        //direction = new Vector2(0, 0);
        //
        if(Input.GetKeyUp("w"))
        {
            memRunDirection.Remove("up");
            if(memRunDirection.Count() > 0)
            {
                runDirection = memRunDirection.Last();
            }else
            {
                if(!StateNameController.isPaused)
                {
                    anim.SetTrigger("Stop");
                }
                direction = new Vector2(0, 0);
            }
            
        }

        if(Input.GetKeyUp("s"))
        {
            memRunDirection.Remove("down");
            if(memRunDirection.Count() > 0)
            {
                runDirection = memRunDirection.Last();
            }else
            {
                if(!StateNameController.isPaused)
                {
                    anim.SetTrigger("Stop");
                }
                direction = new Vector2(0, 0);
            }
        }

        if(Input.GetKeyUp("a"))
        {
            memRunDirection.Remove("left");
            if(memRunDirection.Count() > 0)
            {
                runDirection = memRunDirection.Last();
            }else
            {
                if(!StateNameController.isPaused)
                {
                    anim.SetTrigger("Stop");
                }
                direction = new Vector2(0, 0);
            }
        }

        if(Input.GetKeyUp("d"))
        {
            memRunDirection.Remove("right");
            if(memRunDirection.Count() > 0)
            {
                runDirection = memRunDirection.Last();
            }else
            {
                if(!StateNameController.isPaused)
                {
                    anim.SetTrigger("Stop");
                }
                direction = new Vector2(0, 0);
            }
        }
        //

        if(Input.GetKeyDown("w"))
        {
            runDirection = "up";
            memRunDirection.Add("up");
            if(!StateNameController.isPaused)
            {
                anim.SetTrigger("Up");
            }
        }

        if(Input.GetKeyDown("s"))
        {
            runDirection = "down";
            memRunDirection.Add("down");
            if(!StateNameController.isPaused)
            {
                anim.SetTrigger("Down");
            }
            
        }

        if(Input.GetKeyDown("a"))
        {
            runDirection = "left";
            memRunDirection.Add("left");
            if(!StateNameController.isPaused)
            {
                anim.SetTrigger("Left");
            }
            
        }

        if(Input.GetKeyDown("d"))
        {
            runDirection = "right";
            memRunDirection.Add("right");
            if(!StateNameController.isPaused)
            {
                anim.SetTrigger("Right");
            }
            
        }

        if(Input.GetKey("w") && runDirection == "up")
        {
            if(direction != new Vector2(0, 1) && !StateNameController.isPaused)
            {
                anim.SetTrigger("Up");
                //bool[] currentDirection =  {true,false,false,false};
            }
            direction = new Vector2(0, 1);
        }

        if(Input.GetKey("s") && runDirection == "down")
        {
            if(direction != new Vector2(0, -1) && !StateNameController.isPaused)
            {
                anim.SetTrigger("Down");
                //bool[] currentDirection =  {false,true,false,false};
            }
            direction = new Vector2(0, -1);
        }

        if(Input.GetKey("a") && runDirection == "left")
        {
            if(direction != new Vector2(-1, 0) && !StateNameController.isPaused)
            {
                anim.SetTrigger("Left");
                //bool[] currentDirection =  {false,false,true,false};
            }
            direction = new Vector2(-1, 0);
        }

        if(Input.GetKey("d") && runDirection == "right")
        {
            if(direction != new Vector2(1, 0) && !StateNameController.isPaused)
            {
                anim.SetTrigger("Right");
                //bool[] currentDirection =  {false,false,false,true};
            }
            direction = new Vector2(1, 0);
            
        }
        direction.Normalize();
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        anim.SetTrigger("Stop");
        memRunDirection.Clear();
    }


}
