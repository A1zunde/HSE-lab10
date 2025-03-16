using lab10Classes;
using System;


public class GeoCoordinates : IInit, IComparable<GeoCoordinates>
{
    // Закрытые атрибуты
    public double latitude;
    public double longitude;

    // Статическая переменная для подсчета количества созданных объектов
    public static int objectCount = 0;

    // Свойства для доступа к широте    
    public double Latitude
    {
        get { return latitude; }
        set
        {
            if (value < -90 || value > 90)
                throw new ArgumentOutOfRangeException("Ошибка! Широта может принимать значения между -90 и 90 градусами");
            latitude = value;
        }
    }

    // Свойство для доступа к долготе
    public double Longitude
    {
        get { return longitude; }
        set
        {
            if (value < -180 || value > 180)
                throw new ArgumentOutOfRangeException("Ошибка! Долгота может принимать значения между -180 и 180 градусами");
            longitude = value;
        }
    }

    // Конструктор без параметров
    public GeoCoordinates()
    {
        Latitude = 0;
        Longitude = 0;
        objectCount++;
    }

    // Конструктор с параметрами
    public GeoCoordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        objectCount++;
    }

    // Метод для инициализации с клавиатуры
    public void Init()
    {
        Console.Write("Введите широту (от -90 до 90): ");
        Latitude = double.Parse(Console.ReadLine());
        Console.Write("Введите долготу (от -180 до 180): ");
        Longitude = double.Parse(Console.ReadLine());
    }

    // Метод для инициализации случайными значениями
    public void RandomInit()
    {
        Random rnd = new Random();
        Latitude = rnd.NextDouble() * 180 - 90;
        Longitude = rnd.NextDouble() * 360 - 180;
    }

    // Метод класса для вычисления расстояния до другой точки
    public double DistanceTo(GeoCoordinates other)
    {
        return CalculateDistance(this, other);
    }

    // Функция для перевода градусов в радианы
    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    // Вычисление расстояния между двумя точками
    public static double CalculateDistance(GeoCoordinates pointOrigin, GeoCoordinates pointDestination)
    {
        // Радиус Земли
        const double EarthRadius = 6371.0;

        // Координаты точки начала
        double latitudeOrigin = DegreesToRadians(pointOrigin.Latitude);
        double longitudeOrigin = DegreesToRadians(pointOrigin.Longitude);

        // Координаты конечной точки
        double latitudeDestination = DegreesToRadians(pointDestination.Latitude);
        double longitudeDestination = DegreesToRadians(pointDestination.Longitude);

        // Разница между координатами начала и конца (расстояние)
        double distanceLatitude = latitudeDestination - latitudeOrigin;
        double distanceLongitude = longitudeDestination - longitudeOrigin;

        double a = Math.Sin(distanceLatitude / 2) * Math.Sin(distanceLatitude / 2) +
                   Math.Cos(latitudeOrigin) * Math.Cos(latitudeDestination) *
                   Math.Sin(distanceLongitude / 2) * Math.Sin(distanceLongitude / 2);

        double c = 2 * Math.Asin(Math.Sqrt(a));

        return Math.Round(EarthRadius * c, 3);
    }

    // Метод для получения количества созданных объектов
    public static int GetObjectCount()
    {
        return objectCount;
    }

    // Переопределение метода ToString
    public override string ToString()
    {
        return $"Широта: {Latitude}, Долгота: {Longitude}";
    }

    // Переопределение метода Equals
    public override bool Equals(object obj)
    {
        if (obj is GeoCoordinates other)
        {
            return Latitude == other.Latitude && Longitude == other.Longitude;
        }
        return false;
    }
    public int CompareTo(GeoCoordinates other)
    {
        return Latitude.CompareTo(other.Latitude);
    }

    public void PrintCoordinates()
    {
        Console.WriteLine($"Latitude: {Math.Round(latitude, 2)}, Longitude: {Math.Round(longitude, 2)}");
    }
}

public class LongitudeComparer : IComparer<GeoCoordinates>
{
    public int Compare(GeoCoordinates x, GeoCoordinates y)
    {
        return x.Longitude.CompareTo(y.Longitude);
    }
}
