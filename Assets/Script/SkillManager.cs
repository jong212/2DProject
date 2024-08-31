using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SkillManager instance;
    
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else instance = this;
    }
}
