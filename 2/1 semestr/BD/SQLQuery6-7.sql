--------- Ex.1 ----------
USE computer
GO
SELECT *
FROM Printer
WHERE color = 'y'
ORDER BY price desc

--------- Ex.2 ----------
USE Ships
GO
SELECT name
FROM Ships
WHERE name LIKE '%e%e%'

--------- Ex.3 ----------
USE computer
GO
SELECT Product.model, maker, price
From Product, Printer
WHERE Product.model = Printer.model and price > 300

--------- Ex.4 ----------
USE Ships
GO
SELECT country, Ships.class
FROM Ships, Classes
WHERE country = 'USA' and Ships.class = Classes.class

--------- Ex.5 ----------
USE computer
GO
SELECT maker, Product.model
FROM PC, Product
WHERE PC.speed >= 750 and PC.model = Product.model

--------- Ex.6 ----------
USE Ships
GO
SELECT *, CASE
WHEN result IN ('sunk') THEN 'потонув'
WHEN result IN ('damaged') THEN 'підбитий'
WHEN result IN ('OK') THEN 'живий'
END AS результат
FROM Outcomes

--------- Ex.7 ----------
USE computer
GO
SELECT min(price) AS [Мінімальна ціна], maker
FROM Product, Printer
WHERE Product.model = Printer.model
GROUP BY Product.maker


--------- Ex.8 ----------
USE computer
GO
SELECT max(price) AS [Максимальна ціна], maker
FROM Product, PC
WHERE Product.model = PC.model
GROUP BY Product.maker


--------- Ex.10 ----------
USE computer
GO
SELECT 'PC' type, model, MAX(price) AS maxprice 
FROM PC
GROUP BY model 
UNION 
SELECT 'Printer' type, model, MAX(price) AS maxprice 
FROM Printer 
GROUP BY model 
UNION 
SELECT 'Laptop' type, model, MAX(price) AS maxprice 
FROM Laptop 
GROUP BY model