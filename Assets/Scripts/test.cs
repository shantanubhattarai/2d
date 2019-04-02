using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            StartCoroutine(EquationGenerator());
    }

    private IEnumerator EquationGenerator()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int op = Random.Range(1, 5);
        int rightwrong = Random.Range(1, 3);
        yield return new WaitForSeconds(0.2f);
        if(rightwrong == 1)
        {
            switch (op)
            {
                case 1:
                    print(a + "+" + b + "=" + (a + b));
                    break;
                case 2:
                    print(a + "-" + b + "=" + (a - b));
                    break;
                case 3:
                    print(a + "*" + b + "=" + (a * b));
                    break;
                case 4:
                    print(a + "/" + b + "=" + ((float)a / (float)b));
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (op)
            {
                case 1:
                    print(a + "+" + b + "=" + ((a + b) + Random.Range(-3,3)));
                    break;
                case 2:
                    print(a + "-" + b + "=" + ((a - b) + Random.Range(-3, 3)));
                    break;
                case 3:
                    print(a + "*" + b + "=" + ((a * b) + Random.Range(-3, 3)));
                    break;
                case 4:
                    print(a + "/" + b + "=" + (((float)a / (float)b) + Random.Range(-3, 3)));
                    break;
                default:
                    break;
            }
        }
        
    }

}
