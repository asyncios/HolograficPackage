using UnityEngine;
using System.Collections;

public class AnimatorStormTrooper : MonoBehaviour {

	Animator anim;
	private float elapsedTime;
    private float atackTime;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("isIdle",false);
		anim.SetBool ("isWDSword",true);
		anim.SetBool ("isFirstTimeWDS",true);
		elapsedTime = 0.0f;
        atackTime = elapsedTime+Random.Range(2.1f, 7.1f);

    }
	

	void Update () {

		elapsedTime += Time.deltaTime;
		if (elapsedTime >= 2.0 && anim.GetBool("isFirstTimeWDS"))
        {
	    	anim.SetBool ("isIdle",true);
		    anim.SetBool ("isFirstTimeWDS",false);

		}

		if (!anim.GetBool ("isFirstTimeWDS"))
		{
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

        }




	}

}
