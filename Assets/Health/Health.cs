using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject Can;
    public int numberofhearts;
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;

    void Update() 
    {
        int HealthPoints = Can.GetComponent<Movement>().getcanvalue();

        if (HealthPoints > numberofhearts)
        {
            HealthPoints = numberofhearts;
        }

        for (int i = 0; i < hearts.Length; i++) 
        {
            if (i < HealthPoints)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }
            if(i < numberofhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
         
    }

}
