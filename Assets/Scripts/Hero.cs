using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

    public int maxHp = 30;
    public int minHp = 0;

    protected UISprite sprite;
    private UILabel hpLabel;
    private int hpCount = 30;

    void Awake() {
        sprite = this.GetComponent<UISprite>();

        hpLabel = this.transform.Find("hp").GetComponent<UILabel>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.E)) {
            TakeDamage(Random.Range(1, 5));
        }
        if (Input.GetKey(KeyCode.R)) {
            PlusHp(Random.Range(1, 5));
        }
    }


    //这个方法用来吸收伤害值
    public void TakeDamage(int damage) {
        hpCount -= damage;
        hpLabel.text = hpCount + "";

        if (hpCount <= minHp) {
            //处理游戏结束的逻辑
        }
    }
    public void PlusHp(int hp) {
        hpCount += hp;
        if (hpCount >= maxHp) {
            hpCount = maxHp;
        }
        hpLabel.text = hpCount + "";
    }

}
