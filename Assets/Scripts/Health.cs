using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] /* public*/ int maxOxygen;
    [SerializeField] float currentOxygen;
    
    [SerializeField] int oxygenDrainSpeed;
    [SerializeField] float oxygenDrainAmount;

    [SerializeField] Sprite[] sprite;
    [SerializeField] int spriteIndex;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D bubbla;
   

    [SerializeField] Image oxygenBar;
    void Start()
    {
        currentOxygen = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
       oxygenBar.fillAmount = currentOxygen/maxOxygen;
        bubbla.radius = currentOxygen / maxOxygen;
       DecreaseOxygen();
       UpdateBubbleSize();
       spriteRenderer.sprite = sprite[spriteIndex];
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        //Minska h�lsan
        //Minska bubblan?
    }

    void DecreaseOxygen()
    {
        currentOxygen -= oxygenDrainAmount * oxygenDrainSpeed * Time.deltaTime;
       // bubbla.radius -= oxygenDrainAmount * Time.deltaTime;
      
        if(currentOxygen <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void UpdateBubbleSize()
    {
        // Minska bubblan n�r O2 g�tt ner 10 (90,80,70, osv)
        // om syret har g�tt ner 10 sedan f�rra g�ngen den kollade syret, minska bubblan
        spriteIndex = ((int)currentOxygen)/25;
       
        spriteRenderer.sprite = sprite[spriteIndex];
        //if(spriteIndex == 0 )
        //{
        //    spriteRenderer.sprite = sprite[0];
        //    // syre �r under 25
        //    //minsta bubbelstorleken
        //}
        //else if(spriteIndex == 1 )
        //{
        //    spriteRenderer.sprite= sprite[1];
        //    //syre �r under 50
        //    //n�st minsta bubbelstorleken
            
        //}
        //else if(spriteIndex == 2 )
        //{
        //    spriteRenderer.sprite = sprite[2];
        //    //syre �r under 75
        //    //n�st st�rsta bubbelstorleken
        //}
        //else if (spriteIndex == 3 )
        //{
        //    spriteRenderer.sprite = sprite[3];
        //    //syre �r 100
        //    //Fullstor bubbla
        //}
    }
   public void TakeDamage(int amount)
    {
        currentOxygen -= amount;
    }
   public void Heal(int amount)
    {
        currentOxygen += amount;
    }
}
