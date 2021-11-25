--Selecteer alle klanten die in Duitsland of Londen wonen. Sorteer oplopend op naam.
	
    SELECT * 
    FROM [Customers]
    WHERE 
        UPPER(City) = 'LONDON' 
    OR
        UPPER(Country) = 'GERMANY'
        ORDER BY CustomerName

--Haal alle producten op die minder dan 40$ kosten.

	SELECT * 
    FROM [Products]
    WHERE Price < 40

		
    --Breidt bovenstaande query uit door ook de naam en beschrijving van de productcategorie te tonen.
    SELECT * 
    FROM [Products] p
    INNER JOIN Categories c
        ON c.CategoryID = p.CategoryID
    WHERE p.Price < 40
		
    --Sorteer op prijs, van duur naar goedkoop.
	SELECT * 
    FROM [Products] p
    INNER JOIN Categories c
        ON c.CategoryID = p.CategoryID
    WHERE p.Price < 40
    ORDER BY p.Price DESC
	
	
--Voeg jezelf toe als klant (Adres mag fake zijn)
SELECT * FROM [Customers]

INSERT INTO [Customers] (CustomerName, ContactName, Address, City, PostalCode, Country)
VALUES (
	'Julien Lalmand',
    'Random Contact',
    'Pastoor Evrardlaan 30',
    'Asse',
    '1731'
    'Belgium'
)
	
		
--Voeg enkele orders toe op jouw naam. (Mijn ID is 92) (Kolom OrderDate heeft geen default)
INSERT INTO [Orders] (CustomerID, EmployeeID, ShipperID, OrderDate)
VALUES  (92, 5, 3, '2021-11-25'), 
        (92, 4, 3, '2021-11-25')
	
	--Orders ID zijn 10447, 10448


--Toon alle klanten die ‘Carlos’ heten. (ContactName)
SELECT * 
FROM [Customers]
WHERE ContactName LIKE 'Carlos %'
	
--Pas de ShipperName van United Package aan naar United Packages International.
UPDATE [Shippers]
SET ShipperName = 'United Packages International'
WHERE ShipperID = 1

		
--Zorg ervoor dat enkel 1 record aangepast kan worden.
--'LIMIT' aan het einde van een update-statement blijkt niet te werken, meestal gebruik ik inderdaad TOP(x) zoals volgt dus:
UPDATE TOP(1) [Shippers]
SET ShipperName = 'United Packages International'
WHERE ShipperID = 1

	
--Haal alle orders op van 1997. Toon ook de CustomerName, ContactName, Country van de klant en de voor-en achternaam van de verkoper, 
--alsook de SuplierName van de leverancier.

    --NOTE: varchar concateneren blijkt in het W3Schools environment niet te werken, anders had ik dit gedaan voor employee (naar fullname)
    --NOTE 2 : in een reëel omgeving zou ik DATEPART() gebruiken om op jaar te filteren
SELECT  o.*, 
        cust.CustomerName, 
        cust.ContactName, 
        cust.Country, 
        emp.FirstName as 'Employee FirstName', 
        emp.LastName as 'Employee LastName', 
        ship.ShipperName
FROM [Orders] o
INNER JOIN [Customers] cust
	ON o.CustomerID = cust.CustomerID
INNER JOIN [Employees] emp
	ON o.EmployeeID = emp.EmployeeID
INNER JOIN [Shippers] ship
	ON o.ShipperID = ship.ShipperID
WHERE o.OrderDate LIKE '1997%'


		
--De kolom Country is generiek. Een derde partij weet niet of het over het land van de klant, verkoper of leverancier gaat.
--Geef deze kolom weer als ‘CustomerCountry’.
SELECT  o.*, 
        cust.CustomerName, 
        cust.ContactName, 
        cust.Country as 'CustomerCountry', 
        emp.FirstName as 'Employee FirstName', 
        emp.LastName as 'Employee LastName', 
        ship.ShipperName
FROM [Orders] o
INNER JOIN [Customers] cust
	ON o.CustomerID = cust.CustomerID
INNER JOIN [Employees] emp
	ON o.EmployeeID = emp.EmployeeID
INNER JOIN [Shippers] ship
	ON o.ShipperID = ship.ShipperID
WHERE o.OrderDate LIKE '1997%'
	
	
--Toon alle klanten die minstens 1 bestelling geplaatst hebben.
SELECT * 
FROM [Customers] c
INNER JOIN [Orders] o
	ON o.CustomerID = c.CustomerID


--Toon alle klanten die nog geen bestellingen geplaatst hebben. 
SELECT  o.OrderID, 
        c.CustomerID, 
        c.CustomerName
FROM [Customers] c
LEFT JOIN [Orders] o
	ON o.CustomerID = c.CustomerID
WHERE OrderID IS NULL


	
--Haal de top 5 klanten op die de meeste bestellingen geplaatst hebben. Rangschik van hoog naar laag.
SELECT  o.OrderID, 
        c.CustomerName, 
        COUNT(c.CustomerID)
FROM [Orders] o
INNER JOIN [Customers] c
	ON o.CustomerID = c.CustomerID
GROUP BY c.CustomerName
ORDER BY COUNT(c.CustomerID) DESC
LIMIT 5

		
--Filter bovenstaande query door enkel de klanten te tonen met een totaal aantal bestellingen <= 5
SELECT  o.OrderID, 
        c.CustomerName, 
        COUNT(c.CustomerID)
FROM [Orders] o
INNER JOIN [Customers] c
	ON o.CustomerID = c.CustomerID
GROUP BY c.CustomerName
HAVING COUNT(c.CustomerID) <= 5
ORDER BY COUNT(c.CustomerID) DESC
LIMIT 5
	
	
--Haal de top 3 bestellingen op met het hoogst aantal producten. Toon het ordernummer en het aantal producten in die bestelling. 
--Noem deze laatste kolom ‘Nr. of Products’.
SELECT  o.OrderID, 
        SUM(od.Quantity) as 'Nr. of Products'
FROM [Orders] o
INNER JOIN [OrderDetails] od
	ON od.OrderID = o.OrderID
GROUP BY o.OrderID
ORDER BY SUM(od.Quantity) DESC
LIMIT 3

		
--Breidt bovenstaande query uit door ook het land, ID en de naam van de klant weer te geven.
SELECT  o.OrderID, 
        SUM(od.Quantity) as 'Nr. of Products', 
        c.CustomerID, 
        c.CustomerName, 
        c.Country
FROM [Orders] o
INNER JOIN [OrderDetails] od
	ON od.OrderID = o.OrderID
INNER JOIN [Customers] c
	ON o.CustomerID = c.CustomerID
GROUP BY o.OrderID
ORDER BY SUM(od.Quantity) DESC

--Breidt bovenstaande query uit door enkel de bestellingen te tonen die niet in de USA of Oostenrijk plaatsvonden.
--10248 = 27 total
SELECT  o.OrderID, 
        SUM(od.Quantity) as 'Nr. of Products', 
        c.CustomerID, 
        c.CustomerName, 
        c.Country
FROM [Orders] o
INNER JOIN [OrderDetails] od
	ON od.OrderID = o.OrderID
INNER JOIN [Customers] c
	ON o.CustomerID = c.CustomerID
WHERE c.Country NOT IN ('USA', 'Austria')
GROUP BY o.OrderID
ORDER BY SUM(od.Quantity) DESC
LIMIT 3
		
--Filter bovenstaande query door enkel de bestellingen te tonen met een totaal aantal producten <= 150
SELECT  o.OrderID, 
        SUM(od.Quantity) as 'Nr. of Products', 
        c.CustomerID, 
        c.CustomerName, 
        c.Country
FROM [Orders] o
INNER JOIN [OrderDetails] od
	ON od.OrderID = o.OrderID
INNER JOIN [Customers] c
	ON o.CustomerID = c.CustomerID
WHERE c.Country NOT IN ('USA', 'Austria')
GROUP BY o.OrderID
HAVING SUM(od.Quantity) <= 150
ORDER BY SUM(od.Quantity) DESC
LIMIT 3