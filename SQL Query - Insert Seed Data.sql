
SET IDENTITY_INSERT [Users] ON; 

INSERT INTO [Users] ([Id], [UserName], [Email], [Password])
VALUES
(1, 'JohnDoe', 'johndoe@email.com', 'password123'),
(2, 'JaneSmith', 'janesmith@email.com', 'securepassword'),
(3, 'AliceWong', 'alicewong@email.com', 'alicespassword');

SET IDENTITY_INSERT [Users] OFF;

SET IDENTITY_INSERT [Clothes] ON;

INSERT INTO [Clothes] ([Id], [Name], [Size], [Status], [Image], [Material], [Notes], [UserId])
VALUES
(1, 'Tie Dye Batwing Sleeve Tee', 'Large', 1, 'https://postimg.cc/Y4v48Mdz', '95% Polyester 5% Elastane', 'A little big in the sleeves', 1),
(2, 'Peak Collar Buckle Belted Blazer', 'Medium', 0, 'https://postimg.cc/8sgRkXkP', '95% Polyester - 5% Elastane', 'does not look like picture', 1),
(3, 'Allover Print Wide Leg Jumpsuit', 'Large', 1, 'https://postimg.cc/47HR8NHZ', 'Cotton', 'does not look like picture', 3);

SET IDENTITY_INSERT [Clothes] OFF;

SET IDENTITY_INSERT [Gadgets] ON;

INSERT INTO [Gadgets] ([Id], [Name], [Status], [Image], [Notes], [UserId])
VALUES
(1, 'Power Display Long Lasting Battery Wireless Earbuds', 1, 'https://postimg.cc/yJxR5F89', 'great quality', 1),
(2, 'ABS Multipurpose Portable Curling Iron', 1, ' https://postimg.cc/HJywnY0h', 'not good for thick hair', 2),
(3, 'Expandable Water Hose', 0, 'https://postimg.cc/67ByCBC3', 'good quality', 1);

SET IDENTITY_INSERT [Gadgets] OFF;

SET IDENTITY_INSERT [Shoes] ON;

INSERT INTO [Shoes] ([Id], [Name], [Size], [Status], [Image], [Notes], [UserId])
VALUES
(1, 'Lace Up Sneakers', 7, 1, 'https://postimg.cc/N2BGT43H', 'great for running', 1),
(2, 'Gladiator Sandals', 7, 0, 'https://postimg.cc/w3Gb1vD6', 'very uncomfortable', 2),
(3, 'Skate Shoes', 7, 1, ' https://postimg.cc/GBznVCVH', 'Beachwear', 3);

SET IDENTITY_INSERT [Shoes] OFF;