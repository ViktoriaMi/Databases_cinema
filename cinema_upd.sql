USE cinema;

drop table if exists Покупка;
drop table if exists Билет;
drop table if exists Сеанс_время;
drop table if exists Сеанс_дата;
drop table if exists Админ;
drop table if exists Клиент;
drop table if exists Фильм;

# АДМИН
CREATE TABLE IF NOT EXISTS Админ (
	№_админа INT NOT NULL AUTO_INCREMENT,
	ФИО VARCHAR(47) NOT NULL,
	Email VARCHAR(20) NOT NULL,
	Пароль VARCHAR(6) NOT NULL,
	Дата_рождения DATE NOT NULL,
	Пол ENUM("М", "Ж") NOT NULL,
	Телефон VARCHAR(12) NOT NULL UNIQUE,
	Дата_регистрации DATE NOT NULL,
	PRIMARY KEY (№_админа),
	UNIQUE INDEX index_№_админа (№_админа ASC) VISIBLE,
	UNIQUE INDEX index_Email_admin (Email ASC) VISIBLE,
    CHECK (LENGTH(Пароль) >= 6),
    CHECK (LENGTH(Телефон) = 12),
    CHECK (Дата_регистрации >= "2018-06-01"),
    CHECK (TIMESTAMPDIFF (YEAR, Дата_рождения, Дата_регистрации) >= 18)
    #CHECK (TIMESTAMPDIFF (YEAR, Дата_рождения, Дата_регистрации) <= 70)
    );

INSERT INTO Админ (ФИО, Email, Пароль, Дата_рождения, Пол, Телефон, Дата_регистрации) VALUES
("Петров Петр Петрович", "petrov@mail.ru", "123456", "2000-02-25", "М", "+79641234567", "2018-06-05"),
("Иванов Иван Иванович", "ivanov@mail.ru", "234456", "1999-06-26", "М", "+79641234569", "2018-06-05"),
("Виноградова Ольга Петровна", "olgaop@yandex.ru", "124456", "1985-05-25", "Ж", "+79641234568", "2018-06-04"),
("Горшкова Надежда Алексеевна", "nadezhdaga@yandex.ru", "125456", "1987-04-21", "Ж", "+79641234561", "2018-06-02"),
("Сушкина Валентина Антоновна", "syshkinava@yandex.ru", "126456", "1995-01-05", "Ж", "+79641234562", "2018-06-05"),
("Коростылева Екатерина Павловна", "katyakp@gmail.ru", "127456", "1998-04-13", "Ж", "+79641234563", "2019-05-12"),
("Уткина Раиса Олеговна", "ytkinaro@yandex.ru", "128465", "1988-10-12", "Ж", "+79641234564", "2019-01-09"),
("Ильин Илья Игоревич", "ilyinii@mail.ru", "129466", "1996-08-16", "М", "+79641234565", "2019-01-07"),
("Сомов Анатолий Сергеевич", "somovas@mail.ru", "130466", "1990-09-19", "М", "+79641234566", "2019-01-07"),
("Храпов Юсуп Геннадьевич", "hrapovyg@mail.ru", "131466", "1984-11-09", "М", "+79641234576", "2020-03-20"),
("Это я", "1@", "123456", "1988-10-11", "Ж", "+79641234577", "2019-01-09");

# КЛИЕНТ
CREATE TABLE IF NOT EXISTS Клиент (
	№_клиента INT NOT NULL AUTO_INCREMENT,
	Фамилия VARCHAR(15) NULL,
	Имя VARCHAR(15) NULL,
	Email VARCHAR(20) NOT NULL,
	Пароль VARCHAR(6) NOT NULL,
	Дата_рождения DATE NULL,
	Пол ENUM("М", "Ж") NULL,
	Телефон VARCHAR(12) NULL UNIQUE,
	Дата_регистрации TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (№_клиента),
	UNIQUE INDEX index_№_клиента (№_клиента ASC) VISIBLE,
	UNIQUE INDEX index_Email_client (Email ASC) VISIBLE,
    CHECK (LENGTH(Пароль) >= 6),
    CHECK (LENGTH(Телефон) = 12),
    CHECK (Дата_регистрации >= "2018-06-01"),
    CHECK (TIMESTAMPDIFF (YEAR, Дата_рождения, Дата_регистрации) >= 16)
);

INSERT INTO Клиент (Фамилия, Имя, Email, Пароль, Дата_рождения, Пол, Телефон, Дата_регистрации) VALUES
("Крючкова", "Елизавета", "krykoval@yandex.ru", "321123", "1995-06-27", NULL, "+79119876543", "2018-07-01 09:20"),
("Быков", "Елисей", "elexey@gmail.ru", "322123", "1993-09-17", "М", "+79119876544", "2018-07-24 17:15"),
(NULL, "Ваня", "kylishovvv@gmail.ru", "323123", "1995-09-18", "М", "+79119876545", "2018-07-05 18:30"),
("Щукин", "Артемий", "artemaa@gmail.ru", "324123", "1997-04-21", "М", "+79119876546", "2020-07-10 12:13"),
(NULL, "Маша", "mashynya96@gmail.ru", "325123", "1996-10-07", "Ж", "+79119876547", "2018-07-02 00:30"),
(NULL, "Алладин", "aladdinss@mail.ru", "326123", "1991-03-31", NULL, "+79119876548", "2019-09-18 15:49"),
("Корякова", "Кейт", "kate23@mail.ru", "327123", "1990-04-23", "Ж", "+79119876549", "2020-10-19 01:22"),
("Виноградова", "Алла", "vinograda@yandex.ru", "328123", "1989-05-24", "Ж", "+79119876550", "2020-11-20 16:02"),
("Цветков", "Валентин", "valentinka@gmail.ru", "329123", "1988-06-25", NULL, "+79119876551", "2019-04-05 21:00"),
("Попова", "Анна", "popovaa@yandex.ru", "330123", "1987-03-03", "Ж", "+79119876552", "2019-06-02 17:25"),
(NULL, "Это я", "1@", "123456", "1991-03-24", NULL, "+79119876553", "2019-09-20 15:15");

# ФИЛЬМ
CREATE TABLE IF NOT EXISTS Фильм (
	№_фильма INT NOT NULL AUTO_INCREMENT,
	Название VARCHAR(30) NOT NULL,
	Описание VARCHAR(750) NOT NULL,
	Возрастное_огр ENUM("0+", "6+", "12+", "16+", "18+") NOT NULL DEFAULT '0+',
	Продолжительность INT NULL,
	Постер VARCHAR(14) NULL,
	PRIMARY KEY (№_фильма),
	UNIQUE INDEX index_№_фильма (№_фильма ASC) VISIBLE,
	UNIQUE INDEX index_Название_film (Название ASC) VISIBLE,
	UNIQUE INDEX index_Описание_film (Описание ASC) VISIBLE,
	UNIQUE INDEX index_Постер_film (Постер ASC) VISIBLE,
	INDEX index_Возраст_огр_film (Возрастное_огр ASC) VISIBLE,
    CHECK (Продолжительность >= 60 AND Продолжительность <= 130)
);

CREATE TABLE IF NOT EXISTS Сеанс_дата (
	id_сеанс_дата INT NOT NULL AUTO_INCREMENT UNIQUE,
    №_фильма INT NOT NULL,
    Дата DATE NOT NULL,
    PRIMARY KEY (id_сеанс_дата),
    INDEX fk_Сеанс_дата_Фильм (№_фильма ASC) VISIBLE,
    INDEX index_Сеанс_дата (Дата ASC) VISIBLE,
    CONSTRAINT fk_Сеанс_дата_фильм
	FOREIGN KEY (№_фильма)
	REFERENCES Фильм (№_фильма)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS Сеанс_время (
	id_сеанс_время INT NOT NULL AUTO_INCREMENT UNIQUE,
    id_сеанс_дата INT NULL,
    Время TIME NULL,
    PRIMARY KEY (id_сеанс_время),
    INDEX fk_Сеанс_время_дата (id_сеанс_дата ASC) VISIBLE,
    INDEX index_Сеанс_время (Время ASC) VISIBLE,
    CONSTRAINT fk_Сеанс_время
	FOREIGN KEY (id_сеанс_дата)
	REFERENCES Сеанс_дата (id_сеанс_дата)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS Билет (
	№_билета INT NOT NULL AUTO_INCREMENT UNIQUE,
    id_сеанс_время INT NOT NULL,
    №_ряда INT NULL,
    №_места INT NULL,
    Цена INT NOT NULL DEFAULT "180",
    Куплен BOOLEAN NOT NULL DEFAULT 0,
    PRIMARY KEY (№_билета),
	INDEX fk_Билет_сеанс_время (id_сеанс_время) VISIBLE,
	INDEX index_Цена_билет (Цена ASC) VISIBLE,
    CHECK (Цена = 180 OR Цена = 200 OR Цена = 220),
    CHECK (№_ряда >= 1 AND №_ряда <= 10 AND №_места >= 1 AND №_места <= 10),
    CONSTRAINT fk_Билет_сеансВремя
	FOREIGN KEY (id_сеанс_время)
	REFERENCES Сеанс_время (id_сеанс_время)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS Покупка (
	№_покупки INT NOT NULL AUTO_INCREMENT UNIQUE,
    №_клиента INT NULL,
    №_билета INT NOT NULL,
    колво_билетов INT NOT NULL DEFAULT 0,
    сумма INT NOT NULL DEFAULT 0,
    датавремя_покупки DATETIME NULL,
    PRIMARY KEY (№_покупки),
    FOREIGN KEY (№_клиента)
	REFERENCES Клиент (№_клиента)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
    FOREIGN KEY (№_билета)
	REFERENCES Билет (№_билета)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

# триггер по update билет
DELIMITER $$
DROP TRIGGER IF EXISTS after_update_ticket $$
CREATE
	TRIGGER after_update_ticket AFTER UPDATE
	ON Билет
	FOR EACH ROW BEGIN

		IF (NEW.куплен = 1) THEN
			INSERT INTO Покупка(№_билета, датавремя_покупки) VALUES (NEW.№_билета, NOW());
        END IF;

    END$$
DELIMITER ;

INSERT INTO Фильм (Название, Описание, Возрастное_огр, Продолжительность, Постер) VALUES
("Спирит Непокорный", 
"Лаки Прескотт — юная бунтарка, совсем как ее мама, легендарная бесстрашная наездница, которую дочь почти не помнит. После очередной шалости заботливая тетушка Кора, вырастившая девочку, отправляет ее жить к отцу. Теперь все, о чем мечтает Лаки — вырваться на волю из крошечного сонного городка. Все меняется, когда она знакомится со Спиритом — диким мустангом, таким же упрямым и независимым, как и она сама. После того как Спирит попадает в руки бессердечного ковбоя и его подельников, Лаки в сопровождении новых друзей отправляется в полное опасностей путешествие, чтобы его спасти.",
"6+", 87, "1.jpg"),
("Форсаж 9",
"Доминик Торетто ведет спокойную жизнь вместе с Летти и своим сыном Брайаном, однако, они знают, что новая опасность всегда где-то рядом. В этот раз Доминику придется встретиться с призраками прошлого, если он хочет спасти самых близких. Команда снова собирается вместе, чтобы предотвратить дерзкий план по захвату мира, который придумал самый опасный преступник и безбашенный водитель из всех, с кем они сталкивались ранее. Ситуация усложняется тем, что этот человек — брат Доминика Джейкоб, которого много лет назад изгнали из семьи.",
"12+", 120, "2.bmp"),
("Ассасин. Битва миров",
"В неком фэнтезийном мире правит жестокий Бог, которому нужны лишь смерть и разрушения. Потеряв сестру, но обретя волшебный доспех, молодой воин Кунвэнь отправляется в путешествие, чтобы разыскать и убить Бога. В это время в нашем мире мужчина Гуань Нин уже шесть лет находится на грани отчаяния, разыскивая пропавшую дочку. Он выходит на торговцев детьми, но полиция ошибочно принимает его за преступника и арестовывает. Сбежать Нину помогает ассистентка влиятельного бизнесмена и предлагает ему сделку. Один популярный писатель в данный момент пишет роман в жанре фэнтези, который каким-то образом вредит здоровью её босса, а Нин в обмен на информацию о местонахождении дочери должен этого писателя убить.",
"18+", 130, "3.jpg"),
("Амнезия",
"Джон Доу просыпается в больнице после травмы, не помня, кто он. Вскоре он узнает, что полиция разыскивает хитроумного маньяка за совершение серии убийств. Все улики указывают на Джона. Пытаясь понять, что происходит, и кто он на самом деле, Джон начинает свою собственную игру.",
"16+", 97, "4.jpg"),
("Спиритический сеанс",
"Камилл — новенькая в элитной женской школе, где недавно при загадочных обстоятельствах погибла одна ученица. Когда умирает очередная девушка, Камилл выясняет, что несчастья начали случаться после спиритического сеанса, во время которого девушки в шутку вызывали дух самоубийцы, покончившей с собой в этих стенах много лет назад.",
"16+", 90, "5.jpg"),
("Круэлла", 
"Лондон 70-х годов охвачен зарождающейся культурой панк-рока. Невероятно одаренная мошенница по имени Эстелла решает сделать себе имя в мире моды. Её лучшие друзья — парочка юных карманников, которые ценят страсть Эстеллы к приключениям и надеются вместе с ней отвоевать себе место под солнцем на улицах британской столицы. В один прекрасный день модное чутье Эстеллы привлекает внимание шикарной и пугающе высокомерной баронессы фон Хельман.",
"12+", "118", "6.jpg");

# триггер по добавлению в сеанс_время
DELIMITER $$
DROP TRIGGER IF EXISTS after_insert_time$$
CREATE
	TRIGGER after_insert_time AFTER INSERT
	ON Сеанс_время
	FOR EACH ROW BEGIN
    SET @a = 0;
		WHILE @a < 100 DO
			INSERT INTO Билет(id_сеанс_время) VALUES (NEW.id_сеанс_время);
            SET @a = @a+1;
		END WHILE;
    END$$
DELIMITER ;

# триггер по добавлению в сеанс_дату
DELIMITER $$
DROP TRIGGER IF EXISTS after_insert_date$$
CREATE
	TRIGGER after_insert_date AFTER INSERT 
	ON Сеанс_дата
	FOR EACH ROW BEGIN

		INSERT INTO Сеанс_время(id_сеанс_дата) VALUES (NEW.id_сеанс_дата);
        INSERT INTO Сеанс_время(id_сеанс_дата) VALUES (NEW.id_сеанс_дата);

    END$$
DELIMITER ;

INSERT INTO Сеанс_дата (№_фильма, Дата) VALUES
(1, "2021-06-15"),
(2, "2021-06-15"),
(4, "2021-06-15"),

(1, "2021-06-16"),
(2, "2021-06-16"),
(3, "2021-06-16"),

(3, "2021-06-17"),
(5, "2021-06-17"),
(6, "2021-06-17");

DROP PROCEDURE IF EXISTS update_сеанс_время;
DELIMITER //
CREATE PROCEDURE `update_сеанс_время` (IN period TIME, IN var INT)
BEGIN
	UPDATE Сеанс_время 
		SET Время = period WHERE id_сеанс_время = var;
END //
DELIMITER ;

CALL update_сеанс_время("09:10", 1);
CALL update_сеанс_время("15:30", 2);
CALL update_сеанс_время("12:15", 3);
CALL update_сеанс_время("23:20", 4);
CALL update_сеанс_время("17:45", 5);
CALL update_сеанс_время("20:50", 6);

CALL update_сеанс_время("11:50", 7);
CALL update_сеанс_время("09:15", 8);
CALL update_сеанс_время("19:00", 9);
CALL update_сеанс_время("14:20", 10);
CALL update_сеанс_время("16:30", 11);
CALL update_сеанс_время("22:05", 12);

CALL update_сеанс_время("15:05", 13);
CALL update_сеанс_время("22:45", 14);
CALL update_сеанс_время("12:45", 15);
CALL update_сеанс_время("17:30", 16);
CALL update_сеанс_время("10:30", 17);
CALL update_сеанс_время("20:20", 18);

UPDATE Билет 
SET Цена = "200" WHERE id_сеанс_время = 2 
	OR id_сеанс_время = 3 
	OR id_сеанс_время = 10 
    OR id_сеанс_время = 11
    OR id_сеанс_время = 13
    OR id_сеанс_время = 15;
UPDATE Билет 
SET Цена = "220" WHERE id_сеанс_время = 4 
	OR id_сеанс_время = 5 
    OR id_сеанс_время = 6 
    OR id_сеанс_время = 9 
    OR id_сеанс_время = 12
    OR id_сеанс_время = 14
    OR id_сеанс_время = 16
    OR id_сеанс_время = 18;

SET @num_time = (SELECT COUNT(*) FROM Сеанс_время);
UPDATE Билет
SET Куплен = 1 WHERE id_сеанс_время = FLOOR(RAND()*(@num_time-1+1)+1);
UPDATE Билет 
SET Куплен = 1 WHERE id_сеанс_время = FLOOR(RAND()*(@num_time-1+1)+1);
UPDATE Билет 
SET Куплен = 1 WHERE id_сеанс_время = FLOOR(RAND()*(@num_time-1+1)+1);
UPDATE Билет 
SET Куплен = 1 WHERE id_сеанс_время = FLOOR(RAND()*(@num_time-1+1)+1);
UPDATE Билет 
SET Куплен = 1 WHERE id_сеанс_время = FLOOR(RAND()*(@num_time-1+1)+1);

# Вывести название, возрастное ограничение, продолжительность фильма на определенную дату с указанием времени сеанса и цен
DROP VIEW IF EXISTS raspisanie;
CREATE VIEW raspisanie AS SELECT фильм.Название, фильм.возрастное_огр AS Возраст, фильм.Продолжительность, Сеанс_дата.Дата, Сеанс_время.Время, Билет.Цена
	FROM Фильм
	JOIN Сеанс_дата
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
	JOIN Сеанс_время
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
	JOIN Билет
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	WHERE Сеанс_дата.дата >= curdate() AND Сеанс_дата.дата <= DATE_ADD(curdate(), INTERVAL 2 DAY)
    GROUP BY сеанс_время.время
	ORDER BY Сеанс_дата.Дата;
#SELECT * FROM raspisanie;

# выбираем все фильмы, доступные на текущую дату и еще 2 дня
DROP VIEW IF EXISTS movieSelection;
CREATE VIEW movieSelection AS SELECT фильм.Название
	FROM Фильм
	JOIN Сеанс_дата
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
	WHERE Сеанс_дата.дата >= curdate() AND Сеанс_дата.дата <= DATE_ADD(curdate(), INTERVAL 2 DAY)
    GROUP BY фильм.Название;
#SELECT * FROM movieSelection;

# выбираем все фильмы, доступные на текущую дату
DROP VIEW IF EXISTS movieSelectionToday;
CREATE VIEW movieSelectionToday AS SELECT фильм.Название
	FROM Фильм
	JOIN Сеанс_дата
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
	WHERE Сеанс_дата.дата = curdate()
    GROUP BY фильм.Название;
#SELECT * FROM movieSelectionToday;

DROP VIEW IF EXISTS raspisanieToday;
CREATE VIEW raspisanieToday AS SELECT фильм.Название, фильм.возрастное_огр AS Возраст, фильм.Продолжительность, Сеанс_время.Время, Билет.Цена
	FROM Фильм
	JOIN Сеанс_дата
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
	JOIN Сеанс_время
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
	JOIN Билет
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	WHERE Сеанс_дата.дата = curdate()
    GROUP BY сеанс_время.время
	ORDER BY Сеанс_время.время;
#SELECT * FROM raspisanieToday;

# вывод расписания на дату
DROP PROCEDURE IF EXISTS showSheduleForDate;
DELIMITER //
CREATE PROCEDURE `showSheduleForDate` (IN yDate DATE)
BEGIN
	SELECT фильм.Название, фильм.возрастное_огр AS Возраст, фильм.Продолжительность, Сеанс_время.Время, Билет.Цена
	FROM Фильм
	JOIN Сеанс_дата
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
	JOIN Сеанс_время
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
	JOIN Билет
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	WHERE Сеанс_дата.дата = yDate
    GROUP BY сеанс_время.время
	ORDER BY Сеанс_время.время;
END //
DELIMITER ;
#CALL showSheduleForDate("2021-06-05");

# ОТЧЕТ Вывести информацию о клиентах, зарегистрированных в системе, сгруппировать их по дате регистрации и упорядочить по возрастанию
DROP VIEW IF EXISTS all_clients;
CREATE VIEW all_clients AS
	SELECT №_клиента, Имя, Фамилия, Email, Дата_рождения, Пол, Телефон, Дата_регистрации
		FROM Клиент
	WHERE Клиент.имя <> "Это я"
	GROUP BY Дата_регистрации
	ORDER BY Дата_регистрации;
#SELECT * FROM all_clients;

# выводим информацию о конкретном фильме
DROP PROCEDURE IF EXISTS about_film;
DELIMITER //
CREATE PROCEDURE `about_film` (IN var VARCHAR(30))
BEGIN
	SELECT Название, Описание, возрастное_огр AS Возраст, Продолжительность, Постер
		FROM Фильм
    WHERE Название = var;
END //
DELIMITER ;
#CALL about_film("Спирит Непокорный");

# ОТЧЕТ доход кинотеатра на определенную дату с указанием всех фильмов
DROP PROCEDURE IF EXISTS доход_за_дату_отчет;
DELIMITER //
CREATE PROCEDURE `доход_за_дату_отчет` (IN дата DATE)
BEGIN
	SELECT Название AS Фильмы, Время, Цена, COUNT(Билет.Цена) AS Продано_билетов,  дата AS За_дату, SUM(Цена) AS Итого
    FROM Билет
    JOIN Сеанс_время
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	JOIN Сеанс_дата
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
	JOIN Фильм
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
    WHERE Сеанс_дата.Дата = дата AND билет.куплен = 1
    GROUP BY Сеанс_время.Время
    ORDER BY Сеанс_время.Время;
END //
DELIMITER ;
#CALL доход_за_дату_отчет("2021-06-13");

# представление для извлечения самого прибыльного фильма на вчерашнюю дату
DROP VIEW IF EXISTS доход_за_вчера;
CREATE VIEW доход_за_вчера AS
SELECT Название AS Фильм, Дата, COUNT(Билет.Цена) AS Продано_билетов, SUM(Цена) AS Итого
    FROM Билет
    JOIN Сеанс_время
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	JOIN Сеанс_дата
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
	JOIN Фильм
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
    WHERE Сеанс_дата.Дата = subdate(current_date, 1) AND билет.куплен = 1
    GROUP BY Фильм.Название
    ORDER BY Сеанс_время.Время;
#SELECT * FROM доход_за_вчера;

DROP VIEW IF EXISTS mostCostlyFilm;
CREATE VIEW mostCostlyFilm AS
	SELECT Фильм AS Самый_прибыльный_фильм, Итого FROM доход_за_вчера
		WHERE Итого = (SELECT MAX(Итого) FROM доход_за_вчера);
#SELECT * FROM mostCostlyFilm;

# доход кинотеатра на определенную дату ОБЩАЯ СУММА
DROP PROCEDURE IF EXISTS доход_за_дату;
DELIMITER //
CREATE PROCEDURE `доход_за_дату` (IN дата DATE)
BEGIN
	SELECT дата AS За_дату, SUM(Цена) AS Итого
    FROM Билет
    JOIN Сеанс_время
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	JOIN Сеанс_дата
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
    WHERE Сеанс_дата.Дата = дата AND билет.куплен = 1;
END //
DELIMITER ;
#CALL доход_за_дату("2021-06-14");

# ОТЧЕТ доход кинотеатра на дату по фильму с кучей полей
DROP PROCEDURE IF EXISTS доход_за_датуфильм_отчет;
DELIMITER //
CREATE PROCEDURE `доход_за_датуфильм_отчет` (IN дата DATE, IN вход_фильм VARCHAR(30))
BEGIN
	SELECT дата AS Дата, вход_фильм AS Фильм, Время, COUNT(Билет.Цена) AS Продано_билетов, Билет.Цена, SUM(Билет.Цена) AS Итого
    FROM Билет
    JOIN Сеанс_время
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	JOIN Сеанс_дата
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
	JOIN Фильм
		ON Сеанс_дата.№_фильма = Фильм.№_фильма
    WHERE Сеанс_дата.Дата = дата AND билет.куплен = 1 AND фильм.Название = вход_фильм
    GROUP BY Сеанс_время.Время;
END //
DELIMITER ;
#CALL доход_за_датуфильм_отчет("2021-06-13", "Круэлла");

# доход кинотеатра на дату по фильму
DROP PROCEDURE IF EXISTS доход_за_датуфильм;
DELIMITER //
CREATE PROCEDURE `доход_за_датуфильм` (IN дата DATE, IN вход_фильм VARCHAR(30))
BEGIN
	SELECT дата AS на_дату, вход_фильм AS и_фильм, SUM(Билет.Цена) AS Итого
    FROM Билет
    JOIN Сеанс_время
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	JOIN Сеанс_дата
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
	JOIN Фильм
		ON Сеанс_дата.№_фильма = Фильм.№_фильма
    WHERE Сеанс_дата.Дата = дата AND билет.куплен = 1 AND фильм.Название = вход_фильм;
END //
DELIMITER ;
#CALL доход_за_датуфильм("2021-06-12", "Спирит Непокорный");

# Вывести общее количество клиентов и администраторов, зарегистрированных в системе
DROP VIEW IF EXISTS numClientsAdmins;
CREATE VIEW numClientsAdmins AS
SELECT 
		(SELECT COUNT(*) FROM Админ WHERE Пароль <> "123") AS Колво_админов,
        (SELECT COUNT(*) FROM Клиент WHERE Пароль <> "123") AS Колво_клиентов;
#SELECT * FROM numClientsAdmins;

# Предоставить список клиентов, зарегистрированных в прошлом! году
-- SELECT №_клиента, Фамилия, Имя, Email, Дата_рождения, Пол, Телефон, Дата_регистрации FROM Клиент
-- 	WHERE YEAR(Дата_регистрации) = YEAR(curdate() - INTERVAL 1 YEAR);

# вывод инфы о конкретном админе
-- SELECT №_Админа AS id, ФИО, Email, Пол, Телефон, Дата_рождения, Дата_регистрации
-- FROM Админ WHERE №_Админа = 2;

# получаем описание фильма по названию
DROP PROCEDURE IF EXISTS selectDesc;
DELIMITER //
CREATE PROCEDURE `selectDesc` (IN вход_фильм VARCHAR(30))
BEGIN
	SELECT Описание
    FROM Фильм
    WHERE фильм.Название = вход_фильм;
END //
DELIMITER ;
#CALL selectDesc("Амнезия");

# получаем описание и постер фильма по названию
DROP PROCEDURE IF EXISTS selectDescAndPoster;
DELIMITER //
CREATE PROCEDURE `selectDescAndPoster` (IN вход_фильм VARCHAR(30))
BEGIN
	SELECT Описание, Постер
    FROM Фильм
    WHERE фильм.Название = вход_фильм;
END //
DELIMITER ;
#CALL selectDescAndPoster("Амнезия");

# получаем фильмы, доступные на определенную дату
DROP PROCEDURE IF EXISTS selectFilmByDate;
DELIMITER //
CREATE PROCEDURE `selectFilmByDate` (IN дата DATE)
BEGIN
	SELECT фильм.Название
	FROM Фильм
	JOIN Сеанс_дата
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
	WHERE Сеанс_дата.дата = дата
    GROUP BY фильм.Название;
END //
DELIMITER ;
#CALL selectFilmByDate("2021-06-08");

# расписание для админа
DROP PROCEDURE IF EXISTS sheduleForAdmin;
DELIMITER //
CREATE PROCEDURE `sheduleForAdmin` (IN yDate DATE)
BEGIN
	SELECT фильм.№_фильма, фильм.Название, Сеанс_время.id_сеанс_время, Сеанс_время.Время, Билет.Цена
	FROM Фильм
	JOIN Сеанс_дата
		ON Фильм.№_фильма = Сеанс_дата.№_фильма
	JOIN Сеанс_время
		ON Сеанс_дата.id_сеанс_дата = Сеанс_время.id_сеанс_дата
	JOIN Билет
		ON Сеанс_время.id_сеанс_время = Билет.id_сеанс_время
	WHERE Сеанс_дата.дата = yDate
    GROUP BY сеанс_время.время
	ORDER BY Фильм.№_фильма;
END //
DELIMITER ;
# CALL sheduleForAdmin("2021-06-09");

# изменить название фильма в базе по его id
DROP PROCEDURE IF EXISTS updateFilm;
DELIMITER //
CREATE PROCEDURE `updateFilm` (IN numFilm INT, IN nameFilm VARCHAR(30))
BEGIN
	UPDATE Фильм
		SET Название = nameFilm
			WHERE №_фильма = numFilm;
END //
DELIMITER ;
#CALL updateFilm(1, "Кукарача");

# изменить время показа фильма по id_сеанс_время
-- DROP PROCEDURE IF EXISTS updateTimeFilm;
-- DELIMITER //
-- CREATE PROCEDURE `updateTimeFilm` (IN numTime INT, IN newTime TIME)
-- BEGIN
-- 	UPDATE Сеанс_время
-- 		SET Время = newTime
-- 			WHERE id_сеанс_время = numTime;
-- END //
-- DELIMITER ;
#CALL updateTimeFilm(1, "9:25");

# извлекаем №_фильма по названию
DROP PROCEDURE IF EXISTS getNumFilm;
DELIMITER //
CREATE PROCEDURE `getNumFilm` (IN nameFilm VARCHAR(30))
BEGIN
	SELECT №_фильма FROM Фильм WHERE Название = nameFilm;
END //
DELIMITER ;
#CALL getNumFilm("Амнезия");

#SELECT MAX(id_сеанс_дата) FROM Сеанс_дата;

# АПДЕЙТ сеанс_время по id Сеанс_даты
DROP PROCEDURE IF EXISTS updTimeSession;
DELIMITER //
CREATE PROCEDURE `updTimeSession` (IN period TIME, IN id INT)
BEGIN
	UPDATE Сеанс_время 
		SET Время = period WHERE id_сеанс_дата = id;
END //
DELIMITER ;
#CALL updTimeSession("12:12", 10);

# вытаскиваем всю инфу о фильме по названию
DROP PROCEDURE IF EXISTS selectFilmFromName;
DELIMITER //
CREATE PROCEDURE selectFilmFromName (IN имяФильма VARCHAR(30))
BEGIN
	SELECT * FROM Фильм WHERE Название = имяФильма;
END //
DELIMITER ;
#CALL selectFilmFromName("Амнезия");

# UPDATE Фильм
	# SET Описание = "кура", Возрастное_огр = "0+",
    # Продолжительность = 111, Постер = "12345" 
    # WHERE №_фильма = 1;
    
-- UPDATE Фильм 
-- 	SET Название = "Кура", Описание = "Кура", 
--     Возрастное_огр = "0+", Продолжительность = 111, 
--     Постер = "45.jpg"
--     WHERE №_фильма = 4;

-- UPDATE Фильм
-- 	SET Название = "Якорь" WHERE №_фильма = 4;

-- SELECT №_фильма, Название FROM Фильм
-- 	ORDER BY №_фильма;

-- DELETE FROM Фильм WHERE №_фильма = 4;

-- SELECT №_фильма, Название FROM Фильм
-- 	ORDER BY №_фильма;