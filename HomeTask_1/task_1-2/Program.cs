//Вітаю. Перше завдання по створенню репозиторію Ви виконали.
Console.Write("Please enter amount of rows: ");
int rows = 0;
Int32.TryParse(Console.ReadLine(), out rows);

Console.Write("Please enter amount of columns: ");
int columns = 0;
Int32.TryParse(Console.ReadLine(), out columns);

Console.WriteLine();

Matrix matrix1 = new Matrix(rows, columns);
matrix1.FillSpirally();
Console.WriteLine("Matrix:");
matrix1.Print();

Console.WriteLine();

Matrix matrix2 = new Matrix(rows, columns);
matrix2.Fill();
Console.WriteLine("Matrix:");
matrix2.Print();
Console.WriteLine();
var result = matrix2.LongestSequence();
Console.WriteLine($"First index: {result.first};\nLast index: {result.last};\nLength: {result.count};\nRow: {result.rowNumber};");
