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
    CircleCollider2D bubbla;

    [SerializeField] GameObject pivotPoint;
    [SerializeField] Image oxygenBar;
    [SerializeField] GameObject player;

    [SerializeField] GameObject gameOver;

    void Start()
    {
       gameOver.SetActive(false);
       currentOxygen = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {       
     
       DecreaseOxygen();
      // UpdateBubbleSize();
       spriteRenderer.sprite = sprite[spriteIndex];
    }
  
    void DecreaseOxygen()
    {
        currentOxygen -= oxygenDrainAmount * oxygenDrainSpeed * Time.deltaTime;
        oxygenBar.fillAmount = currentOxygen/(float)maxOxygen;
       // pivotPoint.transform.localScale -= new Vector3(0.1f,0.1f, 0) * Time.deltaTime;

        pivotPoint.transform.localScale = new Vector3(currentOxygen/(float)maxOxygen,currentOxygen/(float)maxOxygen,0);
        if(currentOxygen <= 0)
        {
            currentOxygen = 0;
            gameOver.SetActive(true);
            player.SetActive(false);
        }
        else if (currentOxygen >= maxOxygen)
        {
            currentOxygen = maxOxygen;
        }
    }

    void UpdateBubbleSize()
    {
        // Minska bubblan när O2 gått ner 10 (90,80,70, osv)
        // om syret har gått ner 10 sedan förra gången den kollade syret, minska bubblan
        spriteIndex = ((int)currentOxygen)/25;
       
       // spriteRenderer.sprite = sprite[spriteIndex];
        if(spriteIndex == 0 )
        {
           spriteRenderer.sprite = sprite[0];
            // syre är under 25
            //minsta bubbelstorleken
            bubbla.offset = new Vector2(0,-0.2f);
            bubbla.radius = 0.2f;
        }
        else if(spriteIndex == 1 )
        {
            spriteRenderer.sprite= sprite[1];
            bubbla.offset = new Vector2(0, -0.15f);
            bubbla.radius = 0.3f;
            //syre är under 50
            //näst minsta bubbelstorleken

        }
        else if(spriteIndex == 2 )
        {
            spriteRenderer.sprite = sprite[2];
            bubbla.offset = new Vector2(0,- 0.16f);
            bubbla.radius = 0.3f;
            //syre är under 75
            //näst största bubbelstorleken
        }
        else if (spriteIndex == 3 )
        {
            spriteRenderer.sprite = sprite[3];
            bubbla.offset = new Vector2(0,-0.02f);
            bubbla.radius = 0.45f;
            //syre är 100
            //Fullstor bubbla
        }
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
