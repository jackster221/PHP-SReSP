create database phpsreps_db;
use phpsreps_db;

create table Products (
	ProductID int auto_increment primary key,
    ProductName varchar(255),
    Category varchar(255),
	RestockPrice double,
    SellPrice double,
    CurrentInventory int,
	RestockLevel int
);

create table Sales (
	SaleID int auto_increment primary key,
    ProductID int, foreign key (ProductID) references Products(ProductID),
    NumberSold int,
    SaleDate date
);

insert into Products (ProductName, Category, RestockPrice, SellPrice, CurrentInventory, RestockLevel) 
			  values ("Toothpaste", "Dental Care", 1.49, 3.25, 100, 30),
					 ("Multivitamin", "Vitamins", 9.99, 15.99, 100, 30),
					 ("Panadol", "Medicines", 4.49, 8.99, 100, 30),
					 ("Sud N Bud Cleanser", "Skin Care", 8.99, 12.49, 100, 30),
					 ("David Beckham", "Fragrances", 39.99, 49.99, 100, 30),
					 ("Nurofen", "Medicines", 3.99, 7.99, 100,  30),
					 ("ToothBrush", "Dental Care", 1.00, 1.99, 100, 30),
					 ("Cerave Moisturizer", "Skin Care", 10.99, 18.99, 100, 30),
					 ("Jellybeans", "Food", 3.99, 10.99, 100, 30);


insert into Sales (ProductID, NumberSold, SaleDate)
		values (1, 2, "2021-08-01"),
			   (2, 1, "2021-08-01"),
               (3, 2, "2021-08-05"),
			   (4, 1, "2021-08-09"),
               (6, 2, "2021-08-16"), ///////
			   (1, 1, "2021-08-16"),
               (2, 2, "2021-08-27"),
			   (3, 1, "2021-08-28"),
               (4, 2, "2021-09-01"),
			   (5, 1, "2021-09-01"),
               (1, 2, "2021-09-04"),
			   (2, 1, "2021-09-09"),
               (3, 2, "2021-09-09"),
			   (4, 1, "2021-09-16"),
               (5, 2, "2021-09-16"),
			   (2, 1, "2021-09-28"),
			   (1, 4, "2021-09-29"),
			   (6, 1, "2021-10-07"),
			   (7, 4, "2021-10-07"),
			   (3, 1, "2021-10-07"),
			   (8, 2, "2021-10-09"),
			   (9, 1, "2021-10-14"),
			   (9, 2, "2021-11-02"),
			   (3, 4, "2021-11-05"),
			   (2, 1, "2021-11-05"),
			   (7, 2, "2021-11-07");