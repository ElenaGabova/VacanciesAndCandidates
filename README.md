# VacanciesAndCandidates

Необходимо Создать хранимый пакет:

a.	Функция/Процедура записи в таблицу (с обработкой ошибок на экране вывод сообщения об ошибке)
b.	Процедура чтения данных из БД (возвращается ref_cursor)
c.	Функция/процедура удаления записи (физически запись не удаляется, просто ставить признак не актуальности, с обработкой ошибок на экране вывод сообщения об ошибке)

Работа программы у пользователя:

1.	Интерфейс просмотра процедура 2.b. На интерфейсе 3 кнопки (Вставить, Удалить, Обновить)
2.	Интерфейс ввода записи (кнопка добавить, открывается форма с полями по структуре таблицы , при сохранении в БД 2.а)
3.	Интерфейс удаления записи (кнопка удалить. Задается вопрос: Вы хотите удалить запись? Если ответили да, то запуска 2.с и в БД запись помечается на удаление)


Структура базы данных хранится в файле database.sql
В базе присутсвуют 2 таблицы:
dbo.Candidates
dbo.Vacansies

В базе присутсвуют процедуры для добавления, обновления информации и удаления кандидата,
В базе присутсвуют процедуры для добавления, обновления вакансии
