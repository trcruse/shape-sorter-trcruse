using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4),
                new Rectangle(3.2, 5.9),
                new Square(3),
                new Square(10),
                new Rectangle(2, 3),
                new Circle(2),
                new Rectangle(10, 10),
                new Circle(8)
            };

            // Iterate through shapes
            foreach(IShape shape in shapes)
            {
                Console.WriteLine($"Shape with area {shape.Area}");
            }
            Console.WriteLine("--------------------------------");

            
            // Boolean
            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with area greater than 50");

            foreach (IShape shape in filteredShapes)
            {
               Console.WriteLine($"Shape with area {shape.Area}");
            }
            Console.WriteLine("--------------------------------");



            // Gives back a type object GetType, returns collection of that particular type
            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            foreach(Circle circle in circles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("--------------------------------");



            IEnumerable<Circle> filteredCircles = circles.Where(circle => circle.Area < 70);
            Console.WriteLine("Circles with area less than 70");
            foreach(Circle circle in filteredCircles)
            {
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("--------------------------------");


            
            Console.WriteLine("Combined example");
            //Iterate on where defined
            foreach(Circle circle in shapes.OfType<Circle>().Where(c => c.Radius > 3.5))
            {
                //Filter by radius AND OfType, each function needs to return an object and onward
                Console.WriteLine($"Circle with radius {circle.Radius} and area {circle.Area}");
            }
            Console.WriteLine("--------------------------------");

            //Grouping collections, assigns a key to each group (a type)
            Console.WriteLine("Group by type");
            var groupedShapes = shapes.GroupBy(shape => shape.GetType());
            //Each group is a collection, and inside is a collection
            //When iterating through a group of groups, use double loops
            foreach (var group in groupedShapes)
            {
                //.Name helps descripe the Name
                Console.WriteLine($"Shapes of type {group.Key.Name}");
                foreach(IShape shape in group)
                {
                    Console.WriteLine($"Shape of area {shape.Area}");
                }
            }
            Console.WriteLine("--------------------------------");


            //Even and odds
            var groupedByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach (var group in groupedByArea)
            {
                Console.WriteLine(group.Key ? "Even Areas" : "Odd Areas");
                foreach (IShape shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }
            Console.WriteLine("--------------------------------");


            //Returns shape that has the max area
            var maxiumumArea = shapes.Max(shape => shape.Area);
            Console.WriteLine($"Maximum Area is {maxiumumArea}");


            //Gathers total area of a shape
            Console.WriteLine("--------------------------------");
            var totalArea = shapes.Sum(shape => shape.Area);
            Console.WriteLine($"Total Area is {totalArea}");







            Console.ReadKey();
        }
    }
}
