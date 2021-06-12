CREATE User 'Клиент'@'%' IDENTIFIED BY 'password';

use mysql;
#drop user 'Adm';
    
GRANT SELECT
	ON cinema.фильм
    TO 'Клиент'@'%';
    
GRANT SELECT
	ON cinema.сеанс_дата
    TO 'Клиент'@'%';
    
GRANT SELECT
    ON cinema.сеанс_время
    TO 'Клиент'@'%';
    
GRANT SELECT
    ON cinema.билет
    TO 'Клиент'@'%';
    
# обновляет таблицу прав пользователей MySQL в памяти
FLUSH PRIVILEGES;

-- drop user IF EXISTS 'Админ'@'%';

-- CREATE User 'Админ'@'%' IDENTIFIED BY 'password';
-- GRANT SELECT, UPDATE, INSERT, DELETE
--     ON cinema.фильм
--     TO 'Админ'@'%';
--     
-- GRANT SELECT, UPDATE, INSERT, DELETE
--     ON cinema.сеанс_дата
--     TO 'Админ'@'%';
--     
-- GRANT SELECT, UPDATE, INSERT, DELETE
--     ON cinema.сеанс_время
--     TO 'Админ'@'%';
    
-- GRANT SELECT, UPDATE, INSERT
--     ON cinema.админ
--     TO 'Adm'@'%';
    
-- GRANT SELECT
--     ON cinema.*
--     TO 'Админ'@'%';

-- FLUSH PRIVILEGES;

#select user, host from mysql.user;
show grants for 'Клиент'@'%';
#drop user 'Guest';