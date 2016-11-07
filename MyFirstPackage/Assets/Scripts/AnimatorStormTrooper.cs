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
            gameStateLimitElapsed = Random.Range(10, 12);
            gameState++;
            if (gameState > 1)
            {
                gameState = 0;
            }
            if (gameState == 0)
            {
                capsuleCollider.enabled = false;
                sableStormTrooperGameObject.SetActive(true);
                sableUserGameObject.SetActive(true);
                forceGameObject.SetActive(false);
            }
            else if (gameState == 1)
            {
                capsuleCollider.enabled = true;
                sableStormTrooperGameObject.SetActive(false);
                sableUserGameObject.SetActive(false);
                forceGameObject.SetActive(true);
            }
            

        }

        if (!anim.GetBool ("isFirstTimeWDS"))
		{
            switch (gameState)
            {
                case 0:
                    if (elapsedTime >= atackTime)
                    {
                        atackTime = elapsedTime + Random.Range(2.1f, 7.1f);
                        int pRandom = Random.Range(0, 4);
                        pRandom = Random.Range(0, 4);
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
                        else if (Input.GetKeyDown(KeyCode.D))
                        {
                            anim.SetBool("isDeath", true);
                        }
                        else
                        {
                            anim.SetBool("isIdle", true);
                            anim.SetBool("isAttacking1", false);
                            anim.SetBool("isAttacking2", false);
                            anim.SetBool("isAttacking3", false);
                            anim.SetBool("isAttacking4", false);
                            anim.SetBool("isAttacking5", false);
                            anim.SetBool("isDeath", false);
                        }
                    }
                    else
                    {
                        anim.SetBool("isIdle", true);
                        anim.SetBool("isAttacking1", false);
                        anim.SetBool("isAttacking2", false);
                        anim.SetBool("isAttacking3", false);
                        anim.SetBool("isAttacking4", false);
                        anim.SetBool("isAttacking5", false);
                        anim.SetBool("isDeath", false);
                    }
                    break;
                case 1:
                    if (elapsedTime >= atackTime)
                    {
                        atackTime = elapsedTime + Random.Range(2.1f, 4.1f);
                        int pRandom = Random.Range(0, 2);
                        pRandom = Random.Range(0, 2);
                        if (pRandom == 0)
                        {
                            anim.SetBool("isAttacking1", true);
                        }
                        else if (pRandom == 1)
                        {
                            anim.SetBool("isAttacking2", true);
                        }
                        else
                        {
                            anim.SetBool("isIdle", true);
                            anim.SetBool("isAttacking1", false);
                            anim.SetBool("isAttacking2", false);
                            anim.SetBool("isAttacking3", false);
                            anim.SetBool("isAttacking4", false);
                            anim.SetBool("isAttacking5", false);
                            anim.SetBool("isDeath", false);
                        }
                    }
                    else
                    {
                        anim.SetBool("isIdle", true);
                        anim.SetBool("isAttacking1", false);
                        anim.SetBool("isAttacking2", false);
                        anim.SetBool("isAttacking3", false);
                        anim.SetBool("isAttacking4", false);
                        anim.SetBool("isAttacking5", false);
                        anim.SetBool("isDeath", false);
                    }
                    break;
            }
            

        }




	}

}
