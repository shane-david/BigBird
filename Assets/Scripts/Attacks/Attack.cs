using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    
    //protected variables
    //-------------------

    //timer variable so each attack can track how long it is executing 
    protected float timer = 0f;

    //to talk back to the enemyAI script
    protected System.Action onFinished; 

    //to identify attack 
    protected string AttackName; 

    //public methods
    //--------------

    //method that each attack overrides and implements
    public abstract void Execute(); 

    //not abstract because it is the same for each one 
    public void Begin(System.Action onFinished)
    {   
        //set the function needed to set attackHappening in enemyAI
        this.onFinished = onFinished; 

        //enable this script 
        enabled = true; 
    }

    //getters
    //-------
    public string getAttackName()
    {
        return AttackName; 
    }

}
