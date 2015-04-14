/**
 * DataBinding Example
 * 結局これだと、上手くまとめられない（Updateという名前のHandlerだけでは、どのデータが更新されたのかわからないので）
 */
using UnityEngine;
using System;

/**
 * This is a Obsesrvable Class
 */
public class FooData
{
	public event EventHandler<FooData> Update;

	private int bar;
	private long baz;
	private string qux;

	public int Bar
	{
		get { return bar; }
		set
		{
			if (value != bar) {
				bar = value;
				var args = new BarChangedEventArgs();
				args.Value = value;
				Update(this, args);
			}
		}
	}

	// 同上
	public long Baz { set; get; }
	public string Qux { set; get; }
}

/**
 * （型を無視するため）単一のプロパティを含むEventArgsクラス
 */
class BarChangedEventArgs : EventArgs
{
	public int Value { set; get; }
}

class BazChangedEventArgs : EventArgs
{
	public long Value { set; get; }
}

class QuxChangedEventArgs : EventArgs
{
	public string Value { set; get; }
}



/**
 * This is a Observer Class
 */
public class View
{
	public UILabel Label;

	public FooData DataSource
	{
		set {
			value.Update += HandleUpdate;
		}
	}

	void HandleUpdate(Object sender, EventArgs e)
	{
		Label.text = e.Value.ToString();
	}
}