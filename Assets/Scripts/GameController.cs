using UnityEngine;
using System.Collections;

public enum GameState { 
    CardGenerating,//系统随机发放卡牌的阶段
    PlayCard,//出牌对战阶段
    End//游戏结束阶段
}

public class GameController : MonoBehaviour {
    
    public GameState gameState = GameState.CardGenerating;
    public float cycleTime = 60f;
    public MyCard myCard;

    private UISprite wickpopeSprite;
    private float timer = 0;
    private float wickpopeLength;
    private string currenHeroName = "hero1";//当前回合英雄
    private CardGenerator cardGenerator;

    void Awake() {
        wickpopeSprite = this.transform.Find("wickpope").GetComponent<UISprite>();
        wickpopeLength = wickpopeSprite.width;
        wickpopeSprite.width = 0;
        this.cardGenerator = this.GetComponent<CardGenerator>();
        //给当前回合的英雄发牌 默认是hero1
        StartCoroutine( GenerateCardForHero1());
    }

    void Update() {
        if (gameState == GameState.PlayCard) {//当游戏状态为对战阶段的时候，才会开始计时
            timer += Time.deltaTime;
            if (timer > cycleTime) {
                //强制结束当前回合，进行下一个回合
                TransformPlayer();
            } else if ((cycleTime - timer) <= 15) {//如果当前剩余时间小于15s的时候，我们就要显示绳子的动画
                wickpopeSprite.width =(int) ( ((cycleTime - timer) / 15f) * wickpopeLength);
            }
        }
    }

    private void TransformPlayer() {
    }

    private IEnumerator GenerateCardForHero1() {
        //最开始发牌是发4张牌
        GameObject cardGo = cardGenerator.RandomGenerateCard();//调用方法随机生成一个卡牌//要等2
        yield return new WaitForSeconds(2f);
        //把这个卡片放在 卡牌管理内
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerateCard();//生成第二个卡片
        yield return new WaitForSeconds(2f); 
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerateCard();//生成第二个卡片
        yield return new WaitForSeconds(2f);
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerateCard();//生成第二个卡片
        yield return new WaitForSeconds(2f);
        myCard.AddCard(cardGo);
    }
}
