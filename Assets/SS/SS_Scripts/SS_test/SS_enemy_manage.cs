using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_enemy_manage : MonoBehaviour
{

    private SS_generate_tama generate;
    private SS_beam_hassha beam_attack;
    private SS_worp worp_triangle;
    private float time = 0f;
    Coroutine hassha_Coroutine;
    Coroutine beam_Coroutine;
    private float intarval = 5;
    [SerializeField]  private Animator animator;  // �A�j���[�^�[�R���|�[�l���g�擾�p

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g�擾
        generate = this.GetComponent<SS_generate_tama>();
        beam_attack = this.GetComponent<SS_beam_hassha>();
        worp_triangle = this.GetComponent<SS_worp>();
        StartCoroutine("kougeki");

        
       
    }

    /*public void hahaha() {
        generate = this.GetComponent<generate>();
        beam_attack = this.GetComponent<SS_beam4>();
        worp_triangle = this.GetComponent<SS_worp>();
        StartCoroutine("kougeki");
    }*/

    //�R���[�`���֐����`
    private IEnumerator kougeki() //�R���[�`���֐��̖��O
    {

        //animator.SetBool("hassha", true);
        int i = 0;
        while (true)
        {
            animator.SetBool("hassha", true);
            Debug.Log(animator);
            if (i > 10) {
                animator.SetBool("hassha", false);
                yield return StartCoroutine("beam");
            }
            
            i++;
            generate.hassha();

            yield return new WaitForSeconds(0.5f);
        }
        

    }
    private IEnumerator beam() //�R���[�`���֐��̖��O
    {
        //animator.SetBool("beam", true);
        int i = 0;
        while (true)
        {
            animator.SetBool("beam", true);
            //Debug.Log("aa");
            //Debug.Log(i);
            if (i > 5) {
                animator.SetBool("beam", false);
                yield return StartCoroutine("kougeki");
            }
            
            i++;
            beam_attack.player_search();

            yield return new WaitForSeconds(2f);


        }


    }

    private void Update()
    {
        //animator.SetBool("hassha", true);
        time += Time.deltaTime;
        if (time >= intarval) {
            worp_triangle.worp();
            time = 0;
        }

    }

}
