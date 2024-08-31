using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{

    private SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private float flahDuration;
    [SerializeField] private Material hitMat;  
    private Material originMat;

    private void Start()
    {
        sr =  GetComponentInChildren<SpriteRenderer>();
        originMat = sr.material;


    }
    IEnumerator FlashFX()
    {
        sr.material = hitMat;

        yield return new WaitForSeconds(flahDuration);

        sr.material = originMat;
    }

    private void RedColorBlink()
    {
        if (sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red; 
    }
    private void CancelRedBlink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
        
}
