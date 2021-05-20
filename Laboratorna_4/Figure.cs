using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;



namespace Laboratorna4
{
    
public abstract class Figure
    {
       
        public int x { get; set; }
        public int y { get; set; }
        public abstract void DrawBlack(PictureBox p);
        public abstract void HideDrawingBackGround(PictureBox p);
        public void MoveRight(PictureBox p)
        { 
            HideDrawingBackGround(p);
            x+=10;
            DrawBlack(p);
            
        }

    }
    class Circle : Figure
    {
        
        double radius { get; set; }
        public Circle() { }
        public Circle(double radius) { this.radius = radius; }
        public Circle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Circle(int x, int y, double radius)
        {
            this.radius = radius;
            this.x = x;
            this.y = y;
        }
        public override void DrawBlack(PictureBox p)
        {

            using (var g = Graphics.FromImage(p.Image))
            {
                g.DrawEllipse(Pens.Black, x, y, (int)radius, (int)radius);
            }
        }
        public override void HideDrawingBackGround(PictureBox p)
        {
            using (var g = Graphics.FromImage(p.Image))
            {
                g.DrawEllipse(Pens.White, x, y, (int)radius, (int)radius);
               
            }
           
        }
    }
    class Square : Figure
    {
        private double side { get; set; }
        public Square() { }
        public Square(int sideLength) { this.side = sideLength; }
        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Square(int x, int y, double side)
        {
            this.side = side;
            this.x = x;
            this.y = y;
        }
        public override void DrawBlack(PictureBox p)
        {
            Pen c = Pens.Black;
            using (var g = Graphics.FromImage(p.Image))
            {
                g.DrawRectangle(c,x, y, (int)side, (int)side);
            }
         
        }
        public override void HideDrawingBackGround(PictureBox p)
        {
            Pen c = Pens.White;
            using (var g = Graphics.FromImage(p.Image))
            {
                g.DrawRectangle(c, x, y, (int)side, (int)side);
            }
          
        }
    }
    class Rhomb : Figure
    {
        private double horDiag { get; set; }
        
        private double vertDiag { get; set; }
    
        public Rhomb() { }
        public Rhomb(double horDiagLen, double vertDiagLen)
        {
            this.horDiag = horDiagLen;
            this.vertDiag = vertDiagLen;
        }
        public Rhomb(int x, int y, double horDiagLen, double vertDiagLen)
        {
            this.x = x;
            this.y = y;
            this.horDiag = horDiagLen;
            this.vertDiag = vertDiagLen;
        }

        public override void DrawBlack(PictureBox p)
        {
           
            Pen c = Pens.Black;
            using (var g = Graphics.FromImage(p.Image))
            {

                Rectangle r = new Rectangle(x, y, (int)horDiag, (int)vertDiag);
                using (Matrix m = new Matrix())
                {
                    m.RotateAt(45, new PointF(r.Left + (r.Width / 2),
                                              r.Top + (r.Height / 2)));

                    g.Transform = m;
                    g.DrawRectangle(c, r);

                }

              
            }
        }
        public override void HideDrawingBackGround(PictureBox p)
        {
          
            Pen c = Pens.White;
            using (var g = Graphics.FromImage(p.Image))
            {

                Rectangle r = new Rectangle(x, y, (int)horDiag, (int)vertDiag);
                using (Matrix m = new Matrix())
                {
                    m.RotateAt(45, new PointF(r.Left + (r.Width / 2),
                                              r.Top + (r.Height / 2)));

                    g.Transform = m;
                    g.DrawRectangle(c, r);

                }

               
            }
        }
    }
}
