-- Запрос 1 --

SELECT
    employee_id,
    CASE
        WHEN salary < 5000 THEN 'Low level'
        WHEN salary >= 5000 AND salary < 10000 THEN 'Normal level'
        WHEN salary >= 10000 THEN 'High level'
    END AS salary_level
FROM Employees;


-- Запрос 2 --

SELECT
    country_name,
    CASE region_id
        WHEN 1 THEN 'Europe'
        WHEN 2 THEN 'America'
        WHEN 3 THEN 'Asia'
        WHEN 4 THEN 'Africa'
        ELSE 'Unknown'
    END AS region
FROM Countries;