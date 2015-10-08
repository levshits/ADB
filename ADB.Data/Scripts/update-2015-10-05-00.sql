CREATE TABLE Client
(
Id int Identity(1,1) NOT NULL,
FirstName nvarchar(200),
LastName nvarchar(200),
Version int NOT NULL Default(0),
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
    [ID] ASC
)
);