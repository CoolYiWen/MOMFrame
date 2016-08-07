using UnityEngine;
using System.Collections;
/**
Observe
被监听者：挂载该脚本，调用该脚本中的事件触发函数

监听者：GameObject.Find("gameObject").GetComponent<UIEventDispatcher>.DO +(-)= listener;
       GetEvent(Object sender, DoEventArgs e)
       {
            T mSender = (T) sender;
            e.arg ...
       }
*/
public class UIEventDispatcher : MonoBehaviour
{
    /// <summary>
    /// 事件只传递本身GameObject
    /// </summary>
    public delegate void EventHandler (GameObject e);
    public event EventHandler MouseOver;//鼠标悬浮
    public void OnMouseOver ()
    {
        if (MouseOver != null)
            MouseOver (this.gameObject);
    }
    public event EventHandler MouseDown;//鼠标保持按下
    void OnMouseDown ()
    {
        if (MouseDown != null)
            MouseDown (this.gameObject);
    }
    public event EventHandler MouseEnter;//鼠标点击完成
    void OnMouseEnter ()
    {
        if (MouseEnter != null)
            MouseEnter (this.gameObject);
    }
    public event EventHandler MouseExit;//鼠标离开
    void OnMouseExit ()
    {
        if (MouseExit != null)
            MouseExit (this.gameObject);
    }
    public event EventHandler BecameVisible;//对象被显示
    void OnBecameVisible ()
    {
        if (BecameVisible != null)
            BecameVisible (this.gameObject);
    }
    public event EventHandler BecameInvisible;//对象被隐藏
    void OnBecameInvisible ()
    {
        if (BecameInvisible != null)
            BecameInvisible (this.gameObject);
    }

    /// <summary>
    /// 事件传递本身GameObject和其它附带参数
    /// </summary>


}