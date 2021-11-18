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
        public abstract double GetLenth();
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
            Console.WriteLine("Debug: Vector2D.PrintVectorDescription()");
            Console.Write($"({String.Format("{0:0.00}", X)}, {String.Format("{0:0.00}", Y)})\n");
        }

        public override double GetLenth()
        {
            Console.WriteLine("Debug: Vector2D.GetLenth()");
            return (double)Math.Sqrt(X * X + Y * Y);
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
            Console.WriteLine("Debug: Vector3D.PrintVectorDescription()");
            Console.Write($"({String.Format("{0:0.00}", X)}, {String.Format("{0:0.00}", Y)}, {String.Format("{0:0.00}", Z)})\n");
        }

        public override double GetLenth()
        {
            Console.WriteLine("Debug: Vector3D.GetLenth()");
            return (double)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override double GetComponentSum()
        {
            Console.WriteLine("Debug: Vector3D.GetComponentSum()");
            return X + Y + Z;
        }
    }
    public class Container<T> where T : class
    {
        private T[] elements; 
        private int curElIndex;
        private int lastElIndex = -1;

        public Container()
        {
            Console.WriteLine("Debug: Container - default constructor");
            elements = new T[0];
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
        public void Append(T element)
        {
            Console.WriteLine("Debug: Container.Append()");

            if (lastElIndex == elements.Length - 1)
            {
                ExpandArrayAndCopyContents();
            }
            elements[lastElIndex + 1] = element;
            lastElIndex += 1;
        }
        public void Insert(T element)
        {
            Console.WriteLine("Debug: Container.Insert()");

            if (lastElIndex == elements.Length - 1)
            {
                ExpandArrayAndCopyContents();
            }
            for (int i = lastElIndex; i >= curElIndex; i--)
            {
                elements[i + 1] = elements[i];
            }
            elements[curElIndex] = element;
            lastElIndex += 1;
        }
        private void ExpandArrayAndCopyContents()
        {
            T[] newArrayExpanded = new T[elements.Length + 10]; // Probably not smart
            for (int i = 0; i < elements.Length; i++)
            {
                newArrayExpanded[i] = elements[i];
            }
            elements = newArrayExpanded;
        }
        public void DeleteCurrent()
        {
            Console.WriteLine("Debug: Container.DeleteCurrent()");
            if(elements.Length != 0)
            {
                for (int i = curElIndex; i < lastElIndex; i++)
                {
                    elements[i] = elements[i + 1];
                }
                elements[lastElIndex] = null;
                lastElIndex -= 1;
            }

        }
        public void First()
        {
            Console.WriteLine("Debug: Container.First()");
            curElIndex = 0;
        }
        public void Next()
        {
            Console.WriteLine("Debug: Container.Next()");
            curElIndex += 1;
        }
        public T GetCurrent()
        {
            Console.WriteLine("Debug: Container.GetCurrent()");
            return elements[curElIndex];
        }
        public bool IsEOL()
        {
            Console.WriteLine("Debug: Container.IsEOL()");
            if (curElIndex > lastElIndex)
                return true;

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Container<Vector> container = new Container<Vector>();
            container.Append(new Vector3D(1, 4, -2));
            container.Append(new Vector2D(-3, 2));
            container.Append(new Vector3D(0, 1, -2));

            container.First();
            container.DeleteCurrent();
            container.Next();
            container.Insert(new Vector2D(2, -1));

            Console.WriteLine();
            double totalLength = 0;
            for(container.First(); container.IsEOL() == false; container.Next())
            {
                totalLength += container.GetCurrent().GetLenth();
            }
            Console.WriteLine($"Total length of vectors in container: {String.Format("{0:0.00}", totalLength)}\n");


            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            const int vectorCount = 100;
            const int operationCount = 10000;
            Console.WriteLine($"==== {operationCount} operations on {vectorCount} vectors ====");
            for (int i = 0; i < operationCount; i++)
            {
                container.Append(CreateRandomVector());
                Console.WriteLine();
            }
            container.First();
            for (int i = 0; i < operationCount; i++) 
            {
                if (container.IsEOL())
                {
                    container.First();
                }

                if (container != null)
                {
                    Random rnd = new Random();
                    int nextRandNum = rnd.Next(6);
                    if (nextRandNum == 0)
                    {
                        Vector curEl = container.GetCurrent();
                        curEl.PrintVectorDescription();
                        double length = curEl.GetLenth();
                        Console.WriteLine($"Lenth: {String.Format("{0:0.00}", length)}\n");
                    }
                    else if (nextRandNum == 1)
                    {
                        Vector curEl = container.GetCurrent();
                        curEl.PrintVectorDescription();
                        double sum = curEl.GetComponentSum();
                        Console.WriteLine($"Sum: {String.Format("{0:0.00}", sum)}\n");
                    }
                    else if (nextRandNum == 2)
                    {
                        container.Append(CreateRandomVector());
                    }
                    else if (nextRandNum == 3)
                    {
                        container.Insert(CreateRandomVector());
                    }
                    else
                    {
                        container.DeleteCurrent();
                    }
                    Console.WriteLine();
                }
                container.Next();
            }
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms for {operationCount} operations");

            Vector CreateRandomVector()
            {
                Random rnd = new Random();
                if (rnd.NextDouble() >= 0.5)
                {
                    return new Vector2D(
                        rnd.NextDouble() * 20 - 10,
                        rnd.NextDouble() * 20 - 10);
                }
                else
                {
                    return new Vector3D(
                        rnd.NextDouble() * 20 - 10,
                        rnd.NextDouble() * 20 - 10,
                        rnd.NextDouble() * 20 - 10);
                }
            }
        }
    }
}



