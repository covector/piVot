using UnityEngine;

public class DualAbility : MonoBehaviour
{
    public Pivot piv;
    public Player vul;
    public Player invul;
    private float coolDown;
    public ParticleManager part;
    private bool Ability()
    {
        if (coolDown <= 0)
        {
            vul.invul = 1 - vul.invul;
            invul.invul = 1 - invul.invul;
            part.rotatePart();
            coolDown = 1f;
            colorChange();
            return true;
        }
        return false;
    }
    public GameObject coolDownBar;
    public Transform bar;
    public KeyCode abilityHotkey;
    private void Update()
    {
        int limit = coolDown > 0 ? 1 : 0;
        coolDownBar.SetActive(coolDown > 0);
        coolDown -= Time.deltaTime * limit / 5f;
        if (Input.GetKeyDown(abilityHotkey)) { Ability(); }
        bar.localScale = new Vector3(coolDown, 1, 1);
    }
    public SpriteRenderer invulSprite;
    public SpriteRenderer vulSprite;
    public Color invulColor;
    public Color vulColor;
    private void colorChange()
    {
        if (invul.invul == 1)
        {
            invulSprite.color = invulColor;
            vulSprite.color = vulColor;
        }
        else
        {
            invulSprite.color = vulColor;
            vulSprite.color = invulColor;
        }
    }
}
