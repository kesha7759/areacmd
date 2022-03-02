Console.WriteLine("Выберите фигуру \n 1-Треугольник \n 2-Круг");
string figure = Console.ReadLine();
int figureInt;
int.TryParse(figure, out figureInt);
int area;
switch (figureInt)
{
    case 1:
        area = GetTriangleArea();
        if (area == -1) goto default;
        break;
    case 2:
        area = GetRoundArea();
        if (area == -1) goto default;
        break;
    default:
        Console.WriteLine("Oops");
        break;

}
Console.ReadLine();
int GetTriangleArea()
{
    Console.WriteLine("Вы выбрали треугольник");
    Console.WriteLine("Введите первую сторону");
    string a = Console.ReadLine();
    int aInt;
    if (!int.TryParse(a, out aInt)) return - 1;

    Console.WriteLine("Введите вторую сторону");
    string b = Console.ReadLine();
    int bInt;
    if (!int.TryParse(b, out bInt)) return -1;

    Console.WriteLine("Введите третью сторону");
    string c = Console.ReadLine();
    int cInt;
    if (!int.TryParse(c, out cInt)) return -1;
    
    int p = (aInt + bInt + cInt) / 2; //вычисление периметра
    int result = Convert.ToInt32(Math.Sqrt(p *(p-aInt)*(p-bInt)*(p-cInt))); //вычисление площади
    #region вычисление прямоугольного
    List<int> arr = new List<int>{ aInt, bInt, cInt };
    int maxNum = default;
    foreach (var item in arr)
    {
        if (item > maxNum)
            maxNum = item;
    }
    var minValues = arr.Where(x => x != maxNum).ToList();
    bool isRect = Math.Pow(cInt, 2) == Math.Pow(minValues[0], 2) + Math.Pow(minValues[1], 2);
    #endregion
    Console.WriteLine($"Ваш результат: {result}");
    if (isRect)
        Console.WriteLine($"Бонус: прямоугольник треугольный");

    return result;
}
int GetRoundArea()
{
    Console.WriteLine("Вы выбрали круг");
    Console.WriteLine("Введите радиус");
    string a = Console.ReadLine();
    int aInt;
    if (!int.TryParse(a, out aInt)) return -1;

    int result = Convert.ToInt32(Math.PI * Math.Pow(aInt, 2));
    Console.WriteLine($"Ваш результат: {result}");
    return result;
}