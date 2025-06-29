
CREATE DATABASE Ranking;
GO

USE Ranking;
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Category NVARCHAR(50),
    Price DECIMAL(10, 2)
);
GO

INSERT INTO Products (ProductID, Name, Category, Price) VALUES
(1, 'A', 'Shoes', 100),
(2, 'B', 'Shoes', 90),
(3, 'C', 'Shoes', 90),
(4, 'D', 'Shoes', 80),
(5, 'E', 'Bags', 200),
(6, 'F', 'Bags', 180),
(7, 'G', 'Bags', 180),
(8, 'H', 'Bags', 150);
GO

SELECT * FROM Products;
GO

SELECT *
FROM (
    SELECT
        ProductID,
        Name,
        Category,
        Price,
        ROW_NUMBER() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RowNum,
        RANK() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RankNum,
        DENSE_RANK() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS DenseRankNum
    FROM Products
) RankedProducts
WHERE RowNum <= 3
   OR RankNum <= 3
   OR DenseRankNum <= 3
ORDER BY Category, Price DESC;
GO
