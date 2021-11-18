using System;
using System.Collections;

namespace container
{
    public abstract class Vector
    {
        public Vector()
        {
            Console.WriteLine("Debug: Vector - default constructor");
        }
        ~Vector()
        {
            Console.WriteLine("Debug: Vector - destructor");
        }
        public abstract void PrintVectorDescription();
        public abstract double GetLengh();
        public abstract double GetAngleWithUnitVector();
        public abstract double GetComponentSum();

    }

    public class Vector2D : Vector
    {
        private double _x;
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        private double _y;
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Vector2D()
        {
            Console.WriteLine("Debug: Vector2D - default constructor");
            X = Y = 0;
        }
        public Vector2D(double x, double y)
        {
            Console.WriteLine("Debug: Vector2D - constructor with parameters");
            X = x;
            Y = y;
        }
        public Vector2D(Vector2D vector)
        {
            Console.WriteLine("Debug: Vector2D - copy constructor");
            X = vector.X;
            Y = vector.Y;
        }
        ~Vector2D()
        {
            Console.WriteLine("Debug: Vector2D - destructor");
        }

        public override void PrintVectorDescription()
        {
            Console.Write($"({X}, {Y})");
            Console.WriteLine("Debug: Vector2D.PrintVectorDescription()");
        }

        public override double GetLengh()
        {
            Console.WriteLine("Debug: Vector2D.GetLengh()");
            return (double)Math.Sqrt(X * X + Y * Y);
        }

        public override double GetAngleWithUnitVector()
        {
            Console.WriteLine("Debug: Vector2D.GetAngleWithUnitVector()");
            double lengh = GetLengh();
            return Math.Acos(X/lengh + Y/lengh);
        }

        public override double GetComponentSum()
        {
            Console.WriteLine("Debug: Vector2D.GetComponentSum()");
            return X + Y;
        }
    }
    public class Vector3D : Vector
    {
        private double _x;
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        private double _y;
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private double _z;
        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public Vector3D()
        {
            Console.WriteLine("Debug: Vector3D - default constructor");
            X = Y = Z = 0;
        }
        public Vector3D(double x, double y, double z)
        {
            Console.WriteLine("Debug: Vector3D - constructor with parameters");
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3D(Vector3D vector)
        {
            Console.WriteLine("Debug: Vector3D - copy constructor");
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }
        ~Vector3D()
        {
            Console.WriteLine("Debug: Vector3D - destructor");
        }

        public override void PrintVectorDescription()
        {
            Console.Write($"({X}, {Y}, {Z})");
            Console.WriteLine("Debug: Vector3D.PrintVectorDescription()");
        }

        public override double GetLengh()
        {
            Console.WriteLine("Debug: Vector3D.GetLengh()");
            return (double)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override double GetAngleWithUnitVector()
        {
            Console.WriteLine("Debug: Vector3D.GetAngleWithUnitVector()");
            double lengh = GetLengh();
            return Math.Acos(X / lengh + Y / lengh + Z / lengh);
        }

        public override double GetComponentSum()
        {
            Console.WriteLine("Debug: Vector3D.GetComponentSum()");
            return X + Y + Z;
        }
    }
    public class Container<T>
    {
        private T[] elements;
        private int curEl;

        public Container(int size)
        {
            Console.WriteLine("Debug: Container - constructor with parameters");
            elements = new T[size];
        }
        public Container(Container<T> container)
        {
            Console.WriteLine("Debug: Container - copy constructor");
            this.elements = container.elements;
        }
        ~Container()
        {
            Console.WriteLine("Debug: Container - destructor");
        }
        public bool Add(T element)
        {
            Console.WriteLine("Debug: Container.Add()");

            int i = 0;
            for(; elements[i] != null; i++)
            {
                if(i >= elements.Length)
                {
                    return false;
                }
            }
            elements[i] = element;
            return true;
        }
        public void First()
        {
            Console.WriteLine("Debug: Container.First()");
            curEl = 0;
        }
        public void Next()
        {
            Console.WriteLine("Debug: Container.Next()");
            curEl += 1;
        }
        public T GetCurrent()
        {
            Console.WriteLine("Debug: Container.GetCurrent()");
            return elements[curEl];
        }
        public bool IsEOL()
        {
            Console.WriteLine("Debug: Container.IsEOL()");
            if (curEl >= elements.Length)
                return true;

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Container<Vector> container = new Container<Vector>(10);
            for(int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                if (rnd.NextDouble() >= 0.5)
                {
                    container.Add(new Vector2D(
                        rnd.NextDouble() * 20 - 10,
                        rnd.NextDouble() * 20 - 10));
                }
                else
                {
                    container.Add(new Vector3D(
                        rnd.NextDouble() * 20 - 10,
                        rnd.NextDouble() * 20 - 10,
                        rnd.NextDouble() * 20 - 10));
                }
            }
        }
    }
}



