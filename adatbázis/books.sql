INSERT INTO categories (name) VALUES
("lifestyle"),
("útleírás"),
("filozófia");

INSERT INTO books (title, author_id, publisher_id, category_id, publish_year, pages, price, stock, rating, is_bestseller) VALUES
("A hobbit", 14, 5, 4, 1937, 310, 3690, 60, 4.88, TRUE),
("The Shining", 13, 8, 8, 1977, 447, 3990, 42, 4.79, TRUE);

SELECT title, price, rating FROM books WHERE price > 3000 AND rating >= 4.80 ORDER BY rating DESC LIMIT 5;

SELECT COUNT(*) AS konyvek_szama, AVG(price) AS atlag_ertekeles, COUNT(*) AS osszes_keszlet FROM books GROUP BY category_id;

UPDATE books SET price = price * 1.25 WHERE rating <= 4.85 AND is_bestseller = TRUE;

UPDATE books SET stock = stock + 50;

ALTER TABLE books ADD COLUMN isbn VARCHAR(20) UNIQUE COMMENT 'ISBN szám', MODIFY rating DECIMAL(4.2);

DELETE FROM books WHERE publish_year > 1940 AND stock < 30;