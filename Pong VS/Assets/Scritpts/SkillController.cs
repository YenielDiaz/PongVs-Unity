using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [SerializeField] Image imageCooldown;
    [SerializeField] float coolDown = 1000;
    bool isCooldown = false;
    [SerializeField] Player owner;

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            imageCooldown.fillAmount += 0.005f;

            if(imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0f;
                isCooldown = false;
            }
        }

    }

    public Player GetOwner()
    {
        return owner;
    }

    public bool GetIsCooldown()
    {
        return isCooldown;
    }

    public void SetIsCoolDown(bool isIsCooldown)
    {
        isCooldown = isIsCooldown;
    }
}
