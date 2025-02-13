-- Active: 1721134692719@@bzkguckw75lz4uaddpob-mysql.services.clever-cloud.com@3306@bzkguckw75lz4uaddpob

CREATE TABLE users(
    id_user INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(125) NOT NULL,
    Email VARCHAR(125) UNIQUE NOT NULL,
    Password VARCHAR(125) NOT NULL,
    Phone VARCHAR(125) NOT NULL
);

drop table users;

INSERT INTO users (Name, Email, Password, Phone) VALUES 
("Montiel", "test2@gmail.com", "098765", "3123151"),
("John", "John@gmail.com", "john1234", "4112332");

CREATE TABLE folders(
    id_folder INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(255) NOT NULL,
    parentFolderId INT,
    UserId INT NOT NULL,
    Foreign Key (parentFolderId) REFERENCES folders(id_folder),
    Foreign Key (UserId) REFERENCES users(id_user)
);

DROP TABLE folders;

INSERT INTO folders (Name, `UserId`) VALUES 
("folder1", 1);

CREATE TABLE archives(
    id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    FolderId INT NOT NULL,
    CreationDate DATE NOT NULL,
    FilePath VARCHAR(255) NOT NULL,
    Foreign Key (FolderId) REFERENCES folders(id_folder)
);

DROP TABLE archives;

INSERT INTO archives (Name, FolderId, CreationDate, `FilePath`) VALUES
("archive1", 1, "2020-02-02","asdasd");

SHOW TABLES;

SELECT * FROM archives;