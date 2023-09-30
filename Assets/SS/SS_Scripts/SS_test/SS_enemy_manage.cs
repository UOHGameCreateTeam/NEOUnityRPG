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
    // Start is called before the first frame update
    void Start()
    {

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

    //コルーチン関数を定義
    private IEnumerator kougeki() //コルーチン関数の名前
    {
        int i = 0;
        while (true)
        {
            //Debug.Log(i);
            if (i > 10) yield return StartCoroutine("beam");
            i++;
            generate.hassha();

            yield return new WaitForSeconds(0.5f);
        }
        

    }
    private IEnumerator beam() //コルーチン関数の名前
    {
        int i = 0;
        while (true)
        {
            //Debug.Log("aa");
            //Debug.Log(i);
            if (i > 5) yield return StartCoroutine("kougeki");
            i++;
            beam_attack.player_search();

            yield return new WaitForSeconds(2f);


        }


    }

    private void Update()
    {
        
        time += Time.deltaTime;
        if (time >= intarval) {
            worp_triangle.worp();
            time = 0;
        }

    }

}
