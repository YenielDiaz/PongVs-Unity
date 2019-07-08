using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryMan : Player
{

    [Range(0f, 1000f)] [SerializeField] float cooldown;

    [SerializeField] GameObject sentryPrefab;
    SkillController[] skillControllers;
    [SerializeField] SkillController mySkillController;

    private void Start()
    {
        cooldown = 1000f;
        skillControllers = FindObjectsOfType<SkillController>();
        for(int i = 0; i<skillControllers.Length; i++)
        {
            if (skillControllers[i].GetOwner().Equals(this))
            {
                mySkillController = skillControllers[i];
                break;
            }
        }
    }

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
                    Instantiate(sentryPrefab, new Vector3(-5f, transform.position.y,0f), transform.rotation);
                    mySkillController.SetIsCoolDown(true);
                    cooldown = 0;
                }
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Instantiate(sentryPrefab, new Vector3(5f, transform.position.y, 0f), transform.rotation);
                    mySkillController.SetIsCoolDown(true);
                    cooldown = 0;
                }
            }
        }
    }




}
