-- Active: 1720050651415@@bzkguckw75lz4uaddpob-mysql.services.clever-cloud.com@3306@bzkguckw75lz4uaddpob
CREATE TABLE users(
    id_user INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(125) NOT NULL,
    Email VARCHAR(125) UNIQUE NOT NULL,
    Password VARCHAR(125) NOT NULL,
    Phone VARCHAR(125) NOT NULL,
    Token VARCHAR(255) NOT NULL
);

INSERT INTO users (Name, Email, Password, Phone, Token) VALUES 
("Daniel", "test@gmail.com", "1234", "31454656", "5132sda");

CREATE TABLE folders(
    id_folder INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(255) NOT NULL,
    parenFolderId INT NOT NULL,
    UserId INT NOT NULL
);

INSERT INTO folders (Name, `parentFolderId`, `UserId`) VALUES 
("folder1", 1, 1);

CREATE TABLE archives(
    id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(100) NOT NULL,
    FolderId INT NOT NULL,
    CreationDate DATE NOT NULL
);

INSERT INTO archives (Name, FolderId, CreationDate) VALUES
("archive1", 1, "2020-02-02");

SHOW TABLES;

SELECT * FROM archives;