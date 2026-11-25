using System;

namespace Medvedev
{
    public interface IFigure
    {
        void MoveHorizontal(double dx);
        void MoveVertical(double dy);
        void ChangeColor(string newColor);
        void ToggleVisibility();
        void Show();
    }

    public abstract class Figure : IFigure
    {
        protected string color;
        protected bool isVisible;

        protected Figure(string color)
        {
            this.color = color;
            this.isVisible = true;
        }

        public string Color { get { return color; } }
        public bool IsVisible { get { return isVisible; } }

        public virtual void MoveHorizontal(double dx) { }
        public virtual void MoveVertical(double dy) { }

        public void ChangeColor(string newColor) { color = newColor; }
        public void ToggleVisibility() { isVisible = !isVisible; }

        public virtual void Show()
        {
            Console.Write($"{GetType().Name}: цвет={color}, видимая={(isVisible ? "да" : "нет")}");
        }
    }

    public class Point : Figure
    {
        protected double x;
        protected double y;

        public Point() : this(0, 0, "чёрный") { }
        public Point(double x, double y) : this(x, y, "чёрный") { }

        public Point(double x, double y, string color) : base(color)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get { return x; } }
        public double Y { get { return y; } }

        public override void MoveHorizontal(double dx) { x += dx; }
        public override void MoveVertical(double dy) { y += dy; }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($", x={x}, y={y}");
        }
    }

    public class Circle : Point
    {
        private double radius;

        public Circle(double x, double y, double radius, string color) : base(x, y, color)
        {
            this.radius = radius;
        }

        public double Radius { get { return radius; } }

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($", радиус={radius}, площадь={Area():F2}");
        }
    }

    public class Rectangle : Point
    {
        private double width;
        private double height;

        public Rectangle(double x, double y, double width, double height, string color) : base(x, y, color)
        {
            this.width = width;
            this.height = height;
        }

        public double Width { get { return width; } }
        public double Height { get { return height; } }

        public double Area()
        {
            return width * height;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($", ширина={width}, высота={height}, площадь={Area():F2}");
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Point p = new Point(3, 4, "красный");
            Circle c = new Circle(0, 0, 5, "синий");
            Rectangle r = new Rectangle(10, 10, 4, 6, "зелёный");

            Console.WriteLine("=== Исходное состояние ===");
            p.Show();
            c.Show();
            r.Show();

            Console.WriteLine("\n=== После операций ===");
            p.MoveHorizontal(2);
            p.MoveVertical(-1);
            p.ChangeColor("жёлтый");
            p.ToggleVisibility();

            c.MoveHorizontal(-3);
            c.MoveVertical(5);
            c.ChangeColor("оранжевый");

            r.MoveHorizontal(1.5);
            r.MoveVertical(2.5);
            r.ChangeColor("фиолетовый");
            r.ToggleVisibility();

            p.Show();
            c.Show();
            r.Show();
        }
    }
}