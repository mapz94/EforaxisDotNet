CREATE TABLE ProductTypes(
  ProductTypeID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  TypeName nvarchar(255) UNIQUE NOT NULL
)

CREATE TABLE Pymes(
  PymeID int NOT NULL PRIMARY KEY IDENTITY(1,1),
  PymeName nvarchar(255) UNIQUE NOT NULL
)

CREATE TABLE Products (
  ProductsID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  ProductName nvarchar(255) UNIQUE NOT NULL,
  Price float NOT NULL DEFAULT 0,
  Discount float NOT NULL DEFAULT 1.0,
  Active bit NOT NULL DEFAULT 1,
  FeaturedImage nvarchar(255) DEFAULT '/assets/notFound.png',
  ProductType int NOT NULL FOREIGN KEY REFERENCES ProductTypes(ProductTypeID),
  PymeID int NOT NULL FOREIGN KEY REFERENCES Pymes(PymeID),
)

CREATE TABLE Users (
  UserID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  UserEmail nvarchar(255) UNIQUE NOT NULL,
  UserPassword nvarchar(255) UNIQUE,
  Active bit NOT NULL DEFAULT 1
)

/* CREATE TABLE order_states (
  order_states_id int PRIMARY KEY IDENTITY(1, 1),
  order_state nvarchar(255) UNIQUE NOT NULL
) */

/* CREATE TABLE payment_types (
  payment_types_id int PRIMARY KEY IDENTITY(1, 1),
  payment_type nvarchar(255) UNIQUE NOT NULL
) */



CREATE TABLE Orders (
  OrderID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  UserID int NOT NULL FOREIGN KEY REFERENCES Users(UserID) DEFAULT 1,
  OrderAddress nvarchar(255) NOT NULL,
  OrderCommune nvarchar(255) NOT NULL,
  OrderRegion nvarchar(255) NOT NULL,
  SubTotal float NOT NULL DEFAULT 0,
  Tax float NOT NULL DEFAULT 0,
  Discount float NOT NULL DEFAULT 0,
  Total float NOT NULL DEFAULT 0,
  OrderState int NOT NULL DEFAULT 0,
  PaymentType int NOT NULL DEFAULT 0
)

CREATE TABLE OrderDetails (
  OrderDetailsID int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  OrderID int NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
  ProductID int NOT NULL FOREIGN KEY REFERENCES Products(ProductsID),
  Quantity int NOT NULL DEFAULT 1,
  SubTotal float NOT NULL DEFAULT 0,
  Tax float NOT NULL DEFAULT 0,
  Discount float NOT NULL DEFAULT 0,
  Total float NOT NULL DEFAULT 0
)

INSERT INTO Users(UserEmail, UserPassword) VALUES ('public@gmail.com', '');
INSERT INTO Users(UserEmail, UserPassword) VALUES ('admin@gmail.com', '********');

INSERT INTO ProductTypes(TypeName) VALUES ('Artesanía');
INSERT INTO ProductTypes(TypeName) VALUES ('Vestuario');
INSERT INTO ProductTypes(TypeName) VALUES ('Tecnología');
INSERT INTO ProductTypes(TypeName) VALUES ('Artículos de Hogar');
INSERT INTO ProductTypes(TypeName) VALUES ('Otros');

INSERT INTO Pymes(PymeName) VALUES ('Artesanos Unidos');
INSERT INTO Pymes(PymeName) VALUES ('Vestuarios Chillán');
INSERT INTO Pymes(PymeName) VALUES ('Technostore Chillán');
INSERT INTO Pymes(PymeName) VALUES ('Muebles Ruta Sur');


/* INSERT INTO payment_types(payment_type) VALUES ('Débito');
INSERT INTO payment_types(payment_type) VALUES ('Crédito'); */

INSERT INTO products(ProductName, Price, FeaturedImage, ProductType, PymeID) VALUES ('Pote Artesanal por unidad', 2000, 'https://images.unsplash.com/photo-1621157479674-9fd8fa4fbf81?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80', 1, 1);
INSERT INTO products(ProductName, Price, FeaturedImage, ProductType, PymeID) VALUES ('Par Aros Artesanales', 4000, 'https://images.unsplash.com/photo-1573227895226-86880bc6ce44?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=80', 1, 1);

INSERT INTO products(ProductName, Price, FeaturedImage, ProductType, PymeID) VALUES ('Vestido Verde', 8000, 'https://images.unsplash.com/flagged/photo-1585052201332-b8c0ce30972f?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=400&q=80', 2, 2);
INSERT INTO products(ProductName, Price, FeaturedImage, ProductType, PymeID) VALUES ('Chaqueta Café', 14000, 'https://images.unsplash.com/photo-1591047139829-d91aecb6caea?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=400&q=80', 2, 2);

INSERT INTO products(ProductName, Price, FeaturedImage, ProductType, PymeID) VALUES ('Disco Duro 3.5" Western Digital 250GB', 18000, 'https://images.unsplash.com/photo-1618555981542-06bd8cf63233?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=400&q=80', 3, 3);
INSERT INTO products(ProductName, Price, FeaturedImage, ProductType, PymeID) VALUES ('Control Blanco Xbox One Original', 35000, 'https://images.unsplash.com/photo-1600080972464-8e5f35f63d08?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=400&q=80', 3, 3);

INSERT INTO products(ProductName, Price, FeaturedImage, ProductType, PymeID) VALUES ('Piso moderno 1 metro', 20000, 'https://images.unsplash.com/photo-1503602642458-232111445657?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=400&q=80', 4, 4);
INSERT INTO products(ProductName, Price, FeaturedImage, ProductType, PymeID) VALUES ('Set Bowls 6 piezas', 12000, 'https://images.unsplash.com/photo-1567763745030-bfe9c51bec27?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=400&q=80', 4, 4);
