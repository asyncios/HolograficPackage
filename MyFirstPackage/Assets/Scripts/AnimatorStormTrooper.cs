using UnityEngine;
using System.Collections;

public class AnimatorStormTrooper : MonoBehaviour {

    //Enemy
    public GameObject sableStormTrooperGameObject;
    public GameObject hipsGameObject;
    CapsuleCollider capsuleCollider;
    Animator anim;

    //User
    //force
    public GameObject forceGameObject;
    public GameObject sableUserGameObject;

    private float elapsedTime;
    private float atackTime;
    private int gameState;
    private float gameStateElapsed;
    private float gameStateLimitElapsed;

    private Vector3 lastPosition;
    private bool hasDodgeLeft;
    private bool hasDodgeRight;
    private int lastAnimation;
    private Vector3 initialPosition;
    private Vector3 forceInitialPosition;

    void Start () {
        gameState = 0;
        gameStateElapsed = 0;
        gameStateLimitElapsed = Random.Range(5,7);
        capsuleCollider = hipsGameObject.GetComponent<CapsuleCollider>();
        capsuleCollider.enabled=false;
        anim = GetComponent<Animator> ();
		anim.SetBool ("isIdle",false);
		anim.SetBool ("isWDSword",true);
		anim.SetBool ("isFirstTimeWDS",true);
		elapsedTime = 0.0f;
        atackTime = elapsedTime+Random.Range(2.1f, 7.1f);
        forceGameObject.SetActive(false);

        //
        hasDodgeRight = false;
        hasDodgeLeft = false;
        lastAnimation = 100;
        initialPosition = transform.position;
        forceInitialPosition = forceGameObject.transform.position;
    }
	

	void Update () {

		elapsedTime += Time.deltaTime;
		if (elapsedTime >= 2.0 && anim.GetBool("isFirstTimeWDS"))
        {
	    	anim.SetBool ("isIdle",true);
		    anim.SetBool ("isFirstTimeWDS",false);

		}
        if (elapsedTime >= 3.1 && gameState==0)
        {
            sableStormTrooperGameObject.SetActive(true);
        }

        gameStateElapsed += Time.deltaTime;
        if (gameStateElapsed >= gameStateLimitElapsed)
        {
            gameStateElapsed = 0.0f;
            gameStateLimitElapsed = Random.Range(12, 14);
            gameState++;
            if (gameState > 1)
            {
                gameState = 0;
            }

            if (gameState == 0)
            {
                transform.position = initialPosition;
                capsuleCollider.enabled = false;
                sableStormTrooperGameObject.SetActive(true);
                sableUserGameObject.SetActive(true);
                forceGameObject.SetActive(false);
            }
            else if (gameState == 1)
            {
                forceGameObject.transform.position = forceInitialPosition;
                capsuleCollider.enabled = true;
                sableStormTrooperGameObject.SetActive(false);
                sableUserGameObject.SetActive(false);
                forceGameObject.SetActive(true);
            }
            

        }

        if (LightSaberStormTrooper.hit)
        {
            disableAnimations();
            anim.SetTrigger("hit");
            LightSaberStormTrooper.hit = false;
            return;
        }

        if (!anim.GetBool ("isFirstTimeWDS"))
		{
            switch (gameState)
            {
                case 0:
                    if (elapsedTime >= atackTime)
                    {
                        atackTime = elapsedTime + Random.Range(0.1f, 1.1f);
                        int pRandom = Random.Range(0, 4);
                        pRandom = Random.Range(0, 4);
                        activateAnimtation(pRandom);
                    }
                    else
                    {
                        returnToDefaultAnimation();
                    }
                    break;
                case 1:
                    if (elapsedTime >= atackTime)
                    {
                        atackTime = elapsedTime + Random.Range(0.1f, 1.1f);
                        int pRandom = Random.Range(5, 8);
                        pRandom = Random.Range(5, 8);
                        if (pRandom == 7)
                        {
                            atackTime = elapsedTime + Random.Range(2.1f, 3.1f);
                        }
                        activateAnimtation(pRandom);
                    }
                    else
                    {
                        returnToDefaultAnimation();
                    }
                    break;
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dodgeRight") && gameState == 1)
        {

            Debug.Log("MoviendoseRight");
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            //Debug.Log(transform.position.x - 0.5f);

            if (transform.position.x - 0.5f <= -4f)
                hasDodgeRight = true;

        } else if (transform.position.x > -4f){
            hasDodgeRight = false;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("dodgeLeft") && gameState == 1)
        {

            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            //Debug.Log(transform.position.x - 0.5f);
            Debug.Log("MoviendoseLeft");
            if (transform.position.x + 0.5f >= 4f)
                hasDodgeLeft = true;
            
        } else if (transform.position.x < 4f) {
            hasDodgeLeft = false;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("isJumping") && gameState == 1)
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        else
        {
            if (!(transform.position.y > -7.0f && transform.position.y < -5.90f) && gameState == 1)
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z);
        }



        if (gameState == 0)
        {
            if (lastAnimation>=5)
            {
                transform.position = initialPosition;
            }
        }
    }

    public void returnToDefaultAnimation()
    {
        disableAnimations();
        anim.SetBool("isIdle", true);
    }

    public void disableAnimations()
    {
        //anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking1", false);
        anim.SetBool("isAttacking2", false);
        anim.SetBool("isAttacking3", false);
        anim.SetBool("isAttacking4", false);
        anim.SetBool("isAttacking5", false);
        anim.SetBool("isDodgeLeft", false);
        anim.SetBool("isDodgeRight", false);
        anim.SetBool("isCrouch", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("isDeath", false);
    }

    public void activateAnimtation(int pRandom)
    {
        disableAnimations();
        if (pRandom == 0)
        {
            anim.SetBool("isAttacking1", true);
        }
        else if (pRandom == 1)
        {
            anim.SetBool("isAttacking2", true);
        }
        else if (pRandom == 2)
        {
            anim.SetBool("isAttacking3", true);
        }
        else if (pRandom == 3)
        {
            anim.SetBool("isAttacking4", true);
        }
        else if (pRandom == 4)
        {
            anim.SetBool("isAttacking5", true);
        }
        else if (pRandom == 5 && !hasDodgeLeft)
        {
            //hasDodgeRight = false;
            anim.SetBool("isDodgeLeft", true);
        }
        else if (pRandom == 6 && !hasDodgeRight)
        {
            //hasDodgeLeft = false;
            anim.SetBool("isDodgeRight", true);
        }
        else if (pRandom == 7)
        {
            anim.SetBool("isJumping", true);
        }
        else if (pRandom == 8)
        {
            anim.SetBool("isCrouch", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("isDeath", true);
        }
        else
        {
            returnToDefaultAnimation();
        }

        lastAnimation = pRandom;
    }

}
