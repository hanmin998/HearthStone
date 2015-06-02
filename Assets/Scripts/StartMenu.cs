using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

    public MovieTexture movTexture;

    public bool isDrawMov = true;

    public bool isShowMessage = false;

    public TweenScale logoTweenScale;

    public TweenPosition selectRoleTween;

    public UISprite hero1;

    private bool isCanShowSelectRole = false;//表示是否可以显示角色选择界面

	// Use this for initialization
	void Start () {
        movTexture.loop = false;
        movTexture.Play();
        logoTweenScale.AddOnFinished(this.OnLogoTweenFinished);
	}
	
	// Update is called once per frame
	void Update () {
        if (isDrawMov) {
            if (Input.GetMouseButtonDown(0) && isShowMessage==false ) {
                isShowMessage = true;
            } else if (Input.GetMouseButtonDown(0) && isShowMessage == true) {
                StopMov();
            }
        }
        if (isDrawMov != movTexture.isPlaying) {
            StopMov();
        }

        if (isCanShowSelectRole && Input.GetMouseButtonDown(0)) {
            //显示角色选择界面
            selectRoleTween.PlayForward();
            isCanShowSelectRole = false;
        }
	}

    void OnGUI() {
        if (isDrawMov) {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture);
            if (isShowMessage) {
                GUI.Label(new Rect(Screen.width / 2 -100 , Screen.height / 2, 200, 40),"再点击一次屏幕退出动画的播放");
            }
        }
    }

    private void StopMov() {
        movTexture.Stop();
        isDrawMov = false;

        logoTweenScale.PlayForward();
    }

    private void OnLogoTweenFinished() {
        isCanShowSelectRole = true;
    }

    public void OnPlaybuttonClick() {
        BlackMask._instance.Show();
        VSShow._instance.Show(hero1.spriteName, "hero" + Random.Range(1, 10));
        StartCoroutine(LoadPlayScene());
    }

    IEnumerator LoadPlayScene() {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel(1);
    }



}
