using System;

class triugolnik
{
    private double[] sides;
    public triugolnik(double a, double b, double c)
    {
        sides = new double[] { a, b, c };
        if (!prover())
        {
            throw new ArgumentException("треугольник с такими сторонами не существует");
        }
    }

    
    private bool prover()
    {
        return sides[0] + sides[1] > sides[2] &&
               sides[0] + sides[2] > sides[1] &&
               sides[1] + sides[2] > sides[0];
    }

    
    public double calculatepl()
    {
        double p = (sides[0] + sides[1] + sides[2]) / 2; 
        return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
    }

    
    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= sides.Length)
                throw new IndexOutOfRangeException("индекс должен быть от 0 до 2");
            return sides[index];
        }
        set
        {
            if (index < 0 || index >= sides.Length)
                throw new IndexOutOfRangeException("индекс должен быть от 0 до 2");
            sides[index] = value;
            if (!prover())
                throw new ArgumentException("треугольник с такими сторонами не существует");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            
            triugolnik triangle = new triugolnik(3, 4, 5);

            
            double area = triangle.calculatepl();
            Console.WriteLine($"площадь треугольника: {area}");

            
            Console.WriteLine($"стороны треугольника: {triangle[0]}, {triangle[1]}, {triangle[2]}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"ошибка: {ex.Message}");
        }
    }
}