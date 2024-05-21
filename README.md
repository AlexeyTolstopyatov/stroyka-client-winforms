## Файлы классов-менеджеров
Указаны по адресу ```/strc/sqlserver```, необходимы для быстрого взаимодействия с объектами информационной системы.
Вместо того, чтобы использовать проверку соединения и получения таблицы вручную, как указано на примере ниже:
```csharp
using (SqlConnection connection = new SqlConnection("Your string here")
using (SqlCommand command = "SELECT * FROM [имя таблицы]")
{
  await connection.OpenAsync();
  // или
  connection.Open()

  // логика получения таблицы
}
```
Используйте функцию ```ExecuteMapAsync()```
```csharp
DataTable source = await ExecuteMapAsync("SELECT * FROM [имя таблицы]");
```
Все остальные функции из /strc/sqlserver описаны подобным образом, как например настроенный ```ExecuteScalarAsync()```
```csharp 
QueryManager.ExecuteInt32(string)
```
возврашает ```object``` результат (текст ячейки) первого столбца первой строки.
