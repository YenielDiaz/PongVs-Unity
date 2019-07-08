using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGal : Player
{
    [Range(0f, 1000f)] [SerializeField] float cooldown;
    
    [SerializeField] GameObject laserPrefab;
    SkillController[] skillControllers;
    [SerializeField] SkillController mySkillController;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 1000;
        skillControllers = FindObjectsOfType<SkillController>();
        for (int i = 0; i < skillControllers.Length; i++)
        {
            if (skillControllers[i].GetOwner().Equals(this))
            {
                mySkillController = skillControllers[i];
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleAbilities();
    }


    protected void HandleAbilities()
    {
        if (!mySkillController.GetIsCooldown())
        {
            if (tag.Equals("Player1"))
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    var laser = Instantiate(laserPrefab, new Vector3(-5.5f, transform.position.y, 0f), transform.rotation);
                    mySkillController.SetIsCoolDown(true);
                    cooldown = 0;
                }
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    var laser = Instantiate(laserPrefab, new Vector3(5.5f, transform.position.y, 0f), transform.rotation);
                    mySkillController.SetIsCoolDown(true);
                    cooldown = 0;
                }
            }
        }
    }
}
