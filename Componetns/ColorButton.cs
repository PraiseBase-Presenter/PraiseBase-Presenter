using System;
using System.Windows.Forms;
using System.Drawing;

namespace Pbp
{

public class ColorButton : Button
{			
	Color centerColor;
	
	public ColorButton()
	{		
		MouseEnter += new EventHandler(OnMouseEnter);
		MouseLeave += new EventHandler(OnMouseLeave);					
		MouseUp += new MouseEventHandler(OnMouseUp);						
		Paint += new PaintEventHandler(ButtonPaint);	
	}
	
	public Color CenterColor
	{
		get{ return centerColor; }
		set{ centerColor = value; }
	}		
	
	void OnMouseEnter(object sender, EventArgs e)
	{			
		Invalidate();
	}
	
	void OnMouseLeave(object sender, EventArgs e)
	{					
		Invalidate();
	}	
	
	void OnMouseUp(object sender, MouseEventArgs e)
	{				
		Invalidate();
	}
	
	void ButtonPaint(Object sender, PaintEventArgs e)
	{					
		Graphics g = e.Graphics ; 		
		
		Rectangle r = ClientRectangle;	
		
		byte border = 4;
		byte right_border = 15;
		
		Rectangle rc = new Rectangle(r.Left + border, r.Top + border,
		                             r.Width - border - right_border - 1, r.Height - border * 2 - 1);
		
		SolidBrush centerColorBrush = new SolidBrush( centerColor );
		g.FillRectangle(centerColorBrush, rc);	
		
		Pen pen = new Pen( Color.Black ); 
		g.DrawRectangle( pen, rc );		
		
		//draw the arrow
		Point p1 = new Point( r.Width - 9, r.Height / 2 - 1 );
		Point p2 = new Point(r.Width - 5, r.Height / 2 - 1 );		
		g.DrawLine(pen, p1, p2);
		
		p1 = new Point( r.Width - 8, r.Height / 2 );
		p2 = new Point(r.Width - 6, r.Height / 2 );		
		g.DrawLine(pen, p1, p2);
		
		p1 = new Point( r.Width - 7, r.Height / 2 );
		p2 = new Point(r.Width - 7, r.Height / 2 + 1 );		
		g.DrawLine(pen, p1, p2);
		
		//draw the divider line
		pen = new Pen( SystemColors.ControlDark ); 
		p1 = new Point( r.Width - 12, 4 );
		p2 = new Point(r.Width - 12, r.Height - 5 );		
		g.DrawLine(pen, p1, p2);
		
		pen = new Pen( SystemColors.ControlLightLight ); 
		p1 = new Point( r.Width - 11, 4 );
		p2 = new Point(r.Width - 11, r.Height - 5 );		
		g.DrawLine(pen, p1, p2);
	} 
}

}

