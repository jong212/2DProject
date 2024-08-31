using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SkillManager instance;

    public DashSkill dash {  get; private set; }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else instance = this;
    }
    private void Start()
    {
        dash = GetComponent<DashSkill>();
    }
}
