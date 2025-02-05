-- uncomment when db needs a refresh

--DROP TABLE IF EXISTS Users;
--DROP TABLE IF EXISTS Moods;
--DROP TABLE IF EXISTS JournalEntries;

CREATE TABLE IF NOT EXISTS Users (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    PasswordHash TEXT NOT NULL
);


CREATE TABLE IF NOT EXISTS Moods (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Date TEXT NOT NULL,
    Mood TEXT NOT NULL,
    UserID INTEGER NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(ID) ON DELETE CASCADE
);


CREATE TABLE IF NOT EXISTS JournalEntries (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    UserID INTEGER NOT NULL,
    Date TEXT NOT NULL,
    Entry TEXT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(ID)
);



CREATE TABLE IF NOT EXISTS Affirmations (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Message TEXT NOT NULL
);

INSERT INTO Affirmations (Message) VALUES 
("You are enough."),
("Believe in yourself."),
("You are capable of great things."),
("Every day is a new beginning."),
("You are stronger than you think."),
("Your potential is limitless."),
("You are loved and valued.");
