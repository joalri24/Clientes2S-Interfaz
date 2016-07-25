using System;

class myGroupBox : GroupBox
{
    public myGroupBox()
    {
        base.BackColor = Color.Transparent;

    }
    [Browsable(false)]
    public override Color BackColor
    {
        get
        {
            return base.BackColor;
        }
        set
        {
            base.BackColor = value;
        }
    }

    private Color backColor = Color.Transparent;

    public Color ActualBackColor
    {
        get { return this.backColor; }

        set { this.backColor = value; }
    }

    protected override void OnPaint(PaintEventArgs e)
    {

        Size tSize = TextRenderer.MeasureText(this.Text, this.Font);

        Rectangle borderRect = e.ClipRectangle;

        borderRect.Y += tSize.Height / 2;

        borderRect.Height -= tSize.Height / 2;

        GraphicsPath gPath = CreatePath(0, borderRect.Y, (float)(this.Width - 1), borderRect.Height - 1, 5, true, true, true, true);

        e.Graphics.FillPath(new SolidBrush(ActualBackColor), gPath);

        e.Graphics.DrawPath(new Pen(Color.Red), gPath);

        borderRect.X += 6;
        borderRect.Y -= 7;

        e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), borderRect);
    }
}