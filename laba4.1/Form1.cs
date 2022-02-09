﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4._1
{

    public partial class Form1 : Form
    {
        public class CCircle
        {
            int _x, _y, _radius;
            private bool _selected;
            System.Windows.Forms.Button circle = new System.Windows.Forms.Button();
            //public System.Windows.Forms.MouseEventHandler click_circle;

            public CCircle()
            {
                _x = 0; _y = 0; _radius = 0;
                circle.Width = 60;
                circle.Height = 60;
                circle.FlatStyle = FlatStyle.Flat;
                circle.FlatAppearance.BorderSize = 0;
                circle.Location = new System.Drawing.Point(_x - circle.Width / 2, _y - circle.Height / 2);
                circle.BackColor = System.Drawing.Color.Green;

                //circle.Click += new EventHandler(select_circle);

                System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
                gPath.AddEllipse(0, 0, 60, 60);
                Region rg = new Region(gPath);
                circle.Region = rg;
            }
            public CCircle(int x, int y)
            {
                _x = x; _y = y; _radius = 30;
                circle.Width = _radius * 2;
                circle.Height = _radius * 2;
                circle.FlatStyle = FlatStyle.Flat;
                circle.FlatAppearance.BorderSize = 0;

                circle.Location = new System.Drawing.Point(_x - circle.Width / 2, _y - circle.Height / 2);
                circle.BackColor = System.Drawing.Color.Green;

                System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
                gPath.AddEllipse(0, 0, _radius * 2, _radius * 2);
                Region rg = new Region(gPath);
                circle.Region = rg;
            }
            public CCircle(int x, int y, int radius)
            {
                _x = x; _y = y; _radius = radius;
                circle.Width = _radius * 2;
                circle.Height = _radius * 2;
                circle.FlatStyle = FlatStyle.Flat;
                circle.FlatAppearance.BorderSize = 0;
                circle.Location = new System.Drawing.Point(_x - circle.Width / 2, _y - circle.Height / 2);
                circle.BackColor = System.Drawing.Color.Green;

                System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
                gPath.AddEllipse(0, 0, _radius * 2, _radius * 2);
                Region rg = new Region(gPath);
                circle.Region = rg;
            }


            public System.Windows.Forms.Button inside()
            {
                return circle;
            }
            public bool select()
            {
                return _selected;
            }
            public bool select(bool _select)
            {
                if (_select)
                {
                    this._selected = true;
                    circle.BackColor = System.Drawing.Color.Purple;
                    return true;
                }
                else
                {
                    this._selected = false;
                    circle.BackColor = System.Drawing.Color.Green;
                    return false;
                }
            }
        }

        public class Storage
        {
            int _size;
            public CCircle[] massive;
            public int size() { return _size; }
            public void add(int x, int y)
            {
                int i = 0;
                while (i <_size && massive[i] != null)
                {
                    i++;
                }
                if (i != _size)
                {
                    massive[i] = new CCircle(x, y);
                    massive[i].inside().Name = (i).ToString();
                }
            }
            public void add(CCircle obj)
            {
                int i = 0;
                while (i < _size && massive[i] != null)
                {
                    i++;
                }
                if (i != _size)
                {
                    massive[i] = obj;
                    massive[i].inside().Name = (i).ToString();
                }
            }
            public int del_selected()
            {
                int i = 0;
                int k = 0;
                while (i<_size)
                {
                    if (massive[i] != null && massive[i].select())
                    {
                            massive[i] = null;
                            k++;
                    }
                    i++;
                }
                return k;
            }
            public CCircle get(int i)
            {
                if (i < _size)
                {
                    return massive[i];
                }
                return null;
            }
            public Storage()
            {
                _size = 100;
                massive = new CCircle[100];
            }
            public Storage(int n)
            {
                _size = n;
                massive = new CCircle[n];
            }
        }
        Storage storage = new Storage();
        int i = 0;
        public Form1()
        {
            InitializeComponent();

        }

        /*        public class CCircle : Object
        {
            float _x,_y;
            Pen _pen;
            float _radius;
            private PointF[] curvepoints;
            public override string get_classname() { return _name; }
            protected void set_points(int i,float _d)
            {
                curvepoints[i] = new PointF(_x - _d, _y + _d);
                curvepoints[i + 2] = new PointF(_x - _d, _y - _d);
                curvepoints[i + 4] = new PointF(_x + _d, _y - _d);
                curvepoints[i + 6] = new PointF(_x + _d, _y + _d);

            }
            public void set_points()
            {
                float _d = _radius * Convert.ToSingle(Math.Sqrt(2)) / 2;
                set_points(0, _radius);
                set_points(1, _d);
            }
            public PointF[] get_points() { return curvepoints; }
            public Pen get_pen() { return _pen; }
            public CCircle()
            {
                _name = "Circle";
            }
            public CCircle(float x,float y,float r)
            {
                _x = x; _y = y;
                _radius = r;
                curvepoints = new PointF[8];
                _pen = new Pen(Brushes.Red);
                set_points();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            CCircle circle = new CCircle(20,20,10);
            e.Graphics.DrawPolygon(circle.get_pen(),circle.get_points() );
        }*/


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            i++;
            CCircle circle = new CCircle(e.X, e.Y);
            storage.add(circle);
            if (circle != null)
            {
                circle.inside().MouseClick += select_circle;
                circle.inside().KeyDown += del_selected_circle;
                this.Controls.Add(circle.inside());
                label1.Text = i.ToString();
            }
        }
        private void select_circle(object sender, MouseEventArgs e)
        {
            int k = 0;
            CCircle circle = null;
            int size = storage.size();
            while (k < size)
            {
                if(storage.get(k) == null) { 
                
                }
                else
                {
                    if(sender == storage.get(k).inside())
                    {
                        circle = storage.get(k);
                        circle.select(!circle.select());
                    }
                }
                k++;
            }
        }
        private void del_selected_circle(object sender, KeyEventArgs e)
        {
            CCircle circle = null;
            int k = 0;
            int size = storage.size();
            while(k<size)
            {
                circle = storage.get(k);
                if (circle!=null&&circle.select())
                {
                    Controls.Remove(circle.inside());
                }
                k++;
            }
            i = i - storage.del_selected();
            label1.Text = i.ToString();
        }
        private void paint(object sender, EventArgs e)
        {
            int size = storage.size();
            int k = 0;
            CCircle circle = null;
            Controls.Clear();
            while (k<size)
            {
                circle = storage.get(k);
                if (circle != null)
                {
                    Controls.Add(circle.inside());
                }
            }
        }

    }
}