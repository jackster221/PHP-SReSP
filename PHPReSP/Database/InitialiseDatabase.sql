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
			  values ("Toothpaste", "Dental Care", 1.49, 3.25, 100, 10),
					 ("Multivitamin", "Vitamins", 9.99, 15.99, 100, 10),
					 ("Panadol", "Medicines", 4.49, 8.99, 100, 10),
					 ("Cleanser", "Beauty", 8.99, 12.49, 100, 10),
					 ("David Beckham", "Fragrances", 39.99, 49.99, 100, 10);

insert into Sales (ProductID, NumberSold, SaleDate)
		values (1, 2, "2021-08-01"),
			   (2, 1, "2021-08-02"),
               (3, 2, "2021-08-03"),
			   (4, 1, "2021-08-04"),
               (5, 2, "2021-08-05"),
			   (1, 1, "2021-08-06"),
               (2, 2, "2021-08-07"),
			   (3, 1, "2021-08-08"),
               (4, 2, "2021-08-09"),
			   (5, 1, "2021-09-01"),
               (1, 2, "2021-09-02"),
			   (2, 1, "2021-09-03"),
               (3, 2, "2021-09-04"),
			   (4, 1, "2021-09-05"),
               (5, 2, "2021-09-06"),
			   (2, 1, "2021-09-07");
