/**
 * DataBinding Example
 */
using UnityEngine;
using System;

/**
 * This is a Obsesrvable Class
 */
public class FooData
{
	public event Action<int> UpdateBar;
	public event Action<long> UpdateBaz;
	public event Action<string> UpdateQux;

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
				UpdateBar(value);
			}
		}
	}

	public long Baz
	{
		get { return baz; }
		set
		{
			if (value != baz) {
				baz = value;
				UpdateBaz(value);
			}
		}
	}

	public string Qux
	{
		get { return qux; }
		set
		{
			if (value != qux) {
				qux = value;
				UpdateQux(value);
			}
		}
	}
}



/**
 * This is a Observer Class
 */
public class QuxView
{
	public UILabel Label;

	public FooData DataSource
	{
		set {
			value.UpdateQux += Update;
		}
	}

	void Update(String text)
	{
		Label.text = text;
	}
}



class Program
{
	static void Main()
	{
		var fooData = new FooData();
		var quxView = new QuxView();

		quxView.DataSource = fooData;
		fooData.Qux = "Hello World"; // When Data is changed, QuxView's text will be also changed immediately.
	}
}