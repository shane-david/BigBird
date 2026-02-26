using UnityEngine;
using UnityEngine.UI; 

public class HealthBarUI : MonoBehaviour
{

    //private variables
    //-----------------
    [SerializeField] private float health, maxHealth, width, height; 
    [SerializeField] private RectTransform healthBar; 

    //setters
    //-------

    //set the health and change the UI accordingly
    public void SetHealth(float health)
    {   

        //set health 
        this.health = health; 

        //get new width of UI
        //depends on ration from health to max health 
        float newWidth = (health/maxHealth) * width; 

        //change the recttransfrom so the width change is actually visible
        healthBar.sizeDelta = new Vector2(newWidth, height); 

        
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth; 
    }


}
