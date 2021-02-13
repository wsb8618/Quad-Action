using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public RectTransform uiGroup;
    public int[] itemPrice;
    public string[] talkData;
    public Text talkText;
    public Text upDamageText;
    public int upDamageNum = 0;

    Player enterPlayer;
    Weapon enterWeapon;
    Bullet enterBullet;

    public void Update()
    {
        upDamageText.text = "+" + upDamageNum;
    }

    public void Enter(Player player)
    {
        enterPlayer = player;
        uiGroup.anchoredPosition = Vector3.zero;
    }

    public void Exit()
    {
        uiGroup.anchoredPosition = Vector3.down * 2100;
    }

    IEnumerator Talk()
    {
        talkText.text = talkData[1];
        yield return new WaitForSeconds(2f);
        talkText.text = talkData[0];
    }

    public void UpHealth()
    {
        int price = 2000;
        if(price > enterPlayer.coin)
        {
            StopCoroutine(Talk());
            StartCoroutine(Talk());
            return;
        }
        enterPlayer.coin -= price;
        enterPlayer.maxHealth += 20;
        enterPlayer.health += 20;
    }

    public void UpAmmo(Weapon weapon)
    {
        int price = 2400;
        if (price > enterPlayer.coin)
        {
            StopCoroutine(Talk());
            StartCoroutine(Talk());
            return;
        }
        enterPlayer.coin -= price;
        enterWeapon = weapon;
        enterWeapon.maxAmmo += 10;
        enterWeapon.curAmmo += 10;
    }

    public void UpDamage(Bullet bullet)
    {
        int price = 4500;
        if (price > enterPlayer.coin)
        {
            StopCoroutine(Talk());
            StartCoroutine(Talk());
            return;
        }
        enterPlayer.coin -= price;
        enterBullet = bullet;
        enterBullet.damage += enterBullet.damage * 0.1f;
        upDamageNum++;
    }
}
