using System;

namespace container
{
    abstract class Vector
    {
        public Vector()
        {
            Console.WriteLine("Debug: Vector - default constructor\n");
        }
        ~Vector()
        {
            Console.WriteLine("Debug: Vector - destructor\n");
        }
        public abstract void PrintVectorDescription();
        public abstract double GetLengh();
        public abstract double GetAngleWithUnitVector();
        public abstract double GetComponentSum();

    }

    class Vector2D : Vector
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

        Vector2D()
        {
            Console.WriteLine("Debug: Vector2D - default constructor\n");
            X = Y = 0;
        }
        Vector2D(double x, double y)
        {
            Console.WriteLine("Debug: Vector2D - constructor with parameters\n");
            X = x;
            Y = y;
        }
        Vector2D(Vector2D vector)
        {
            Console.WriteLine("Debug: Vector2D - copy constructor\n");
            X = vector.X;
            Y = vector.Y;
        }
        ~Vector2D()
        {
            Console.WriteLine("Debug: Vector2D - destructor\n");
        }

        public override void PrintVectorDescription()
        {
            Console.WriteLine($"({X}, {Y})");
            Console.WriteLine("Debug: Vector2D.PrintVectorDescription()\n");
        }

        public override double GetLengh()
        {
            Console.WriteLine("Debug: Vector2D.GetLengh()\n");
            return (double)Math.Sqrt(X * X + Y * Y);
        }

        public override double GetAngleWithUnitVector()
        {
            Console.WriteLine("Debug: Vector2D.GetAngleWithUnitVector()\n");
            double lengh = GetLengh();
            return Math.Acos(X/lengh + Y/lengh);
        }

        public override double GetComponentSum()
        {
            Console.WriteLine("Debug: Vector2D.GetComponentSum()\n");
            return X + Y;
        }
    }
    class Vector3D : Vector
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

        Vector3D()
        {
            Console.WriteLine("Debug: Vector3D - default constructor\n");
            X = Y = Z = 0;
        }
        Vector3D(double x, double y, double z)
        {
            Console.WriteLine("Debug: Vector3D - constructor with parameters\n");
            X = x;
            Y = y;
            Z = z;
        }
        Vector3D(Vector3D vector)
        {
            Console.WriteLine("Debug: Vector3D - copy constructor\n");
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }
        ~Vector3D()
        {
            Console.WriteLine("Debug: Vector3D - destructor\n");
        }

        public override void PrintVectorDescription()
        {
            Console.WriteLine($"({X}, {Y}, {Z})");
            Console.WriteLine("Debug: Vector3D.PrintVectorDescription()\n");
        }

        public override double GetLengh()
        {
            Console.WriteLine("Debug: Vector3D.GetLengh()\n");
            return (double)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override double GetAngleWithUnitVector()
        {
            Console.WriteLine("Debug: Vector3D.GetAngleWithUnitVector()\n");
            double lengh = GetLengh();
            return Math.Acos(X / lengh + Y / lengh + Z / lengh);
        }

        public override double GetComponentSum()
        {
            Console.WriteLine("Debug: Vector3D.GetComponentSum()\n");
            return X + Y + Z;
        }
    }
    class Container<T>
    {
        private List<T> elements;
        private int curEl;

        Container()
        {
            elements = new List<T>();
        }
        Container(List<T> list)
        {
            elements = list;
        }
        Container(Container<T> container)
        {
            this.elements = container.elements;
        }
        ~Container()
        {

        }

        public void First()
        {
            curEl = 0;
        }
        public void Next()
        {
            curEl += 1;
        }
        public T GetCurrent()
        {
            return elements[curEl];
        }
        public bool IsEOL()
        {
            if(curEl >= elements.Count)
                return true;

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


        }
    }
}



