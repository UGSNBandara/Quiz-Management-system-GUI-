CREATE TABLE Players (
    Username NVARCHAR(50) PRIMARY KEY, -- Use NVARCHAR for text keys
    Email NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(255) NOT NULL,
    Score INT NOT NULL,
    Rank INT NOT NULL
);
