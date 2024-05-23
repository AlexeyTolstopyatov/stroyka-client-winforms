## Файлы классов-менеджеров
Указаны по адресу ```/strc/sqlserver```, необходимы для быстрого взаимодействия с объектами информационной системы.
Вместо того, чтобы использовать проверку соединения и получения таблицы вручную, как указано на примере ниже:
```csharp
using (SqlConnection connection = new SqlConnection("Your string here")
using (SqlCommand command = "SELECT * FROM [имя таблицы]")
{
  await connection.OpenAsync();
  // или
  connection.Open();

  // логика получения таблицы
}
```
Используйте функцию ```ExecuteMapAsync()```
```csharp
DataTable source = await ExecuteMapAsync("SELECT * FROM [имя таблицы]");
```
Все остальные функции из /strc/sqlserver описаны подобным образом, как например настроенный ```ExecuteScalarAsync()```
```csharp 
QueryManager.ExecuteInt32(string);
```
возврашает ```object``` результат (текст ячейки) первого столбца первой строки.


## Файлы безопасности
В папке ```/strc/security``` создан класс для быстрой перезаписи и сжатия строк данных. Класс ```Compressor``` предоставляет функции
```csharp
Compressor.FromBytes(string);
Compressor.ToBytes(string);
```
Функции перевода данных представляют очень урезанный, но необходимый функционал, как пример попытки защиты данных для Демонстрационного экзамена
```csharp
string name = "OlEg";
string compressed = await Compressor.ToBytes(name); // compressed будет выглядеть как "0JDQu9C10LrRgdC10Lk="
```
По такому же принципу работает функция ```FromBytes```, которая вернет из "0JDQu9C10LrRgdC10Lk=" имя указанное когда-то

## Что такое await?
Использование асинхронных функций и их смысл написан в моем уроке по Асинхронным Операциям
https://github.com/AlexeyTolstopyatov/traffic-async-lesson-winforms
В ```traffic-async-lesson-winforms``` описана одна из основ использования операторов async/await. В Дальнейшем будет продолжение уроков
