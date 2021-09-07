create database phpsreps_db;
use phpsreps_db;

create table Products (
	ProductID int auto_increment primary key,
    ProductName varchar(255),
    Category varchar(255),
    CurrentInventory int
);

create table Sales (
	SaleID int auto_increment primary key,
    ProductID int, foreign key (ProductID) references Products(ProductID),
    NumberSold int,
    SaleDate date
);

insert into Products (ProductName, Category, CurrentInventory) 
			  values ("Toothpaste", "Dental Care", 100),
					 ("Multivitamin", "Vitamins", 100),
					 ("Panadol", "Medicines", 100),
					 ("Cleanser", "Beauty", 100),
					 ("David Beckham", "Fragrances", 100);

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